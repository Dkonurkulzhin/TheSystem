using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
namespace Networking
{
    public static class Constants
    {
        public enum Messages { Echo, RequestUpdate, RequestUserData, UserData};
        public static int UDPBroodcastPort = 9895;
        public static int ServerListenPort = 9896;
        public static int ClientListenPort = 9897;
        public static int LastTCPPort = 9900;
        public static Dictionary<Messages, string> RequestHeaders = new Dictionary<Messages, string>()
        {
            {Messages.Echo, "marco" },
            {Messages.RequestUpdate, "requpdate"},
            {Messages.RequestUserData, "requser" },
            {Messages.UserData, "userdata" }
        };
        public static string GetAddressFromEndPoint(EndPoint endPoint)
        {
            return endPoint.ToString().Split(':')[0];
        }
    }
}
