using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;


using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using Networking;

namespace Overlord
{
    public static class ClientCommunicationManager
    {
        public static UDPListener udpListener;
        public static Dictionary<string, FileHandler> Transitions;

        public static MessageHandler messageHanler;
        public static int ClientListenPort = Constants.ClientListenPort;

        public static void Init()
        {
            udpListener = new UDPListener();
            Transitions = new Dictionary<string, FileHandler>();
            messageHanler = new MessageHandler();
            udpListener.SendUpdate += AddUpdateTransition;
            udpListener.GotEcho += MachineManager.GotEchoPacket;
            messageHanler.StartServerListening(SendUser);
        }

        public static void SendForceUpdate(Machine machine)
        {
            if (machine.IP != null && machine.IP != "")
                messageHanler.SendObject("update", Constants.RequestHeaders[Constants.Messages.ForceUpdate], 
                    machine.IP, ClientListenPort);
        }


        public static void SendUser(PacketHeader header, Connection connection, User user)
        {
            User incommingUser = user as User;
            UserManager.FindUserByName(incommingUser.name);

            Console.WriteLine("Sending user data to " + Constants.GetAddressFromEndPoint(connection.ConnectionInfo.RemoteEndPoint));
            messageHanler.SendUser(UserManager.FindUserByName(incommingUser.name), 
                Constants.GetAddressFromEndPoint(connection.ConnectionInfo.RemoteEndPoint));
        }

        public static void UpdateStatus(PacketHeader header, Connection connection, object user)
        {

        }

        public static void AddUpdateTransition(string ip, int port)
        {
            if (Transitions.Keys.Contains(ip))
                return;
            string path = GlobalVars.Settings.UpdateFolder;
            if (path != null && path != "")
            {
                FileHandler fileHandler = new FileHandler();
                fileHandler.TransitionCompleted += CloseTransition;
                fileHandler.SendFiles(GlobalVars.Settings.UpdateFolder, ip, port.ToString());

                Transitions.Add(ip, fileHandler);
            }
            else
                return;

        }

        public static void CloseTransition(string ip)
        {
            Transitions.Remove(ip);
            GC.Collect();
        }

    }
}
