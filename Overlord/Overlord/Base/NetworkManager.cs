using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Globalization;

using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using Networking;

namespace Overlord
{
    public static class ClientCommunicationManager
    {
        private static UDPListener udpListener;
        private static Dictionary<string, FileHandler> Transitions;

        private static MessageHandler messageHanler;
        private static int ClientListenPort = Constants.ClientListenPort;

        public static void Init()
        {
            udpListener = new UDPListener();
            Transitions = new Dictionary<string, FileHandler>();
            messageHanler = new MessageHandler();
            udpListener.SendUpdate += AddUpdateTransition;
            udpListener.GotEcho += MachineManager.GotEchoPacket;
            udpListener.Start();
            messageHanler.StartServerListening(SendUserOnRequest);
        }

        public static void SendForceUpdate(Machine machine)
        {
            if (machine.IP != null && machine.IP != "")
                messageHanler.SendObject("update", Constants.RequestHeaders[Constants.Messages.ForceUpdate], 
                    machine.IP, ClientListenPort);
        }

        public static void SendConfiguration(Machine machine)
        {
            if (machine.IP != null && machine.IP != "")
                messageHanler.SendConfiguration(new MachineConfiguration(machine.label, machine.priceMultiplier),
                    machine.IP);
        }


        public static void SendUserOnRequest(PacketHeader header, Connection connection, User user)
        {
            User incommingUser = user as User;
            incommingUser = UserManager.CheckUserData(incommingUser.name, incommingUser.password);
            if (incommingUser == null)
                incommingUser = new User();
            Console.WriteLine("Sending user data to " + Constants.GetAddressFromEndPoint(connection.ConnectionInfo.RemoteEndPoint) + 
                " " + incommingUser.name + ", " + incommingUser.password);
            SendUserObject(incommingUser,
                Constants.GetAddressFromEndPoint(connection.ConnectionInfo.RemoteEndPoint));
        }

        public static void SendUserObject(User user, string ip)
        {
            Console.WriteLine("Sending " + user.name + " to " + ip);
            messageHanler.SendUser(user, ip);
        }

        public static void SendWakeUpPacket(string MACaddress)
        {
            WakeFunction(MACaddress);
        }

        public static void UpdateStatus(PacketHeader header, Connection connection, object user)
        {

        }

        public static void SendForceLogOutCommand(Machine machine)
        {
            string ip = machine.IP;
            if (ip != null && ip != "")
                messageHanler.SendForceLogOut(ip);
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


        private static void WakeFunction(string MAC_ADDRESS)
        {
            WakeUPHandler client = new WakeUPHandler();
            client.Connect(new
               IPAddress(0xffffffff),  //255.255.255.255  i.e broadcast
               0x2fff); // port=12287 let's use this one 
            client.SetClientToBrodcastMode();
            //set sending bites
            int counter = 0;
            //buffer to be send
            byte[] bytes = new byte[1024];   // more than enough :-)
                                             //first 6 bytes should be 0xFF
            for (int y = 0; y < 6; y++)
                bytes[counter++] = 0xFF;
            //now repeate MAC 16 times
            for (int y = 0; y < 16; y++)
            {
                int i = 0;
                for (int z = 0; z < 6; z++)
                {
                    bytes[counter++] =
                        byte.Parse(MAC_ADDRESS.Substring(i, 2),
                        NumberStyles.HexNumber);
                    i += 2;
                }
            }

            //now send wake up packet
            int reterned_value = client.Send(bytes, 1024);


        }

    }
}
