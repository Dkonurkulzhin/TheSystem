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

        public UDPListener()
        {
            Start();
        }


        public void Start()
        {
            Connection.StartListening(ConnectionType.UDP, new IPEndPoint(IPAddress.Any, Constants.UDPBroodcastPort));
            NetworkComms.AppendGlobalConnectionCloseHandler(OnConnectionClose);
            AppendHandlers();
            Console.WriteLine("Starting udp listener");
            foreach (IPEndPoint listenEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.UDP))
            {
                Console.WriteLine(listenEndPoint.Address + ":" + listenEndPoint.Port);
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
            NetworkComms.AppendGlobalIncomingPacketHandler<int>(Constants.RequestHeaders[Constants.Messages.Echo],
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

        private void EchoHandler(PacketHeader header, Connection connection, int machine)
        {
            Console.WriteLine("Marco from Machine " + machine);
        }

        private string GetAddressFromEndPoint(EndPoint endPoint)
        {
            return endPoint.ToString().Split(':')[0];
        }

    }
}
