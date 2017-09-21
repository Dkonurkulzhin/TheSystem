using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
    public static class UIManager
    {
        static public Form1 MainForm;
        static public LogInForm LobbyForm;
        static public DebugForm DevForm;
        static public InitForm InitScreen;
       

        static UIManager()
        {
            
            SessionManager.OnLogIn += ShowMainForm;
            Console.WriteLine("UI manager has been initialized");
        }

        static public void Initialize()
        {
            MainForm = new Form1();
            InitScreen = new InitForm();
            LobbyForm = new LogInForm();
            //
            //InitScreen.Show();
            
            DevForm = new DebugForm();
            DevForm.TopMost = true;
            DevForm.Show();
        }

        static void ShowMainForm()
        {
            LobbyForm.TopMost = true;
            MainForm.Show();
            LobbyForm.TopMost = false;
            LobbyForm.Hide();
            

           
        }

        static void ShowLobbyForm()
        {
            
            //MainForm.Hide();
            LobbyForm.Show();
        }
    }
}
