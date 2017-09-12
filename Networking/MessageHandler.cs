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

        public delegate void UserEH(User user);
        public event UserEH UserRecieved;

        public delegate void UpdateEH();
        public event UpdateEH StartUpdate;

       
        public delegate void TimeoutEH(string message);
        public event TimeoutEH ConnectionTimeOut;

        public NetworkComms.PacketHandlerCallBackDelegate<User> UserRequestHandler;


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

        public void SendUserObject(User user, string header, string ip, int port)
        {
            remoteInfo = new ConnectionInfo(ip, port);
            try
            {
                Connection connection = TCPConnection.GetConnection(remoteInfo);

                connection.SendObject(header, user, customOptions);
               
            }
            catch (Exception)
            {

            }
        }


        #region ServerMethods

        public bool StartServerListening(NetworkComms.PacketHandlerCallBackDelegate<User> userRequesthandler)
        {
            try
            {

                Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, Constants.ServerListenPort));
                NetworkComms.AppendGlobalConnectionCloseHandler(OnServerConnectionClose);

                UserRequestHandler = userRequesthandler;
                
                NetworkComms.AppendGlobalIncomingPacketHandler<User>(Constants.RequestHeaders[Constants.Messages.RequestUserData],
                    userRequesthandler);
                
                
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
            StartServerListening(UserRequestHandler);

        }

        public void SendUser(User user, string ip)
        {
            SendUserObject(user, Constants.RequestHeaders[Constants.Messages.UserData], ip, Constants.ClientListenPort); 
        }

        public void SendForceUpdate(string ip)
        {
            SendObject("update", Constants.RequestHeaders[Constants.Messages.ForceUpdate], ip, Constants.ClientListenPort);
        }
      

        #endregion


        #region ClientMethods
        public bool StartClientListening(string serverIP)
        {
            try
            {

                Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Parse(serverIP), Constants.ClientListenPort));
                ServerIP = serverIP;
                NetworkComms.AppendGlobalIncomingPacketHandler<string>(Constants.RequestHeaders[Constants.Messages.ForceUpdate], GetUpdateMessage);
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

        public void SendLogInRequest(User user, string serverIP)
        {
            SendUserObject(user, Constants.RequestHeaders[Constants.Messages.RequestUserData], serverIP, Constants.ServerListenPort);
            NetworkComms.AppendGlobalIncomingPacketHandler<User>(Constants.RequestHeaders[Constants.Messages.UserData], GetUserOnClient);
            Timer timeout = new Timer(3000);
            timeout.Elapsed += UserRequestTimeOut;
            timeout.Start();
        }

        public void GetUserOnClient(PacketHeader header, Connection connection, User user)
        {
            UserRecieved?.Invoke(user);
            NetworkComms.RemoveGlobalIncomingPacketHandler<User>(Constants.RequestHeaders[Constants.Messages.UserData], GetUserOnClient);
        }

        public void UserRequestTimeOut(object sender, ElapsedEventArgs e)
        {
            NetworkComms.RemoveGlobalIncomingPacketHandler<User>(Constants.RequestHeaders[Constants.Messages.UserData], GetUserOnClient);
            (sender as Timer).Close();
            ConnectionTimeOut?.Invoke("Нет связи с сервером");
        }

        public void GetUpdateMessage(PacketHeader header, Connection connection, string message)
        {
            StartUpdate?.Invoke();
        }

        #endregion
    }
}
