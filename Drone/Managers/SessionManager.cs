using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Timers;


namespace Drone
{
    public static class SessionManager
    {
        public enum SessionType {Regular, Bonus};
        public static SessionType sessionType = SessionType.Regular;
        public static Stopwatch SessionTimer;
        public static User currentUser;
        public static Timer tick;
        public static volatile  float currentBalance;
        public static volatile  int secondsLeft;
        public static volatile float currentRate;
        public  enum RateFormat {perHour, perMinute, perSecond};
        private static TimeSpan lastTickTime;

        public delegate void EmptySessionDelegate();
        public delegate void UserSessionDelegate(User user);
        public delegate void TextSessionDelegate(string message);
        public delegate void NumericSessionDelegate(int num);

        public static event EmptySessionDelegate OnLogIn;
        public static event EmptySessionDelegate OnLogOut;
        public static event TextSessionDelegate OnRejectedSession;
        public static event UserSessionDelegate OnUserStatsUpdated;
        public static event NumericSessionDelegate OnPenaltyApplied;
        public static event TextSessionDelegate OnRejectedBonus;

        public static List<BonusObject> Bonuses;

        private static BonusObject CurrentBonus;

        static SessionManager()
        {
           
            Console.WriteLine("Session manager has been initialized");
        }

        public static void Initialize()
        {
            NetworkManager.OnUserRecieve += TryOpenSession;
            NetworkManager.OnPenalty += ApplyPenalty;
            NetworkManager.OnLogOutCommand += TryCloseSessionOnCommand;
            LoadBonuses();
        }

        #region Открытие/закрытие сесии 

        public static void SendOpenSessionReqest(User user)
        {
            NetworkManager.sendLoginRequest(user);
        }
         

        public static void TryOpenSession(User user)
        {
           if (user != null && user.name != null && user.name != "")
           {
                if (user.balance >= -1000)
                {
                   
                    ProcessSession(user);     
                }
                else
                    OnRejectedSession?.Invoke("недостаточно средсвт на аккаунте"); 
           }
           else
           {
                OnRejectedSession?.Invoke("неправильный пользователь или пароль");
           }
        
        }

        public static void ProcessSession(User user)
        {
            if (currentUser == null)
            {
                currentUser = user;
                StartSession();
            }
            else
            {
                if (user.name == currentUser.name)
                    currentUser.balance = user.balance;
            }
            
        }

        private static void StartSession()
        {
            lastTickTime = TimeSpan.Zero;

            SessionTimer = new Stopwatch();
            SessionTimer.Reset();
            SessionTimer.Start();

            tick = new Timer(1000);
            tick.AutoReset = true;
            tick.Enabled = true;
            tick.Elapsed += SessionTick;
            OnLogIn?.Invoke(); // открываем сессию при получении валидных данных о пользователе с сервера
        }

        public static void CloseSession()
        {
            if (currentUser != null)
            {
                EndSession();
                currentUser = null;
                
            }
        }

        private static DateTime EndSession()
        {
            tick.Elapsed -= SessionTick;
            tick.Stop();
            tick.Close();

            SessionTimer.Reset();
            SessionTimer.Stop();

            OnLogOut?.Invoke();

            CurrentBonus = null;
            return DateTime.Now;
        }

        private static void TryCloseSessionOnCommand(string message)
        {
            //Метод вызывается при команде закрытия сессии с сервера
            CloseSession();
            
        }

        #endregion

        #region Бонусы

        private static void LoadBonuses()
        {
           // XMLManager.
        }

        public static void OpenBonusSession(BonusObject bonus)
        {
            int currentHour = DateTime.Now.Hour; //исправить!!! ненадежно!
            if (currentUser!= null)
            {
                if (IsBonusAvailable(bonus))  
                {
                    if (currentUser.balance >= bonus.cost * 0.95)
                    {
                        sessionType = SessionType.Bonus;
                        currentUser.balance -= bonus.cost;
                        CurrentBonus = bonus;
                        CurrentBonus.startDay = DateTime.Now.Day;
                    }
                    else
                        OnRejectedBonus?.Invoke("Недостаточно средств на аккаунте");
                }
                else
                {
                    OnRejectedBonus?.Invoke("Акция станет доступна с " + bonus.startHour + ":00");

                }
            }
        }

        public static string GetActiveBonusName()
        {
            if (CurrentBonus == null)
                return "";
            else
                return CurrentBonus.bonusName;
        }



        private static bool IsBonusAvailable(BonusObject bonus)
        {

            int currentHour = DateTime.Now.Hour;
            int startHour = bonus.startHour;
            int endHour = bonus.endHour;
            if (bonus.startHour > bonus.endHour)
            {
                return (currentHour >= startHour || currentHour < endHour);
            }
            else
            {
                return (currentHour >= startHour && currentHour < endHour);
            }
            
        }

        #endregion
        private static void ApplyPenalty(int penalty)
        {
            OnPenaltyApplied?.Invoke(penalty);
            if (currentUser != null)
            {
                currentUser.balance -= penalty;
            }
        }


        #region Методы вызываемые в тике

        private static void SessionTick(object sender, ElapsedEventArgs e)
        {
            OnUserStatsUpdated?.Invoke(currentUser);
            if (sessionType == SessionType.Regular)
            {
                UserProcessRegular();
            }
            else
            {
                UserProcessBonus();
            }
        }

        private static void UserProcessRegular()
        {
            double interval = SessionTimer.Elapsed.TotalSeconds - lastTickTime.TotalSeconds;
            lastTickTime = SessionTimer.Elapsed;
            currentUser.balance -= interval*GetCurrentRate();
            CalculateStats();
            if (currentUser.balance <= 0)
            {
                EndSession();
                OnLogOut.Invoke();
            }
            //Console.WriteLine("Time left " + SessionTimer.Elapsed.TotalSeconds.ToString() + " CurrentBalance " + currentUser.balance.ToString());
        }

        private static void UserProcessBonus()
        {

            int currentHour = DateTime.Now.Hour;
            if (CurrentBonus == null)
            {
                sessionType = SessionType.Regular;
                return;
            }

            if (!IsBonusAvailable(CurrentBonus))
                sessionType = SessionType.Regular;

            //if (CurrentBonus.startHour > CurrentBonus.endHour)
            //{
            //    if (currentHour >= CurrentBonus.endHour && DateTime.Now.Day != CurrentBonus.startDay)
            //        sessionType = SessionType.Regular;
            //}
            //else
            //{
            //    (currentHour >= CurrentBonus.endHour) //если бонусное время не переходит на следующий день
            //}   

        }
        #endregion

        #region "Get" Методы

        public static float GetCurrentRate(RateFormat rateFormat = RateFormat.perSecond)
        {
            int rate = GlobalVars.rateSettings.BaseRatePerHour - currentUser.level * GlobalVars.rateSettings.RatePerLevel;
            switch (rateFormat)
            {
                case RateFormat.perSecond:
                    return (float)rate / 3600;
                case RateFormat.perMinute:
                    return (float)rate / 60;
                case RateFormat.perHour:
                    return (float)rate;
                default:
                   
                    break;
            }
            return (float) 200/3600; //currentUser.exp;
        }

        private static void CalculateStats()
        {
            currentBalance = (float) currentUser.balance;
            currentRate =  GetCurrentRate();
            secondsLeft = (int) (currentBalance / currentRate);
        }

        #endregion

    }
}
