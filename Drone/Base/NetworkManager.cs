using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Networking;

using NetworkCommsDotNet;


namespace Drone
{
    public static class NetworkManager
    {
        private static MessageHandler messageHanlder = new MessageHandler();
        private static UDPBroadcaster broadcaster = new UDPBroadcaster(1000, Constants.UDPBroodcastPort);

        public delegate void UpdateEchoMessageEH();
        public delegate void EmptyMessageDelegate();
        public delegate void NumericMessageDelegate(int num);
        public delegate void StringMessageDelegate(string message);
        public delegate void UserMessageDelegate(User user);

        public static event UserMessageDelegate OnUserRecieve; // вызывается при получении пользователя с сервера
        public static event EmptyMessageDelegate OnLogoutRequest; // вызывается при запросе об окончании ссесси с сервера
        public static event NumericMessageDelegate OnPenalty; // вызывается при получении штрафа
        public static event StringMessageDelegate OnMessage; // вызывается при получении текстового сообщения с сервера





        static NetworkManager()
        {
            Console.WriteLine("Network manager has been initialized");
        }


        public static void Initialize()
        {
            messageHanlder.StartClientListening(GlobalVars.settings.serverIP);
            messageHanlder.NotifyUpdate += SetPendingUpdate;
            broadcaster.StartBroadcasting(Constants.RequestHeaders[Constants.Messages.Echo], new MachineStatMessage(
                GlobalVars.settings.pcNumber, false, "", 0 ,0 ));
            
        }

        public static void UpdateEchoMessage()
        {
            broadcaster.Content = new MachineStatMessage(GlobalVars.settings.pcNumber,
                (SessionManager.currentUser == null) ? false : true, SessionManager.currentUser.name, 
                (long) SessionManager.currentBalance, SessionManager.secondsLeft);
        }
        public static void sendLoginRequest(User user)
        {
            messageHanlder.SendLogInRequest(user, GlobalVars.settings.serverIP); //);
            messageHanlder.UserRecieved += CheckRequestedUser;   
        }

        public static void CheckRequestedUser(User user)
        {
            if (user == null || user.name == null || user.name == "")
            {
               // Program.LobbyForm.SetErrorText("Неправльный пользователь или пароль");
                Console.WriteLine("Invalid USER!!!");
                return;
            }
                
            User incommingUser = user as User;
            SessionManager.OpenSession(incommingUser);
        }

        public static void SetPendingUpdate()
        {
            if (SessionManager.currentUser == null)
            {
                Program.PerformUpdate();
            }
            else
            {
                Program.isPendingUpdate = true;
            }
        }

    }
}
