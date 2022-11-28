using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace DesktopStreamer
{
    unsafe internal static class ImageManip
    {
        [DllImport(@"CudaLib.dll")]
        private static extern void computeDifference(int* a, int* b, int n);

        [DllImport(@"CudaLib.dll")]
        private static extern void computeDifference2(int* a, int* b, int* c, int n);

        [DllImport(@"CudaLib.dll")]
        private static extern void computeDifferenceBytes(int* a, int* b, int* c, int n);

        public static void Calc(int[] arrayA, int[] arrayB)
        {
            fixed (int* a = &arrayA[0], b = &arrayB[0])
            {
                computeDifference(a, b, arrayA.Length);
            }
        }

        public static void Calc(int[] arrayA, int[] arrayB, int[] arrayC)
        {
            fixed (int* a = &arrayA[0], b = &arrayB[0], c = &arrayC[0])
            {
                computeDifference2(a, b, c, arrayA.Length);
            }
        }

        public static void CalcBytes(int[] arrayA, int[] arrayB, int[] arrayC)
        {
            fixed (int* a = &arrayA[0], b = &arrayB[0], c = &arrayC[0])
            {
                computeDifferenceBytes(a, b, c, arrayA.Length);
            }
        }

        public static Bitmap GetDifference(this Bitmap bmp1, Bitmap bmp2)
        {
            int[] arrayA = bmp1.GetInts();

            int[] arrayB = bmp2.GetInts();
            Bitmap bmp3 = new Bitmap(bmp1.Width, bmp1.Height, PixelFormat.Format32bppArgb);

            IntPtr ptr;
            BitmapData bmpData;
            int[] arrayC = bmp3.GetIntsLocked(out ptr, out bmpData);

            fixed (int* a = arrayA, b = arrayB, c = arrayC)
            {
                computeDifferenceBytes(a, b, c, arrayA.Length);

            }

            Marshal.Copy(arrayC, 0, ptr, arrayC.Length);
            bmp3.UnlockBits(bmpData);

            return bmp3;
        }
    }
}