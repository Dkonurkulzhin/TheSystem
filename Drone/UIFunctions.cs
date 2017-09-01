using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Drone
{
    public static class UIFunctions
    {
        public enum Positions { Centre, Bottom, Top, Right, Left };

        private static Point GetCentreScreen(int objWidth, int objHeight, int xOffset = 0, int yOffset = 0)
        {
            return new Point(GlobalVars.ScreenWidth / 2 - objWidth / 2 + xOffset,
                GlobalVars.ScreenHeight / 2 - objHeight/2 + yOffset);
        }

        private static Point GetBottomScreen(int objWidth, int objHeight, int xOffset = 0, int yOffset = 0)
        {
            return new Point(GlobalVars.ScreenWidth / 2 - objWidth / 2 + xOffset,
                GlobalVars.ScreenHeight - objHeight - yOffset);
        }

        private static Point GetTopScreen(int objWidth, int objHeight, int xOffset = 0, int yOffset = 0)
        {
            return new Point(GlobalVars.ScreenWidth / 2 - objWidth / 2 + xOffset,
                0 + yOffset);
        }


        public static void SetElementLocation(Control element, Positions position, int xOffset = 0, int yOffset = 0)
        {
            switch (position)
            {
                case Positions.Centre:
                    element.Location = GetCentreScreen(element.Width, element.Height, xOffset, yOffset);
                    break;
                case Positions.Bottom:
                    element.Location = GetBottomScreen(element.Width, element.Height, xOffset, yOffset);
                    break;
                case Positions.Top:
                    element.Location = GetTopScreen(element.Width, element.Height, xOffset, yOffset);
                    break;
                default:
                    break;
            }

        }

        public static void SetBackgroundImage(Control element, string wpPath)
        {
            try
            {
                element.BackgroundImage = Image.FromFile(wpPath);
            }
            catch
            {

            }
        }
       
        public static Image GetImageByKey(ImageList imglst, string key)
        {
            
            return null;
        }

        public static string FormatTime(int seconds)
        {
            return string.Format("{0:00}:{1:00}:{2:00}", seconds / 3600, (seconds / 60) % 60, seconds % 60);

        }

        public static Point ListPostion(int index, Size elemSize, Form form, int Xindent = 15, int Yindent = 15)
        {

            int elemTotalWidth = elemSize.Width + Xindent;
            int elemTotalHeight = elemSize.Height + Yindent;
            int maxXcount = form.Size.Width / elemTotalWidth;
            int row = index / maxXcount;
            int column = index - maxXcount * (row);
            return new Point(Xindent + column * elemTotalWidth, 15 + row * (elemSize.Height + Yindent));
        }
    }
}
