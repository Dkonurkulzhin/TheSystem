using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Microsoft.Win32;
using System.Security.Principal;
using System.IO;

namespace Drone.WinSystem
{
    public static class SystemHandler
    {
        public static bool IsInAdministratorRole()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

    }
}
