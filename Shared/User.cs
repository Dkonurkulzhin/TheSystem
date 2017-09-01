using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class User
    {
        public int ID;
        public string name;
        public long exp;
        public long balance;
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

