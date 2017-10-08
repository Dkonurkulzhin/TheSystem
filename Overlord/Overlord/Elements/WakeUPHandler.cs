using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Overlord
{
    public class WakeUPHandler:UdpClient
    {
        public WakeUPHandler():base()
    { }
        //this is needed to send broadcast packet
        public void SetClientToBrodcastMode()
        {
            if (this.Active)
                this.Client.SetSocketOption(SocketOptionLevel.Socket,
                                          SocketOptionName.Broadcast, 0);
        }
    }
    //now use this class
    //MAC_ADDRESS should  look like '013FA049'
   
}
