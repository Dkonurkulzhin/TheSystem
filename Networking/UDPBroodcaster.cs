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
    public class UDPBroodcaster
    {
        Timer udpTimer;
        private int Interval, Port;
        private string Header, Content;
       
        public UDPBroodcaster(int interval, int port, string header, string content)
        {
            Interval = interval;
            Port = port;
            Header = header;
            Content = content;

            udpTimer = new Timer(Interval);
            udpTimer.Elapsed += Tick;
            udpTimer.AutoReset = true;
            udpTimer.Start();
        }

        public void Stop()
        {
            udpTimer.Stop();
        }

        public void Restart()
        {
            udpTimer.Start();
        }

        private void Tick(Object sender, ElapsedEventArgs e)
        {
            UDPConnection.SendObject(Header, Content, new IPEndPoint(IPAddress.Broadcast, Port));
        }
    }

}
