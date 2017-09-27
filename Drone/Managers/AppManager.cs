using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.IO;
using System.Drawing;

namespace Drone
{
    static class AppManager
    {
      
        static XMLManager XMLmng = new XMLManager();
        static AppUnit[] AppList = { };
        static public List<AppUnit> Apps = new List<AppUnit>();
        

        static public void Initialize()
        {
            LoadLinkPathes();
        }

        static public string ReadLinkPath(string linkPath)
        {
            string linkPathName = linkPath; // Change this to the shortcut path

            if (System.IO.File.Exists(linkPathName))
            {
                // WshShellClass shell = new WshShellClass();
                WshShell shell = new WshShell(); //Create a new WshShell Interface
                IWshShortcut link = (IWshShortcut)shell.CreateShortcut(linkPathName); //Link the interface to our shortcut

                return link.TargetPath; //Show the target in a MessageBox using IWshShortcut

            }
            else
                return null;
        }
        static public string ReadLinkName(string linkPath)
        {
            string linkPathName = linkPath; // Change this to the shortcut path

            if (System.IO.File.Exists(linkPathName))
            {
                // WshShellClass shell = new WshShellClass();
                WshShell shell = new WshShell(); //Create a new WshShell Interface
                IWshShortcut link = (IWshShortcut)shell.CreateShortcut(linkPathName); //Link the interface to our shortcut

                return link.Description; //Show the target in a MessageBox using IWshShortcut

            }
            else
                return null;
        }

        static public void LoadLinkPathes()
        {
            Apps.Clear();
            foreach (string category in GlobalVars.settings.AppCategories)
            {
                foreach (string file in Directory.GetFiles(GlobalVars.LinkDirectory + category))
                {
                    if (file.Contains(".lnk"))
                    {
                        string appPath = ReadLinkPath(file);
                        if (System.IO.File.Exists(appPath))
                        {
                            AppUnit app = new AppUnit();
                            app.AppName = Path.GetFileName(file).Split('.').First();
                            app.AppPath = ReadLinkPath(file);
                            app.Category = category;
                            string appPicPath = GlobalVars.LinkDirectory + category + @"\" + app.AppName + ".png";
                            Console.WriteLine("app picture: " + appPicPath);
                            if (System.IO.File.Exists(appPicPath))
                                try
                                {
                                    app.Picture = Image.FromFile(appPicPath);
                                }
                                catch (Exception e)
                                {
                                    Icon icon;
                                    icon = Icon.ExtractAssociatedIcon(app.AppPath);
                                    app.Picture = icon.ToBitmap();
                                }
                            else
                            {
                                Icon icon;
                                icon = Icon.ExtractAssociatedIcon(app.AppPath);
                                app.Picture = icon.ToBitmap();
                            }
                            Apps.Add(app);
                            Console.WriteLine("file found: " + app.AppName);
                        }
                    }
                }
            }

        }

        static public AppUnit LoadAppData(int AppID, bool LoadLocal = false)
        {
            AppUnit App = new AppUnit();
            try
            {
                App = XMLmng.DeserializeAppData(AppID);
            }
            catch (Exception e)
            {
                return null;
            }
            return App;
        }

        static public string SaveAppData(AppUnit App, string AppName, int AppID = 0, bool LoadLocal = false)
        {
            try
            {
                XMLmng.SerializeAppData(App, AppName);
                
            }
            catch (Exception e)
            {
                return e.ToString();
                 
            }
            return "OK";
        }

        

        static public void SaveApps()
        {
            foreach (AppUnit app in Apps)
            {
                SaveAppData(app, app.AppName);
            }
        }

    }
}
