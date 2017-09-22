using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Drone.WinSystem;


namespace Drone
{
    public static class SecurityManager
    {
        static SecurityManager()
        {
            
        }

        public static void ToggleWindowsShell(bool toggle)
        {
            if (SystemHandler.IsInAdministratorRole())
            {
                RegistryHandler.ToggleShellAutoRestart(toggle);
                RegistryHandler.SetTaskManager(toggle);
                if (toggle)
                    ProcessHandler.RunWinShellProcess();
                else
                    ProcessHandler.KillWinShellProcess();
            }

        }



    }
}
