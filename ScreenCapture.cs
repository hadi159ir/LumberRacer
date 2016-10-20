﻿using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ScreenShotDemo
{
    /// <summary>
    /// Provides functions to capture the entire screen, or a particular window, and save it to a file.
    /// </summary>
    public class ScreenCapture : IDisposable
    {
        public Graphics Graphics { get; private set; }

        public Image SeeHere(int width, int height)
        {
            var p = Cursor.Position;

            Bitmap bmp = new Bitmap(width,height);
            Graphics = Graphics.FromImage(bmp);
            var screen = Screen.FromPoint(Cursor.Position);
            Graphics.CopyFromScreen(p.X, p.Y, 0, 0, new Size(width, height));
            return bmp;
        }

        public void Dispose()
        {
            Graphics.Dispose();
        }
    }
}
