using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Networking;

namespace Overlord
{
    public static class ClientCommunicationManager
    {
        public static UDPListener udpListener;
        public static Dictionary<string, FileHandler> Transitions;

      

        public static void Init()
        {
            udpListener = new UDPListener();
            Transitions = new Dictionary<string, FileHandler>();
            udpListener.SendUpdate += AddUpdateTransition;
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
