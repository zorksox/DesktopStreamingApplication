using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DesktopStreamer
{
    internal static class Extensions
    {
        //returns an array of int32 with the format AAAAAAAA RRRRRRRR GGGGGGGG BBBBBBBB
        public static int[] GetInts(this Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            int[] rgbValues = new int[bytes / 4];
            Marshal.Copy(bmpData.Scan0, rgbValues, 0, rgbValues.Length);
            bmp.UnlockBits(bmpData);
            return rgbValues;
        }

        //same as GetInts, but does not unlock the bits.
        public static int[] GetIntsLocked(this Bitmap bmp, out IntPtr ptr, out BitmapData bmpData)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            int[] rgbValues = new int[bytes / 4];
            Marshal.Copy(ptr, rgbValues, 0, rgbValues.Length);
            //bmp.UnlockBits(bmpData);
            return rgbValues;
        }

        //returns an array of int16 with the format U RRRRR GGGGG BBBBB
        public static short[] GetShorts(this Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            short[] rgbValues = new short[bytes / 2];
            Marshal.Copy(ptr, rgbValues, 0, bytes / 2);
            bmp.UnlockBits(bmpData);
            return rgbValues;
        }
    }
}
