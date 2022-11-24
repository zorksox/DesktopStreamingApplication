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
    }
}