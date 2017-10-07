using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packager
{
    public static class PathLocations
    {
        public static string ClientReleasePath = @"D:\Projects\System\TheSystem\Drone\bin\Release\";
        public static List<string> ClientFilesToIgnore = new List<string>() { ClientReleasePath + "settings.xml" };
        public static string ClientFolderDestinationPath = @"D:\Projects\SystemBuilds\SystemBuilds\Client\Drone\";
        public static string CleintZipDestinationPath = @"D:\Projects\SystemBuilds\SystemBuilds\Client\";

        public static string ServerReleasePath = @"D:\Projects\System\TheSystem\Overlord\Overlord\bin\Release\";
        public static List<string> ServerFilesToIgnore = new List<string>() { ServerReleasePath + "data" };
        public static string ServerFolderDestinationPath = @"D:\Projects\SystemBuilds\SystemBuilds\Server\Overlord\";
        public static string ServerZipDestinationPath = @"D:\Projects\SystemBuilds\SystemBuilds\Server\";
    }
}
