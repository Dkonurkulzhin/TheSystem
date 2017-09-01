using System;
using System.Collections.Generic;
using System.Text;

namespace Networking
{
    public static class Constants
    {
        public enum Messages { Echo, RequestUpdate, RequestUserData };
        public static int UDPBroodcastPort = 9895;
        public static Dictionary<Messages, string> RequestHeaders = new Dictionary<Messages, string>()
        {
            {Messages.Echo, "marco" },
            {Messages.RequestUpdate, "requpdate"},
            {Messages.RequestUserData, "requser" }
        };
    }
}
