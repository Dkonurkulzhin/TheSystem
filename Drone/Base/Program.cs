using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Diagnostics;
using Microsoft.Win32;

namespace Drone
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
       
        static public ProcessManager ProcMNG = new ProcessManager();
       
        static public bool isPendingUpdate = false;

        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            GlobalVars.LoadSettings();
            GlobalVars.CreateSystemFolders();
            InitManagers();
            Application.Run();
            
          
            // MainForm.Hide();
            Application.DoEvents();
           
            ProcMNG.AdjustWinShell(false);
            //   MainForm.Hide();  
           
        }

        public static void InitManagers()
        {
            NetworkManager.Initialize();
            SessionManager.Initialize();
            UIManager.Initialize();
        }

        static public void LogOut()
        {
            //LobbyForm.Invoke(new Action(LobbyForm.Show));
            ////MainForm.Invoke(new Action(MainForm.ShowUI(false)));
            //MainForm.Invoke(new Action(MainForm.ShowUI));
            //MainForm.Invoke(new Action(MainForm.Hide));
            ////MainForm.Hide();
            //CurrentUser = null;
            //NetworkManager.UpdateEchoMessage();
            //if (isPendingUpdate)
            //    PerformUpdate();
        }

        static public void LogIn(User user)
        {
          
            //MainForm.Show();
            //MainForm.ShowUI();
            //LobbyForm.Hide();
            //CurrentUser = user;
            //NetworkManager.UpdateEchoMessage();
        }

        static public void ShutDownApp(bool enableShell = true)
        {
            
            ProcMNG.AdjustWinShell(enableShell);
            GlobalVars.StopApplyingRights = enableShell;
            RegistryManager.SetTaskManager(enableShell);
            
            Application.Exit();
        }

        static private void InitDebugStuff()
        {
      
        }

        static public void PerformUpdate()
        {
            try
            {
                ProcMNG.RunApp(GlobalVars.UpdaterPath);
                ShutDownApp();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
 
        static public bool CheckAdmin() 
        {
            bool isElevated;
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            return isElevated;
        }

    }
}
