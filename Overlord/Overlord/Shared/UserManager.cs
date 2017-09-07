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

        public static User FindUserByName(string name)
        {
            return Program.uscon.DeserializeUser(name);
            
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
