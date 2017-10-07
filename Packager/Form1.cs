using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;




namespace Packager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClientSourcePathTB.Text = PathLocations.ClientReleasePath;
            ClientTargetPathTB.Text = PathLocations.ClientFolderDestinationPath;

            ServerSourcePathTB.Text = PathLocations.ServerReleasePath;
            ServerTargetPathTB.Text = PathLocations.ServerFolderDestinationPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CopyFromSource(ClientSourcePathTB.Text, ClientTargetPathTB.Text, PathLocations.ClientFilesToIgnore);
            CreateZip(PathLocations.CleintZipDestinationPath + "Drone.zip", ClientTargetPathTB.Text);
            MessageBox.Show("Копирование успешно!");
            StatLabel.Text = "";
        }

        private void CopyFromSource(string sourceDirectory, string targetDirectory, List<string> exceptions = null)
        {
            try
            {
                foreach (string dirPath in Directory.GetDirectories(sourceDirectory, "*", SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(sourceDirectory, targetDirectory));

                foreach (string newPath in Directory.GetFiles(sourceDirectory, "*.*", SearchOption.AllDirectories))
                {
                    if (exceptions != null && !exceptions.Contains(newPath))
                    {
                        File.Copy(newPath, newPath.Replace(sourceDirectory, targetDirectory), true);
                        StatLabel.Text = "Копирование: " + newPath + " в " + newPath.Replace(sourceDirectory, targetDirectory);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        

        private void CreateZip(string zipFilePath, string targetPath)
        { 
            if (File.Exists(zipFilePath))
                File.Delete(zipFilePath);
            ZipFile.CreateFromDirectory(targetPath, zipFilePath);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CopyFromSource(ServerSourcePathTB.Text, ServerTargetPathTB.Text, PathLocations.ServerFilesToIgnore);
            CreateZip(PathLocations.ServerZipDestinationPath + "Overlord.zip", ServerTargetPathTB.Text);
            MessageBox.Show("Копирование успешно!");
            StatLabel.Text = "";
        }
    }
}
