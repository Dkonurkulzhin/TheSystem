using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class User
    {
        public int ID;
        public string name;
        public int level;
        public long exp;
        public double balance;
        public DateTime regDate;
        public DateTime lastVisit;
        public string personalName;
        public string personalSurname;
        public string phoneNumber;
        public int[] offers;
        public string email;
        public string password;
        public string usergroup = "Default";
        private long expToNextLvl;
        
        public User(string username = "", string userpassword ="")
        {
            name = username;
            password = userpassword;
        }

        public long GetExpToNextLevel()
        {
            return expToNextLvl;

        } 
        public int GetLevel()
        {
            return 0; // Math.Round((float)exp);
        }

        public void SetExpToNextLevel(long exp)
        {
            expToNextLvl = exp;
        }
    }

