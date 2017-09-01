using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Drone
{
    class XMLManager
    {
        // Логика сериализации и десереализации объектова в и из XML
       
        private string AppDataPath = GlobalVars.AppDataName;
        private string Xmldot = ".xml";


        public void SerializeAppData(AppUnit App, string appname)
        {
            XmlSerializer AppXS = new XmlSerializer(typeof(AppUnit));
            string CurrentAppDataPath = AppDataPath + appname + Xmldot;
            if (!File.Exists(@CurrentAppDataPath))
            {
                var newFile = File.Create(CurrentAppDataPath);
                newFile.Close();
            }
            TextWriter AppTW = new StreamWriter(@CurrentAppDataPath);
            AppXS.Serialize(AppTW, App);
        }

        public AppUnit DeserializeAppData(int AppID)
        {
            XmlSerializer AppXS = new XmlSerializer(typeof(AppUnit));
            string CurrentAppDataPath = AppDataPath + AppID.ToString() + Xmldot;
            try
            {
                using (var AppSR = new StreamReader(@CurrentAppDataPath))
                {
                    AppUnit App = (AppUnit)AppXS.Deserialize(AppSR);
                    return (App);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public void SerializeSettings(ClientSettings settings)
        {
            XmlSerializer SettingsXS = new XmlSerializer(typeof(ClientSettings));
            string CurrentSettingsPath = GlobalVars.SettingsPath + "settings" + Xmldot;
            if (!File.Exists(@CurrentSettingsPath))
            {
                var newFile = File.Create(CurrentSettingsPath);
                newFile.Close();
            }
            TextWriter SettingsTW = new StreamWriter(@CurrentSettingsPath);
            SettingsXS.Serialize(SettingsTW, settings);
            SettingsTW.Close();
            string updaterSettingsPath = GlobalVars.UpdaterDirectory + "settings" + Xmldot;
            if (File.Exists(@updaterSettingsPath))
            {
                File.Delete(updaterSettingsPath);
            }
            File.Copy(CurrentSettingsPath, updaterSettingsPath);
        }

        public ClientSettings DeserializeSettings()
        {
            XmlSerializer SettingsXS = new XmlSerializer(typeof(ClientSettings));
            string CurrentSettingsPath = GlobalVars.SettingsPath + "settings" + Xmldot;
            try
            {
                using (var SettingsSR = new StreamReader(@CurrentSettingsPath))
                {
                    ClientSettings settings = (ClientSettings)SettingsXS.Deserialize(SettingsSR);
                    return (settings);
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
