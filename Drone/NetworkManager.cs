﻿using System;
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

        public static void InitNetwork()
        {
            messageHanlder.StartClientListening(GlobalVars.settings.serverIP);
            broadcaster.StartBroadcasting(Constants.RequestHeaders[Constants.Messages.Echo], 32);
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
                Console.WriteLine("Invalid USER!!!");
                return;
            }
                
            User incommingUser = user as User;
            SessionManager.OpenSession(incommingUser);
        }

    }
}
