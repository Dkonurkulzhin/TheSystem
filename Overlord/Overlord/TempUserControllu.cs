using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;


namespace Overlord
{
    class TempUserControllu
    {
        string Xmldot = ".xml";
        DirectoryInfo d = new DirectoryInfo(@GlobalVars.TempUserPath);

        private void SerializeUser(User user)
        {
            XmlSerializer userXS = new XmlSerializer(typeof(User));
            string CurrentDataPath = GlobalVars.TempUserPath + user.name + Xmldot;

            if (!File.Exists(@CurrentDataPath))
            {
                var newFile = File.Create(CurrentDataPath);
                newFile.Close();

            }
            TextWriter userTW = new StreamWriter(@CurrentDataPath);
            userXS.Serialize(userTW, user); 
            userTW.Close();
        }

        public void SaveUser(User user)
        {
            SerializeUser(user);
        }

        public void createTestFiles(int count)
        { 

         for (int i = 0; i < count; i++)
            {
                User user = new User();
                user.name = "user" + i.ToString();
                user.balance = 100;
                user.personalName = "Ivan";
                SerializeUser(user);
            }
        }

        public List<User> LoadUserFiles()
        {
            List<User> users = new List<User>();
            
            foreach(var file in d.GetFiles("*.xml"))
            {
                users.Add(DeserializeUser(file.Name.Substring(0, file.Name.Length - 4)));
            }
            return users;
        }

        public User LoadUser(string name)
        {
            return DeserializeUser(name);
        }

        public User DeserializeUser(string name)
        {
            XmlSerializer userXS = new XmlSerializer(typeof(User));
            string CurrentDataPath = GlobalVars.TempUserPath + name + Xmldot;
            if (!File.Exists(@CurrentDataPath))
            {
                return null;
            }
            try
            {
                using (var userSR = new StreamReader(@CurrentDataPath))
                {
                    User user = (User)userXS.Deserialize(userSR);
                    userSR.Close();
                    return (user);

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        public List<string> ListUsers(string filtername = "")
        {
            List<string> users = new List<string>();
            foreach (var file in d.GetFiles(filtername + "*.xml"))
                users.Add(file.Name.Substring(0, file.Name.Length - 4));

            return users;
        }

        public bool DeleteUser(string name)
        {
            string CurrentDataPath = GlobalVars.TempUserPath + name + Xmldot;
            if (File.Exists(@CurrentDataPath))
            {
                File.Delete(@CurrentDataPath);
              
                return true;

            }
            else
            {
               
                return false;
            }
        }
    }
}
// for (var file in d.GetFiles("*.xml"))