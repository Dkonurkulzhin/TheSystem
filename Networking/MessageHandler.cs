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

namespace Networking
{
    public class MessageHandler
    {

        SendReceiveOptions customOptions = new SendReceiveOptions<ProtobufSerializer>();
        private ConnectionInfo remoteInfo;

        public void SendMessage(string ip)
        {

        }

        public void SendObject(object obj, string header, string ip, int port)
        {
            remoteInfo = new ConnectionInfo(ip, port);

            Connection connection = TCPConnection.GetConnection(remoteInfo);

            connection.SendObject(header, obj, customOptions);
            GC.Collect();
            connection.CloseConnection(false);
        }
    }
}
