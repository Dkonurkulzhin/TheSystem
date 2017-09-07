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
    public partial class CategoryForm : Form
    {
        private Form1 MainForm;
        private List<PictureBox> CatButtons = new List<PictureBox>();
        private List<string> categories;
        public static List<PictureBox> Pictures;
        public static List<Label> Labels;
        private AppListForm appList;

        public CategoryForm(Form1 ParentForm)
        {
            MainForm = ParentForm;
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            appList = MainForm.appListForm;
            Labels = new List<Label>(new Label[] { label1, label2, label3, label4});
            Pictures = new List<PictureBox>(new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4});
            categories = GlobalVars.settings.AppCategories;
            UIGraphical.LoadUILists();
            // this.Size = new Size(categories.Count*90 + 60, 90);
            for (int i = 0; i < categories.Count; i++)
            {
                if (i < Labels.Count)
                    Labels[i].Text = categories[i];
            }

        }

    
        private void ChangeCategory(object sender, EventArgs e)
        {
            Control control = GetChildAtPoint(new Point(Cursor.Position.X, Cursor.Position.Y));
            if (control != null)
            {
                MainForm.appListForm.ChangeCategory(control.Name);
                Console.WriteLine(control.Name);
                return;
            }
            Console.WriteLine("not found");
        }

      

        private void label1_Click(object sender, EventArgs e)
        {
            MainForm.appListForm.ChangeCategory(label1.Text);
            pictureBox1.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MainForm.appListForm.ChangeCategory(label2.Text);
            pictureBox2.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MainForm.appListForm.ChangeCategory(label3.Text);
            pictureBox3.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MainForm.appListForm.ChangeCategory(label4.Text);
            pictureBox4.Visible = true;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            //if (MainForm.appListForm.ActiveCategory != categories[0])
                pictureBox1.Visible = false;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
           // if (MainForm.appListForm.ActiveCategory != categories[1])
                pictureBox2.Visible = false;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
           // if (MainForm.appListForm.ActiveCategory != categories[2])
                pictureBox3.Visible = false;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
          //  if (MainForm.appListForm.ActiveCategory != categories[3])
                pictureBox4.Visible = false;
        }

        
    }
}
