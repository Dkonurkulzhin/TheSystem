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

        public static void OpenSession(User user)
        {

            Program.LobbyForm.LogIn(user);
            currentUser = user;
            currentUser.balance = 100;
            Program.MainForm.FormIsReady += StartSession;
         

        }

        public static void StartSession()
        {
            lastTickTime = TimeSpan.Zero;
            SessionTimer = new Stopwatch();
            SessionTimer.Reset();
            SessionTimer.Start();
            tick = new Timer(1000);
            tick.Elapsed += UserProcess;
            tick.AutoReset = true;
            tick.Enabled = true;
            tick.Elapsed += Program.MainForm.UserStats.UpdateStats;
            
        }

        public static DateTime EndSession()
        {
            tick.Elapsed -= UserProcess;
            tick.Elapsed -= Program.MainForm.UserStats.UpdateStats;
            tick.Stop();
            tick.Close();
            SessionTimer.Reset();
            SessionTimer.Stop();
            
            Program.LogOut();
            return DateTime.Now;
        }

        public static void UserProcess(Object source, ElapsedEventArgs e)
        {

            double interval = SessionTimer.Elapsed.TotalSeconds - lastTickTime.TotalSeconds;
            lastTickTime = SessionTimer.Elapsed;
            currentUser.balance -= interval*GetCurrentRate();
            GetStats();
            if (currentUser.balance <= 0)
            {
                EndSession(); 
            }
            Console.WriteLine("Time left " + SessionTimer.Elapsed.TotalSeconds.ToString() + " CurrentBalance " + currentUser.balance.ToString());

        }

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
        
    }
}
