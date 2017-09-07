using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

using NetworkCommsDotNet;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;
using NetworkCommsDotNet.DPSBase.SevenZipLZMACompressor;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using ProtoBuf;
using System.Timers;


namespace Networking
{
    public class MessageHandler
    {

        public string ServerIP;
        SendReceiveOptions customOptions = new SendReceiveOptions<ProtobufSerializer>();
        private ConnectionInfo remoteInfo;

        public delegate void UserEH(object user);
        public event UserEH UserRecieved;

       
        public delegate void TimeoutEH(string message);
        public event TimeoutEH ConnectionTimeOut;

        public Dictionary<Constants.Messages, NetworkComms.PacketHandlerCallBackDelegate<object>> ServerPacketHandlers;
    



        public void SendObject(object obj, string header, string ip, int port)
        {
            remoteInfo = new ConnectionInfo(ip, port);
            try
            {
                Connection connection = TCPConnection.GetConnection(remoteInfo);

                connection.SendObject(header, obj, customOptions);
                GC.Collect();
                connection.CloseConnection(false);
            }
            catch (Exception)
            {

            }
        }

        #region ServerMethods

        public bool StartServerListening(Dictionary<Constants.Messages, NetworkComms.PacketHandlerCallBackDelegate<object>> handlers)
        {
            try
            {

                Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, Constants.ServerListenPort));
                NetworkComms.AppendGlobalConnectionCloseHandler(OnServerConnectionClose);

                ServerPacketHandlers = handlers;
                foreach (Constants.Messages msg in handlers.Keys)
                {
                    NetworkComms.AppendGlobalIncomingPacketHandler<object>(Constants.RequestHeaders[msg], handlers[msg]);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public void OnServerConnectionClose(Connection conn)
        {
            conn.RemoveShutdownHandler(OnServerConnectionClose);
            StartServerListening(ServerPacketHandlers);

        }

        public void SendUser(object user, string ip)
        {
            SendObject(user, Constants.RequestHeaders[Constants.Messages.UserData], ip, Constants.ClientListenPort); 
        }
      

        #endregion


        #region ClientMethods
        public bool StartClientListening(string serverIP)
        {
            try
            {

                Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Parse(serverIP), Constants.ClientListenPort));
                ServerIP = serverIP;
                NetworkComms.AppendGlobalConnectionCloseHandler(OnCleintConnectionClose);
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void SendMessageToServer(string ip, Constants.Messages messageType, string message = "")
        {
            SendObject(message, Constants.RequestHeaders[messageType], ip, Constants.ServerListenPort);
        }

        public void OnCleintConnectionClose(Connection conn)
        {
            conn.RemoveShutdownHandler(OnCleintConnectionClose);
            StartClientListening(ServerIP);
        }

        public void SendLogInRequest(object user, string serverIP)
        {
            SendObject(user, Constants.RequestHeaders[Constants.Messages.RequestUserData], serverIP, Constants.ServerListenPort);
            NetworkComms.AppendGlobalIncomingPacketHandler<object>(Constants.RequestHeaders[Constants.Messages.UserData], GetUserOnClient);
            Timer timeout = new Timer(3000);
            timeout.Elapsed += UserRequestTimeOut;
            timeout.Start();
        }

        public void GetUserOnClient(PacketHeader header, Connection connection, object user)
        {
            UserRecieved?.Invoke(user);
            NetworkComms.RemoveGlobalIncomingPacketHandler<object>(Constants.RequestHeaders[Constants.Messages.UserData], GetUserOnClient);
        }

        public void UserRequestTimeOut(object sender, ElapsedEventArgs e)
        {
            NetworkComms.RemoveGlobalIncomingPacketHandler<object>(Constants.RequestHeaders[Constants.Messages.UserData], GetUserOnClient);
            (sender as Timer).Close();
            ConnectionTimeOut?.Invoke("Нет связи с сервером");
        }

        #endregion
    }
}
