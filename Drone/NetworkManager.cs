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
        public static MessageHandler messageHanlder = new MessageHandler();
        public static UDPBroadcaster broadcaster = new UDPBroadcaster(1000, Constants.UDPBroodcastPort);
        public delegate void UpdateEchoMessageEH();
       
        public static void InitNetwork()
        {
            messageHanlder.StartClientListening(GlobalVars.settings.serverIP);
            messageHanlder.NotifyUpdate += SetPendingUpdate;
            broadcaster.StartBroadcasting(Constants.RequestHeaders[Constants.Messages.Echo], new MachineStatMessage(
                GlobalVars.settings.pcNumber, false));
            
        }

        public static void UpdateEchoMessage()
        {
            broadcaster.Content = new MachineStatMessage(GlobalVars.settings.pcNumber,
                (SessionManager.currentUser == null) ? false : true);
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
                Program.LobbyForm.SetErrorText("Неправльный пользователь или пароль");
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
