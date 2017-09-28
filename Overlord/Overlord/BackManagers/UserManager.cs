using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Overlord
{
   public static class UserManager
    {
        public static List<User> ActiveUsers = new List<User>();

        private static TempUserControllu UserDB = new TempUserControllu();
        
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

        public static void SaveUser(string name)
        {
            UserDB.SaveUser(GetUserByName(name));
        }


        public static bool AddExp(User user, long exp)
        {

            return true;

        }

        public static bool AddBalance(User user, int value)
        {
            return true;
        }
        


    }
}
