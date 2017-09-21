using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Drone
{
    public static class UIGraphical
    {
        public static ImageList CategoriesIcons = new ImageList();
        public static Image defaultImage;
        public static Image selected;
        

        public static void LoadUILists()
        {
            CategoriesIcons.ImageSize = new Size(70, 70);
            
            string path = GlobalVars.InterfaceResPath;
            defaultImage = Image.FromFile(path + "default.png");
            selected = Image.FromFile(path + "selected.png");
            foreach (string category in GlobalVars.settings.AppCategories)
            {
                string imagePath = path + category + @".png";
                if (File.Exists(imagePath))
                {
                    Image ic = ChangeSize(Image.FromFile(imagePath), 70, 70);
                    Console.WriteLine(ic.Size.ToString());
                    CategoriesIcons.Images.Add(category, ic);
                }
                else
                {
                    CategoriesIcons.Images.Add(category, defaultImage);
                }
                     
            }
        }

        public static Image ChangeSize(Image original, int newWidth, int newHeight)
        {
            Bitmap destination = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(destination);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(original, new Rectangle(0,0, destination.Width, destination.Height), 
                new Rectangle(0, 0, original.Width, original.Height), GraphicsUnit.Pixel);
            return destination;
        } 
    

    }
}
