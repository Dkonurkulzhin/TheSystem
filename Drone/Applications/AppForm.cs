using System;
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
    public partial class AppForm : Form
    {
        
        public string AppPath = "calc.exe";
        public string CommandLine;
        private Size BaseSize = new Size(); 
        public AppUnit AppItem;

        public AppForm(AppUnit app)
        {
            InitializeComponent();
            AppItem = app;  
        }

        private void AppForm_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.White;
            //this.TransparencyKey = Color.White;
           
            label1.Text = AppItem.AppName;
            BaseSize = this.Size;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void AppForm_MouseEnter(object sender, EventArgs e)
        {
            Opacity = 0;
            this.BackColor = Color.DarkGray;
          //  this.Size = new Size(BaseSize.Width + 10, BaseSize.Height + 5);
           
        }

        private void AppForm_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = 0.2;
            this.BackColor = Color.Wheat;
         //   this.Size = BaseSize;
        }
    }
}
