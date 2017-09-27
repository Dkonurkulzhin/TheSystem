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
    public partial class AppListForm : Form
    {

        public List<AppUnit> ShownApps = new List<AppUnit>();
        public List<AppForm> AppList = new List<AppForm>();
        public List<PictureBox> AppLinks = new List<PictureBox>();
        private List<Label> AppLabels = new List<Label>();

        public string ActiveCategory = GlobalVars.settings.AppCategories.First();

        public AppListForm()
        {
            InitializeComponent();
            FormManager.SetBevel(this, false);
        }

        private void AppListForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            
            //this.BackColor = Color.Lime;
            this.ForeColor = Color.Lime;
            this.TransparencyKey = Color.Lime;
            
            LoadApplicationList();
        }

        private void LoadApplicationList()
        {
            
            ShownApps.Clear();
            foreach (AppUnit app in UIManager.GetAllApplications())
            {
                if (app.Category == ActiveCategory)
                {
                    ShownApps.Add(app);
                }
            }
            ShowApplications();
            string apps = "";
            foreach (string cat in UIManager.AppCategories)
            {
                apps += cat;
            } 
            Console.WriteLine("app categories: " + apps);

        }
        private bool ApplicationsHasPictures(List<AppUnit> apps)
        {
            foreach (AppUnit app in apps)
            {
                if (app.Picture.Size.Width > 32)
                    return true;
            }
            return false;
        }

        public void ShowApplications(int pictureSize = 32, int indent = 64)
        {
            int i = 0;
            foreach (PictureBox app in AppLinks)
            {
                app.Dispose();
            }
            AppLinks.Clear();
            foreach (Label label in AppLabels)
            {
                label.Dispose();
            }
            AppLabels.Clear();

            Size LinkSize = ApplicationsHasPictures(ShownApps) ? new Size(100, 150) : new Size(32, 32);

            foreach (AppUnit app in ShownApps)
            {
                addAppLink(app, i, LinkSize);
                i++;
            }
        }

        private void addAppLink(AppUnit app, int index, Size pictureSize, int indent = 64)
        {
            PictureBox appPic = new PictureBox();
            
            
            appPic.BackgroundImage = app.Picture;
            if (app.Picture.Size.Width > 32)
            {
                appPic.BackgroundImageLayout = ImageLayout.Stretch;
               
            }
            else
                appPic.BackgroundImageLayout = ImageLayout.Center;
            appPic.Size = pictureSize;
          
            appPic.Name = app.AppName;
            appPic.Location = UIFunctions.ListPostion(index, pictureSize, this, indent, indent + 16);
            appPic.Cursor = Cursors.Hand;
            appPic.Click += new EventHandler((sender, e) => RunApp(sender, e, app));
            
            AppLinks.Add(appPic);
            this.Controls.Add(appPic);

            Label appLabel = new Label();
            appLabel.TextAlign = ContentAlignment.MiddleCenter;
            appLabel.AutoSize = true;
            appLabel.MaximumSize = new Size(pictureSize.Width + indent / 2, 0);
            appLabel.Text = app.AppName;
            appLabel.Location = new Point(appPic.Location.X + (pictureSize.Width - appLabel.Size.Width) / 2, appPic.Location.Y + pictureSize.Height + 4);
            appLabel.Click += new EventHandler((sender, e) => RunApp(sender, e, app));
            AppLabels.Add(appLabel);
            Controls.Add(appLabel);
        }

       
            

        private void RunApp(Object sender, EventArgs e, AppUnit app)
        {
            UIManager.LaunchApplication(app);
            Console.WriteLine(app.AppName);
        }

        public void ChangeCategory(string newCategory)
        {
            ActiveCategory = newCategory;
            LoadApplicationList();
        }
    }
}
