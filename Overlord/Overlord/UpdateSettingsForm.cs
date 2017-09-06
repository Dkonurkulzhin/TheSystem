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

namespace Overlord
{
    public partial class UpdateSettingsForm : Form
    {
        public string targetFolder;
        public UpdateSettingsForm()
        {
            InitializeComponent();
        }

        private void UpdateSettingsForm_Load(object sender, EventArgs e)
        {
            targetFolder = GlobalVars.Settings.UpdateFolder;
            UpdateElements();
        }

        private void UpdateElements()
        {
           
            label1.Text = FolderInfo(targetFolder);
            textBox1.Text = targetFolder;
        }

        private string FolderInfo(string path)
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(path);
                FileInfo[] fis = d.GetFiles(".", SearchOption.AllDirectories);
                long size = 0;
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
                return "Файлов в директории - " + fis.Length + ", общий объем - " + size.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openDialog = new FolderBrowserDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                targetFolder = openDialog.SelectedPath;
                UpdateElements();
                UpdateFolderSettings();
            }
        }

        private void UpdateFolderSettings()
        {
            GlobalVars.Settings.UpdateFolder = targetFolder;
            GlobalVars.SaveSettings();
        }
    }
}
