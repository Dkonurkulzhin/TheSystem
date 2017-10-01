using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using NetworkCommsDotNet;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.Connections.UDP;

namespace Networking
{
    public class UDPListener
    {
        public delegate void SendUpdateEH(string ip, int port);
        public event SendUpdateEH SendUpdate;
        private bool ListenerEnabled = false;
        public delegate void EchoEH(int machine, string machineIP, bool isOccupied, string username = "guest", long balance = 0, long minutesLeft = 0);
        public event EchoEH GotEcho;

        public UDPListener()
        {
           // Start();
        }
       
        
        public void Start()
        {
            if (!ListenerEnabled)
            {
                Connection.StartListening(ConnectionType.UDP, new IPEndPoint(IPAddress.Any, Constants.UDPBroodcastPort));
                NetworkComms.AppendGlobalConnectionCloseHandler(OnConnectionClose);
                AppendHandlers();
                Console.WriteLine("Starting udp listener");
                foreach (IPEndPoint listenEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.UDP))
                {
                    Console.WriteLine(listenEndPoint.Address + ":" + listenEndPoint.Port);
                }
                ListenerEnabled = true;
            }
        }


        public void OnConnectionClose(Connection conn)
        {
            Start();
        }

        private void AppendHandlers()
        {
            NetworkComms.AppendGlobalIncomingPacketHandler<List<int>>(Constants.RequestHeaders[Constants.Messages.RequestUpdate], 
                UpdateHandler);
            NetworkComms.AppendGlobalIncomingPacketHandler<MachineStatMessage>(Constants.RequestHeaders[Constants.Messages.Echo],
                EchoHandler);

        }

        private void UpdateHandler(PacketHeader header, Connection connection, List<int> ports)
        {
            foreach (int port in ports)
            {
                try
                {
                    if (!GetAddressFromEndPoint(connection.ConnectionInfo.RemoteEndPoint).Contains("127.0.0.1"))
                        SendUpdate?.Invoke(GetAddressFromEndPoint(connection.ConnectionInfo.RemoteEndPoint), port);
                  
                    return;
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void EchoHandler(PacketHeader header, Connection connection, MachineStatMessage machineMessage)
        {
            string ip = Constants.GetAddressFromEndPoint(connection.ConnectionInfo.RemoteEndPoint);

            if (ip != "127.0.0.1")
            {
                GotEcho?.Invoke(machineMessage.Index, ip, machineMessage.IsOccupied, machineMessage.Username, 
                    machineMessage.Balance, machineMessage.MinutesLeft);
                Console.WriteLine("Marco from Machine " + machineMessage.Index + ": " + ip);
            }
        }

        private string GetAddressFromEndPoint(EndPoint endPoint)
        {
            return endPoint.ToString().Split(':')[0];
        }

    }
}
