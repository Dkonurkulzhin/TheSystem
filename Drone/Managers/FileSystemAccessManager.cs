using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;
using System.IO;
using System.Threading;
    
namespace Drone
{
    static class FileSystemAccessManager
    {
        // Получение, установка прав для файловой системы 
        // Для клиента
        // зависимости: нет
        static public string username = "Dias";
        static public string[] DirExceptions = new string[] {@"D:\\Work", @"C:\\Users", @"C:\\Windows", @"D:\\Projects"};
        static public volatile bool Authority = false;

        public static string SystemUserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        public static bool SetDirRights(string username, string Directory, bool Authority)
        {
            AccessControlType ControlType;
            bool Result;
            if (Authority)
                ControlType = AccessControlType.Allow;
            else
                ControlType = AccessControlType.Deny;
            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(Directory);
                DirectorySecurity dSecurity = dInfo.GetAccessControl();
                 dSecurity.ModifyAccessRule(AccessControlModification.Reset, new FileSystemAccessRule(username, FileSystemRights.Write, InheritanceFlags.ObjectInherit, PropagationFlags.None, ControlType), out Result);
                if (!Result) return false;
                 dSecurity.ModifyAccessRule(AccessControlModification.Reset, new FileSystemAccessRule(username, FileSystemRights.Traverse, InheritanceFlags.ObjectInherit, PropagationFlags.None, ControlType), out Result);
                if (!Result) return false;
                // dSecurity.ModifyAccessRule(AccessControlModification.Reset, new FileSystemAccessRule(username, FileSystemRights.ListDirectory, InheritanceFlags.ObjectInherit, PropagationFlags.None, ControlType), out Result);

                dInfo.SetAccessControl(dSecurity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }                                                     
        }

        public static bool ApplyFilesystemPremissions(string username, string[] DirExceptions, bool Authority)
        {
            Worker workerobject = new Worker();
            Thread FileThread = new Thread(workerobject.DoStuff);
            FileThread.Start();
            Thread.Sleep(1);
            return true;
        }

        public class Worker
        {
            public void DoStuff()
            {
                
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in allDrives)
                {
                    if (drive.IsReady)
                        foreach (string dir in Directory.GetDirectories(drive.Name))
                            if (Directory.Exists(dir))
                                foreach (string ex in DirExceptions)
                                    if (dir != ex)
                                    {
                                        Console.WriteLine("Applying rights to directory: "+dir +" "+ SetDirRights(username, dir, Authority).ToString());
                                        if (GlobalVars.StopApplyingRights) break;
                                    }
                }
            }
        }

    }
}


//public static bool SetAcl(string Directory, bool Authority)
//{
//    FileSystemRights Rights = (FileSystemRights)0;
//    Rights = FileSystemRights.Write;
//    AccessControlType Status = new AccessControlType();
//    if (Authority) Status = AccessControlType.Allow;
//    else Status = AccessControlType.Deny;
//    // *** Add Access Rule to the actual directory itself
//    FileSystemAccessRule AccessRule = new FileSystemAccessRule("Dias", Rights,
//                                InheritanceFlags.ObjectInherit,
//                                PropagationFlags.None,
//                                Status);

//    DirectoryInfo Info = new DirectoryInfo(Directory);
//    DirectorySecurity Security = Info.GetAccessControl(AccessControlSections.Access);

//    bool Result = false;
//    Security.ModifyAccessRule(AccessControlModification.Set, AccessRule, out Result);

//    if (!Result)
//        return false;

//    // *** Always allow objects to inherit on a directory
//    InheritanceFlags iFlags = InheritanceFlags.ObjectInherit;
//    iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;

//    // *** Add Access rule for the inheritance
//    AccessRule = new FileSystemAccessRule("Dias", Rights,
//                                iFlags,
//                                PropagationFlags.None,
//                                Status);
//    Result = false;
//    Security.ModifyAccessRule(AccessControlModification.Add, AccessRule, out Result);

//    if (!Result)
//        return false;

//    Info.SetAccessControl(Security);

//    return true;
//}