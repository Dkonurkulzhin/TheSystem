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
        static public Form1 MainForm;
        static public Form LobbyForm;
        static public DebugForm DevForm;
        static public InitForm InitScreen;
        static public User CurrentUser;
        static public ProcessManager ProcMNG = new ProcessManager();
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GlobalVars.LoadSettings();
            GlobalVars.CreateSystemFolders();
            MainForm = new Form1();
            InitScreen = new InitForm();
            DevForm = new DebugForm();
            DevForm.Show();
            DevForm.TopMost = true;

            // MainForm.Hide();
            Application.DoEvents();
            InitScreen.Show();
            Application.DoEvents();
            LobbyForm = new LogInForm();
            ProcMNG.AdjustWinShell(false);
            //   MainForm.Hide();  
            Application.Run(LobbyForm);
            Application.DoEvents();
            InitScreen.Hide();
            
            if (GlobalVars.debug)
            {
            }
            //FileSystemAccessManager.SetDirRights("Users", @"D:\", true);  
            //RegistryManager.HideDrive("8");
            // MainForm.Show();
            Application.DoEvents();
           
           
        }

        static public void LogOut()
        {
            LobbyForm.Invoke(new Action(LobbyForm.Show));
            //MainForm.Invoke(new Action(MainForm.ShowUI(false)));
            MainForm.Invoke(new Action(MainForm.ShowUI));
            MainForm.Invoke(new Action(MainForm.Hide));
            //MainForm.Hide();
            CurrentUser = null; 
        }

        static public void LogIn(User user)
        {
            MainForm.Show();
            MainForm.ShowUI();
            LobbyForm.Hide();
            CurrentUser = user;
        }

        static public void ShutDownApp()
        {
            //LobbyForm.Close();
            //if (GlobalVars.debug) DevForm.Close();
            //InitScreen.Close();
            ProcMNG.AdjustWinShell(true);
            GlobalVars.StopApplyingRights = true;
            MainForm.Hide();
            InitScreen.Show();
            RegistryManager.SetTaskManager(true);
            
            Application.Exit();
        }

        static private void InitDebugStuff()
        {
      
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
