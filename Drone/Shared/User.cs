using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    public class User
    {
        public int ID;
        public string name;
        public long exp;
        public int level;
        public double balance;
        public DateTime regDate;
        public DateTime lastVisit;
        public string personalName;
        public string personalSurname;
        public string phoneNumber;
        public int[] offers;
        private long expToNextLvl;
       
        public long GetExpToNextLevel()
        {
            return expToNextLvl;

        }

        public void SetExpToNextLevel(long exp)
        {
           
        }
    }
}
