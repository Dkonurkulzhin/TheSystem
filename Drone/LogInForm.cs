﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drone
{
    public partial class LogInForm : Form
    {
        public AdminForm adminForm;
        private Color StandartForeColor = SystemColors.Menu;
        private Color ErrorColor = Color.Red;

        public LogInForm()
        {
            InitializeComponent();
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

            this.TopMost = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            SetUpUIPos();
           
        }

        private void SetUpUIPos()
        {
            UIFunctions.SetElementLocation(panel1, UIFunctions.Positions.Centre, 0, 400);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = UsernameInput.Text;
            string password = PasswordInput.Text;
            
            if (username == "")
            {
                UsernameLabel.ForeColor = ErrorColor;
                return;
            }
            UsernameLabel.ForeColor = StandartForeColor;
            if (password == "")
            {
                PasswordLabel.ForeColor = ErrorColor;
                return;
            }   
            PasswordLabel.ForeColor = StandartForeColor;

            NetworkManager.sendLoginRequest(new User(username, password));
            
            UsernameInput.Text = "";
            PasswordInput.Text = "";

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

        private void LogInForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Escape)
            {
                if (adminForm != null)
                    adminForm.Close();
                adminForm = new AdminForm();
                adminForm.TopMost = true;
                adminForm.Show();
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Escape && GlobalVars.debug)
            {
                Program.ShutDownApp();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
