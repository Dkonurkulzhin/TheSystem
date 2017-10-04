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
        public static List<string> FilesToIgnore = new List<string>() { ClientReleasePath + "settings.xml" };
        public static string ClientFolderDestinationPath = @"D:\Projects\SystemBuilds\SystemBuilds\Client\Drone\";
        public static string CleintZipDestinationPath = @"D:\Projects\SystemBuilds\SystemBuilds\Client\";
    }
}
