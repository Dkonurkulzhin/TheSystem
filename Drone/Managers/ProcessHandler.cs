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

namespace Drone.WinSystem
{
    public static class ProcessHandler
    {
        static List<Process> SessionProcesses = new List<Process>();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);
        [DllImport("USER32.DLL")]

        private static extern IntPtr GetShellWindow();

        public static string RunApp(string path, string commandline = null)
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

        public static void EndSessionProcesses()
        {
            foreach (Process process in SessionProcesses)
                if (process != null)
                    try
                    {
                        process.Kill();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
        }

        public static void RunWinShellProcess()
        {
            Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"));
        }

        public static void KillWinShellProcess()
        {
            foreach (Process p in Process.GetProcessesByName("explorer"))
            {
                p.Kill();
            }
        }

        public static List<string> ViewProcesses()
        {
            List<string> ProcNames = new List<string>();
            foreach (Process p in Process.GetProcesses(System.Environment.MachineName))
            {
                ProcNames.Add(p.ProcessName);
            }
            return ProcNames;
        }

        public static void KillAllActive(string[] excepts)
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

        private static bool NameExceptsList(string ProcName, string[] excepts)
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

