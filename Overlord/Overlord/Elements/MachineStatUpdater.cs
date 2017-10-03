using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Overlord.Elements
{
     class MachineStatUpdater
    {
        public delegate void NotifyStatusUpdate(int index);
        public event NotifyStatusUpdate OnUserLoggedOut;
        Machine[] Machines;
        Machine[] PreviousMachines;
        Timer TickTimer;
        public MachineStatUpdater(int CheckPeriod = 3000)
        {
            TickTimer = new Timer(CheckPeriod);
            TickTimer.AutoReset = true;
            TickTimer.Elapsed += UpdateStats;


        }

        void UpdateStats(object sender, ElapsedEventArgs e)
        {
            Machines = MachineManager.Machines;
            if (PreviousMachines != null && Machines.Length == PreviousMachines.Length)
            {
                int i = 0;
                foreach (Machine machine in Machines)
                {
                    if (Machines[i].username != PreviousMachines[i].username)
                    {
                        DebugManager.AddLine("USER HAS LOGGED OUT: " + PreviousMachines[i].user);
                        OnUserLoggedOut?.Invoke(i);
                    }
                    i++;
                }

            }
            
            PreviousMachines = Machines;
        }
    }
}
