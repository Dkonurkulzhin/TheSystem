using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overlord
{
    public static class DebugManager
    {
        private static DebugLog Log = new DebugLog(10);
        public static bool LogEnabled = false;
        
        public static void Initialize()
        {
            Log.Show();
            LogEnabled = true;

        }

        public static void OpenLog()
        {
           if (LogEnabled) Log.Show();
           LogEnabled = true;
           
        }

        public static void DisableLog()
        {
            LogEnabled = false;
        }

        public static void HideLog()
        {
            if (LogEnabled) Log.Hide();
            LogEnabled = false;
        }

        public static void AddLine(string line)
        {
            if (LogEnabled)
                Log.Invoke(new Action(() => { Log.AddLineToLog(line);
                }));
        }

    }
}
