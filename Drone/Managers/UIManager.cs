using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;


namespace Drone
{
    public static class UIManager
    {
        static Form1 MainForm;
        static LogInForm LobbyForm;
        static DebugForm DevForm;
        static InitForm InitScreen;

        static Form[] AppForms = { MainForm, LobbyForm, DevForm, InitScreen };
        static UIManager()
        {
            
            SessionManager.OnLogIn += ShowMainForm;
            Console.WriteLine("UI manager has been initialized");
        }

        static public void Initialize(bool ReplaceWinShell = true)
        {
            MainForm = new Form1();
            InitScreen = new InitForm();
            LobbyForm = new LogInForm();
            //
            //InitScreen.Show();
            ShowLobbyForm();
            DevForm = new DebugForm();
            DevForm.TopMost = true;
            DevForm.Show();
            if (ReplaceWinShell)
            {
                SecurityManager.ToggleWindowsShell(false);
            }
        }

        static void ShowMainForm()
        {
            LobbyForm.TopMost = true;
            MainForm.Show();
            LobbyForm.TopMost = false;
            LobbyForm.Hide();
        }

        public static void ExitShell()
        {
            foreach (Form form in AppForms)
            {
                if (form != null)
                    form.Close();
            }
            Program.ShutDownApp();
            SecurityManager.ToggleWindowsShell(true);
        }

        static void ShowLobbyForm()
        {
            
            //MainForm.Hide();
            LobbyForm.Show();
        }
    }
}
