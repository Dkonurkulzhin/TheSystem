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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CopyFromSource(ClientSourcePathTB.Text, ClientTargetPathTB.Text, PathLocations.FilesToIgnore);
            CreateCleintZip();
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
                    if (PathLocations.FilesToIgnore != null && !PathLocations.FilesToIgnore.Contains(newPath))
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

        private void CreateCleintZip()
        {
            string zipFilePath = PathLocations.CleintZipDestinationPath + "Drone.zip";
            if (File.Exists(zipFilePath))
                File.Delete(zipFilePath);
            ZipFile.CreateFromDirectory(PathLocations.ClientFolderDestinationPath, zipFilePath);
        }

      
    }
}
