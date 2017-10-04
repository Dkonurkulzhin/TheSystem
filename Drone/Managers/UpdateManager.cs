using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoUpdaterDotNET;
using System.Reflection;
using System.Diagnostics;


namespace Drone
{
    public static class UpdateManager
    {

        public delegate void NullEventHandler();
        public static event NullEventHandler OnLatestVerision;
        public static event NullEventHandler OnServerFailed;

        static Assembly assembly = Assembly.GetExecutingAssembly();
        static FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
        static string version = fileVersionInfo.ProductVersion;

        public static void Initialize()
        {
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
        }

        public static void StartUpdateCheck()
        {
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Start(GlobalVars.UpdateInfoLink);
        }

        public static string GetCurrentVersion()
        {
            return version;
        }

        private static void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args != null)
            {
                if (args.IsUpdateAvailable)
                {
                    try
                    {
                        //You can use Download Update dialog used by AutoUpdater.NET to download the update.
                        if (AutoUpdater.DownloadUpdate())
                        {
                            Program.ShutDownApp();
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message, exception.GetType().ToString());
                    }

                }
                else
                    OnLatestVerision?.Invoke();
            }
            else
                OnServerFailed?.Invoke();
        }


    }
}
