using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace Networking
{
    public static class TCPPortConfiguration
    {

        public static void ReserveTCPPorts()
        {
            string RegPath= "SYSTEM\\CurrentControlSet\\Services\\TCPIP\\Parameters";
            RegistryKey rKey1 = Registry.LocalMachine.CreateSubKey(RegPath);

            string[] ReservedPorts = {Constants.UDPBroodcastPort.ToString() + "-"
                 + Constants.LastTCPPort.ToString(), "", ""};

            rKey1.SetValue("ReservedPorts", ReservedPorts
                , RegistryValueKind.MultiString);
            rKey1.Close();
        }

    }
}
