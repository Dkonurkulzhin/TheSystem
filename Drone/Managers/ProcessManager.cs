using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Security.Principal;
using System.IO;
using System.Runtime.InteropServices;

namespace Drone
{
    class ProcessManager
    {
        List<Process> SessionProcesses = new List<Process>();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);
        [DllImport("USER32.DLL")]

        private static extern IntPtr GetShellWindow();

        public string RunApp(string path, string commandline = null)
        {
            if (path != "")
            {
                if (commandline == null)
                    try
                    {
                        SessionProcesses.Add(Process.Start(path));
                        return "Running";
                    }
                    catch (Exception e)
                    {
                        return "Invalid path" + "||" + e.ToString();
                    }
                else
                {
                    try
                    {
                        SessionProcesses.Add(Process.Start(path));
                        return "Running";
                    }
                    catch (Exception e)
                    {
                        return "Invalid path" + "||" + e.ToString();
                    }
                }
            }
            else
            {
                return "No App path";
            }
        }

        public void AdjustWinShell(bool adjust)
        {
            bool isElevated;
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            if (isElevated)
            {
                RegistryKey ourKey = Registry.LocalMachine;
                ourKey = ourKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
                if (adjust)
                {
                    ourKey.SetValue("AutoRestartShell", 1);
                    Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"));

                }
                else
                {
                    ourKey.SetValue("AutoRestartShell", 0);
                    foreach (Process p in Process.GetProcessesByName("explorer"))
                    {
                        p.Kill();
                        
                    }

                    
                }
                
            }
           
               
        }

        public List<string> ViewProcesses()
        {
            List<string> ProcNames = new List<string>();
            foreach (Process p in Process.GetProcesses(System.Environment.MachineName))
            {
                ProcNames.Add(p.ProcessName);
            }
            return ProcNames;
        }

        public void KillAllActive(string[] excepts)
        {
            foreach (Process p in Process.GetProcesses(System.Environment.MachineName))
            {
                if (p.MainWindowHandle != IntPtr.Zero)
                { 
                    if (!NameExceptsList(p.ProcessName, excepts))
                        p.Kill(); 
                }
            }
          
        }

        private bool NameExceptsList(string ProcName, string[] excepts)
        {
            foreach (string n in excepts)
            {
                if (ProcName.Contains(n))
                {
                    return true; 
                }
            }
            return false;
        }



    }
}

