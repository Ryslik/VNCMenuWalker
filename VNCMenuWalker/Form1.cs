using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace VNCMenuWalker
{
    public partial class Form1 : Form
    {
        private static Bitmap cursor = null;

        public Form1()
        {
            cursor = VNCMenuWalker.Properties.Resources.Cursor;
            cursor.MakeTransparent(Color.FromArgb(34, 177, 76));

            InitializeComponent();
        }


        /// <summary>
        /// hjghygy
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private static Bitmap ScreenShot(int width, int height)
        {
            Graphics gfxScreenshot;

            Bitmap screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            gfxScreenshot = Graphics.FromImage(screen);

            Size sizeCopy = new Size(width, height);
            gfxScreenshot.CopyFromScreen(Cursor.Position.X - (width / 2 - 2), Cursor.Position.Y - (height / 2 - 30), 0, 0, sizeCopy, CopyPixelOperation.SourceCopy);
            gfxScreenshot.DrawImage(cursor, width / 2 - 3, height / 2 - 31);

            return screen;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pictureBox1.Image = (Image)ScreenShot(this.Width, this.Height);
        }
    }
}
