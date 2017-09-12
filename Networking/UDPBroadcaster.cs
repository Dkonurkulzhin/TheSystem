using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Net;

using NetworkCommsDotNet;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.Connections.UDP;

namespace Networking
{
    public class UDPBroadcaster
    {
        Timer udpTimer;
        private int Interval, Port;
        private string Header;
        public object Content = null;
        public UDPBroadcaster(int interval, int port)
        {
            Interval = interval;
            Port = port; 
        }

        public void StartBroadcasting(string header, object content)
        {
            Header = header;
            Content = content;
            udpTimer = new Timer(Interval);
            udpTimer.Elapsed += Tick;
            udpTimer.AutoReset = true;
            udpTimer.Start();

        }

        public void Stop()
        {
            if (udpTimer != null)
                udpTimer.Stop();
        }

        public void Restart()
        {
            if (udpTimer != null)
                udpTimer.Start();
        }

        private void Tick(Object sender, ElapsedEventArgs e)
        {
            UDPConnection.SendObject(Header, Content, new IPEndPoint(IPAddress.Broadcast, Port));
        }
    }

}
