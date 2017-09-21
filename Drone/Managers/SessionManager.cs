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
        public static event EmptySessionDelegate OnInvalidUser;
        public static event EmptySessionDelegate OnRejectedSession;
        public static event UserSessionDelegate OnUserStatsUpdated;
        public static event NumericSessionDelegate OnPenaltyApplied;

        static SessionManager()
        {
           
            Console.WriteLine("Session manager has been initialized");
        }

        public static void Initialize()
        {
            NetworkManager.OnUserRecieve += TryOpenSession;
            NetworkManager.OnPenalty += ApplyPenalty;
        }

        private static void SessionTick(object sender, ElapsedEventArgs e)
        {
            OnUserStatsUpdated?.Invoke(currentUser);
            UserProcess();
        }

         

        public static void TryOpenSession(User user)
        {
           if (user != null && user.name != null && user.name != "")
           {
                if (user.balance >= 0)
                {
                    OnLogIn?.Invoke(); // открываем сессию при получении валидных данных о пользователе с сервера
                    OpenSession(user);     
                }
                else
                    OnRejectedSession?.Invoke(); 
           }
           else
           {
                OnInvalidUser?.Invoke();
           }
        }

        public static void OpenSession(User user)
        {
            currentUser = user;
            StartSession();
         
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
            
        }

        public static DateTime EndSession()
        {
            tick.Elapsed -= SessionTick;
            tick.Stop();
            tick.Close();

            SessionTimer.Reset();
            SessionTimer.Stop();

            currentUser = null;
            Program.LogOut();
            return DateTime.Now;
        }


        public static void ApplyPenalty(int penalty)
        {
            OnPenaltyApplied?.Invoke(penalty);
        }


        #region Методы вызываемые в тике

        private static void UserProcess()
        {

            double interval = SessionTimer.Elapsed.TotalSeconds - lastTickTime.TotalSeconds;
            lastTickTime = SessionTimer.Elapsed;
            currentUser.balance -= interval*GetCurrentRate();
            GetStats();
            if (currentUser.balance <= 0)
            {
                EndSession();
                OnLogOut.Invoke();
            }
            Console.WriteLine("Time left " + SessionTimer.Elapsed.TotalSeconds.ToString() + " CurrentBalance " + currentUser.balance.ToString());

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

        private static void GetStats()
        {
            currentBalance =(float) currentUser.balance;
            currentRate =  GetCurrentRate();
            secondsLeft = (int) (currentBalance / currentRate);
        }

        #endregion

    }
}
