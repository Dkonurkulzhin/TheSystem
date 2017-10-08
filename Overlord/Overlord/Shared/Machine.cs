using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overlord
{
    public class Machine
    {
        public int index;
        public string label;
        public string username;
        public bool aviability;
        public MachineManager.MachineStatus status;
        public long time;
        public long balance;
        public string group = GlobalVars.DefaultMachineGroup;
        public float priceMultiplier = 1;
        public string IP;
        public string MAC_ADDRESS;
        public long CleintVersion;
        public User user;
    }
}
