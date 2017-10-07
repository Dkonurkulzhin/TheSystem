﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Overlord.Elements;

namespace Overlord
{
   public static class UserManager
    {
        public static List<User> ActiveUsers = new List<User>();
        public enum RateFormat { perHour, perMinute, perSecond};
        private static TempUserControllu UserDB = new TempUserControllu();
        private static MachineStatUpdater machineStatUpdater = new MachineStatUpdater();
    
        public static void Initialize()
        {
           machineStatUpdater.OnUserLoggedOut += LogOutUserFromMachine;
        }
        
        public static void AddActiveUser(User user)
        {
            if (!ActiveUsers.Contains(user))
                ActiveUsers.Add(user);
        }

        public static string GetActiveUsersString()
        {
            string ActiveUserNames = "Текущие пользователи: ";
            foreach (User user in ActiveUsers)
            {
                ActiveUserNames += user.name + ", ";
            }
            return ActiveUserNames;
        }

        public static void VerifyActiveUserList(List<User> users)
        {
            ActiveUsers = users;
        }


        public static void LogOutUserFromMachine(int index)
        {

        }

        public static User CheckUserData(string name, string password)
        {
            User UserToSend = UserDB.DeserializeUser(name);
            if (UserToSend != null) //если пользовтель найден проверяем пароль
            {
                if (UserToSend.password == null || UserToSend.password == "") //если пароль не выставлен отправляем пользователя
                    return UserToSend;

                if (UserToSend.password == password) // если пароли совпадают, отправляем пользователя 
                    return UserToSend;
                else            
                    return null;      //иначе отправляем null
            }
            return UserToSend;
            
        }

        public static User GetUserByName(string name)
        {
            return UserDB.DeserializeUser(name);
        }

        public static List<string> GetUserList(string filter = "")
        {
            return UserDB.ListUsers(filter);
        }

        public static bool DeleteUser(string name)
        {
            return UserDB.DeleteUser(name);
        }

        public static void SaveUser(User user)
        {
            UserDB.SaveUser(user);
        }


        public static bool AddExp(User user, long exp)
        {

            return true;

        }

        public static bool AddBalance(User user, int value)
        {
            if (value > 20000)
                return false;
            user.balance += value;
            SaveUser(user);
            return true;
        }

        public static float GetCurrentRate(User user, RateFormat rateFormat = RateFormat.perSecond)
        {
            int rate = GlobalVars.Settings.BaseRatePerHour - user.level * GlobalVars.Settings.RatePerLevel;
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
            return (float)200 / 3600; //currentUser.exp;
        }

    }
}
