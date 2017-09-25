using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Windows.Forms;
using Drone.Managers;

namespace Drone
{
    public static class UIManager
    {
        static Form1 MainForm;
        static LogInForm LobbyForm;
        static DebugForm DevForm;
        static InitForm InitScreen;

        static Form[] AppForms = { MainForm, LobbyForm, DevForm, InitScreen };


        public delegate void MessageDelegate(string message);
        public delegate void UserDelegate(User user);

        public static event MessageDelegate OnInvalidUserAuthorization;
        public static event UserDelegate OnUserStatsUpdated;

        static UIManager()
        {
            Console.WriteLine("UI manager has been initialized");
        }

        static public void Initialize(bool ReplaceWinShell = true)
        {
            MainForm = new Form1();
            InitScreen = new InitForm();
            LobbyForm = new LogInForm();
            //
            //InitScreen.Show();
            MainForm.Show();
            MainForm.Hide();
            LobbyForm.Show();
          
            DevForm = new DebugForm();
            DevForm.TopMost = true;
            DevForm.Show();
            if (ReplaceWinShell)
            {
                SecurityManager.ToggleWindowsShell(false);
            }

            // бинд ивентов
            SessionManager.OnPenaltyApplied += ShowPenaltyMessage;
            SessionManager.OnRejectedSession += ShowInvalidUserMessage;
            SessionManager.OnLogIn += ShowMainForm;
            SessionManager.OnLogOut += ShowLobbyForm;
            SessionManager.OnUserStatsUpdated += UpdateUserStats;
        }

        #region Внешние методы

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

        public static void ExecuteAdminLogIn()
        {
            ShowMainForm();
            SessionManager.currentUser = new User("Administrator", "");
        }

        public static void PerformLogOut()
        {
            if (SessionManager.currentUser != null)
            {
                SessionManager.CloseSession();
                ShowLobbyForm();
            }
        }

        public static void PerformLogIn(User user)
        {
            if (SessionManager.currentUser == null)
            {
                SessionManager.SendOpenSessionReqest(user);
            }
        }
        #endregion


        #region Базовая логика интерфейса

        private static void ShowMainForm()
        {
            //LobbyForm.TopMost = true;
            LobbyForm.Invoke(new Action(delegate () { LobbyForm.Hide(); }));
            MainForm.Invoke(new Action(delegate () { MainForm.Show(); }));
        }

        private static void ShowLobbyForm()
        {
            MainForm.Invoke(new Action(delegate () { MainForm.Hide(); }));
            LobbyForm.Invoke(new Action(delegate () { LobbyForm.Show(); }));
            LobbyForm.Invoke(new Action(delegate () { LobbyForm.TopMost = false; }));
        }

        private static void UpdateUserStats(User user)
        {
            if (user != null)
                OnUserStatsUpdated?.Invoke(user);
        }
        #endregion
       


        #region Вывод сообщений с сервера

        static void ShowPenaltyMessage(int penalty)
        {
            ShowGenericMessage("Штраф " + penalty.ToString() + " - за нарушение правил заведения", Color.Red);
        }

        static void ShowInvalidUserMessage(string message)
        {
            OnInvalidUserAuthorization?.Invoke(message);
        }

        static void ShowWarningMessage(string message)
        {
            ShowGenericMessage(message, Color.White);
        }


        static void ShowGenericMessage(string message, Color messageColor)
        {
            MessageForm msgForm = new MessageForm(message, messageColor);
            msgForm.StartPosition = FormStartPosition.CenterScreen;
            msgForm.Show();
            msgForm.TopMost = true;
                  
        }
        #endregion
    }
}
