using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DesktopStreamer
{
    internal class ScreenShot
    {
        private Bitmap Bitmap;
        private Bitmap SmallBitmap;
        private Rectangle Rectangle;
        private Graphics Graphics;

        public ScreenShot()
        {
            Initialize();
        }

    public ScreenShot(bool capture)
        {
            Initialize();
            if (capture) Capture();
        }

        private void Initialize()
        {
            Bitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
            SmallBitmap = new Bitmap(384, 216, PixelFormat.Format32bppArgb);
            Rectangle = new Rectangle(0, 0, 1920, 1080);
            Graphics = Graphics.FromImage(Bitmap);
        }

        public void Capture()
        {
            Graphics.CopyFromScreen(Rectangle.Location, Point.Empty, Rectangle.Size);
        }

        public Bitmap GetBitmap()
        {
            return Bitmap;
        }

        public Bitmap GetSmallBitmap()
        {
            return SmallBitmap;
        }

        unsafe public Bitmap GenerateSmallBitmap()
        {
            Capture();
            SmallBitmap.Dispose();
            SmallBitmap = new Bitmap(Bitmap, 384, 216);
            return SmallBitmap;
        }

        //returns an array of int32 with the format AAAAAAAA RRRRRRRR GGGGGGGG BBBBBBBB
        public int[] GetInts()
        {
            Rectangle rect = new Rectangle(0, 0, Bitmap.Width, Bitmap.Height);
            BitmapData bmpData = Bitmap.LockBits(rect, ImageLockMode.ReadWrite, Bitmap.PixelFormat);
            int bytes = Math.Abs(bmpData.Stride) * Bitmap.Height;
            int[] rgbValues = new int[bytes / 4];
            Marshal.Copy(bmpData.Scan0, rgbValues, 0, rgbValues.Length);
            Bitmap.UnlockBits(bmpData);
            return rgbValues;
        }

        //same as GetInts, but does not unlock the bits.
        public int[] GetIntsLocked(out IntPtr ptr, out BitmapData bmpData)
        {
            Rectangle rect = new Rectangle(0, 0, Bitmap.Width, Bitmap.Height);
            bmpData = Bitmap.LockBits(rect, ImageLockMode.ReadWrite, Bitmap.PixelFormat);
            ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * Bitmap.Height;
            int[] rgbValues = new int[bytes / 4];
            Marshal.Copy(ptr, rgbValues, 0, rgbValues.Length);
            return rgbValues;
        }
    }
}
