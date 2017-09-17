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
        
        
        public static bool ConnectToDB()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = @"Server=[.\SQLEXPRESS];Database=[database_name];Trusted_Connection=true";
                SqlCommand command = new SqlCommand("SELECT * FROM TableName", conn);
            }
            return true;
        }

        public static User FindUserByName(string name, string password)
        {
            User UserToSend = Program.uscon.DeserializeUser(name);
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
