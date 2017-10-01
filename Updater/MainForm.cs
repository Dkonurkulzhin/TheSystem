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
using System.Net;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Timers;

using NetworkCommsDotNet;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;
using NetworkCommsDotNet.DPSBase.SevenZipLZMACompressor;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using Drone;
using Networking;


namespace Updater
{
   

    public partial class MainForm : Form
    {

        private UDPBroadcaster udpBroadcaster;
        private FileHandler fileHandler;

        public ClientSettings settings;
        private XMLManager xmlManager = new XMLManager();
        private Size AdvancedSize = new Size(420, 170);
        private Size StandartSize = new Size(420, 350);
        private bool AdvancedMode = false;
        private bool UpdateFinished = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitUI()
        {
            TopMost = true;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            LoadClientSettings();
            TCPPortConfiguration.ReserveTCPPorts();
            InitUI();
            udpBroadcaster = new UDPBroadcaster(10000, Constants.UDPBroodcastPort);
            fileHandler = new FileHandler();
            fileHandler.UpdateLog += AddLineToLog;
            fileHandler.UpdatePercent += UpdateSendProgress;
            fileHandler.UpdateStatus += UpdateStatus;
            fileHandler.ConnectionEstablished += udpBroadcaster.Stop;
            fileHandler.ReceivingCompleted += UpdateCompleted;
            udpBroadcaster.StartBroadcasting(Constants.RequestHeaders[Constants.Messages.RequestUpdate], fileHandler.StartListening());
            udpBroadcaster.OnBroadcastTick += AddLineToLog;
        }

        /// <summary>
        /// Sends requested file to the remoteIP and port set in GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateCompleted()
        {
            fileHandler.SaveAllRecievedFiles(GlobalVars.settings.applicationDirectory);
            UpdateStatus("Обновление завершено");
            UpdateFinished = true;
            System.Timers.Timer OnUpdateProcessFinished = new System.Timers.Timer(1000);
            OnUpdateProcessFinished.Start();
            OnUpdateProcessFinished.Elapsed += OnUpdateProcessFinishedTimer;
            

        }

        private void OnUpdateProcessFinishedTimer(object sender, ElapsedEventArgs e)
        {
            System.Timers.Timer timer = sender as System.Timers.Timer;
            timer.Stop();
            timer.Dispose();
            ExitUpdater();
            
        }

        private void ExitUpdater()
        { 
            Application.Exit();
            try
            {
                ProcessStartInfo info = new ProcessStartInfo(GlobalVars.settings.applicationDirectory + "drone.exe");
                info.UseShellExecute = true;
                info.Verb = "runas";
                Process.Start(info);
            }
            catch (Exception ex)
            {

            }
           
        }


        private void AddLineToLog(string line)
        {
            BeginInvoke(new Action(() =>
            {
                    listBox1.Items.Add(line);
            }));
        }
        
        private void UpdateSendProgress(double percentComplete)
        {
            BeginInvoke(new Action(() =>
            {
                //progressBar1.Value = (int)percentComplete;
            }));
        }

        
        private void UpdateStatus(string status)
        {
            BeginInvoke(new Action(() =>
            {
                label1.Text = status;
            }));
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create an OpenFileDialog so that we can request the file to send         
                //Disable the send and compression buttons
                //Parse the necessary remote information
                string remoteIP = textBox1.Text;
                string remotePort = textBox2.Text;

                SelectFilesToSend(remoteIP, Int32.Parse(remotePort));

        }

        private void SelectFilesToSend(string ip, int port)
        {
            FolderBrowserDialog openDialog = new FolderBrowserDialog();
            udpBroadcaster.Stop();
            //If a file was selected
            BeginInvoke(new Action(() =>
            {
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = openDialog.SelectedPath;
                    AddLineToLog("sending files from: " + path);

                    fileHandler.SendFiles(path + @"\", ip, port.ToString());
                }
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fileHandler.SaveAllRecievedFiles(@"D:\Progs\");
        }

        private void LoadClientSettings()
        {
            settings = xmlManager.DeserializeSettings();
            if (settings != null)
            {
                AddLineToLog("Настройки клиента загружены ");
                AddLineToLog("IP сервера: " + settings.serverIP);
                AddLineToLog("Директория клиентского приложения: " + settings.applicationDirectory);
                ToggleAdvancedMode(true);
            }
            else
            {
                MessageBox.Show("Не удалось загрузить файл конфига!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddLineToLog("Файл конфига не найден :(");
                ToggleAdvancedMode(false);
            }
        }

        private void ToggleAdvancedMode(bool toggle)
        {
            Size = (toggle) ? AdvancedSize : StandartSize;
            FormBorderStyle = (toggle) ? FormBorderStyle.None : FormBorderStyle.FixedSingle;
            AdvancedMode = toggle;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Escape)
            {
                ToggleAdvancedMode(!AdvancedMode);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AdvancedMode)
             e.Cancel = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExitUpdater();
        }
    }
}

