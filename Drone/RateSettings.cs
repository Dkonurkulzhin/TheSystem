using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    public class RateSettings
    {
        public long BaseExp = 6000;
        public long ExpDifPerLevel = 3000;
        public int expPerSecond = 1;
        public int MaxLevel = 100;
        public int BaseRatePerHour = 300;
        public int RatePerLevel = 2;
        
    }
}
