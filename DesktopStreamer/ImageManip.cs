using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace DesktopStreamer
{
    unsafe internal static class ImageManip
    {
        [DllImport(@"CudaLib.dll")]
        private static extern void complexCalcFast(int* a, int* b, int n);

        public static void Calc(int[] arrayA, int[] arrayB)
        {
            fixed (int* a = &arrayA[0], b = &arrayB[0])
            {
                complexCalcFast(a, b, arrayA.Length);
            }
        }
    }
}