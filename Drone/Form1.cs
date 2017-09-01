using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace Drone
{
    public partial class Form1 : Form
    {
        public UserForm UserStats;
        public CategoryForm categoryForm;
        public AppListForm appListForm;
      
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_CLIENTEDGE = 0x200;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWP_NOREDRAW = 0x0008;
        private const uint SWP_NOACTIVATE = 0x0010;
        private const uint SWP_FRAMECHANGED = 0x0020;
        private const uint SWP_SHOWWINDOW = 0x0040;
        private const uint SWP_HIDEWINDOW = 0x0080;
        private const uint SWP_NOCOPYBITS = 0x0100;
        private const uint SWP_NOOWNERZORDER = 0x0200;
        private const uint SWP_NOSENDCHANGING = 0x0400;



        public Form1()
        {
            InitializeComponent();
        }

        public AppForm[] AppItems = new AppForm[6];
      




        private void Init_Stuff()
        {
            bool isElevated;
         
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            
        }
        private void InitUI()
        {
            UserStats = new UserForm();
            UserStats.MdiParent = this;
            UserStats.Show();
            UIFunctions.SetElementLocation(UserStats, UIFunctions.Positions.Bottom);

            categoryForm = new CategoryForm(this);
            categoryForm.MdiParent = this;
            categoryForm.Show();
            UIFunctions.SetElementLocation(categoryForm, UIFunctions.Positions.Top);

            appListForm = new AppListForm();
            SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
            appListForm.MdiParent = this;
            appListForm.Show();
            UIFunctions.SetElementLocation(appListForm, UIFunctions.Positions.Centre, 0, -50);
            
            TopmostUI(true);
            FormManager.SetBevel(this, false);
        }
        
        public void ShowUI()
        {
            bool show = true;
            if (show)
            {
                UserStats.Show();
                categoryForm.Show();
                appListForm.Show();
            }
            else
            {
                UserStats.Hide();
                categoryForm.Hide();
                appListForm.Hide();
            }
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            Init_Stuff();
            //CenterToScreen();
            this.TopMost = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            AppManager.LoadLinkPathes();
            InitUI();
            
            //FileSystemAccessManager.SetDirRights("Dias",@"D:\Games", false);
            //RegistryManager.SetTaskManager(false);
            //FileSystemAccessManager.SetDirRights("Dias", @"D:\Games\Factorio", true);
        }

       
      

        private void button1_Click(object sender, EventArgs e)
        {
            
           
            Program.ShutDownApp();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            //for (int i = 0; i < 5; i++)
            //{
            //    AppItems[i] = new AppForm();
            //    AppItems[i].MdiParent = this;
            //    AppItems[i].Show();
            //    AppItems[i].Location = new Point(i * 250, 20);
            //}
            
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

           
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    e.Cancel = true;
                    break;
            }

            base.OnFormClosing(e);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void TopmostUI(bool show)
        {
            UserStats.TopMost = show;
            categoryForm.TopMost = show;
            appListForm.TopMost = show;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            TopmostUI(true);
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            TopmostUI(false);
        }
    }
}
