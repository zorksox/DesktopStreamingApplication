using System;
using System.Runtime.InteropServices;

namespace DesktopStreamer
{
    unsafe internal static class ImageManip
    {
        [DllImport(@"CudaLib.dll")]
        private static extern void complexCalcFast(int* a, int* b, int n);

        public static void Difference(int[] arrayA, int[] arrayB)
        {
            fixed (int* a = &arrayA[0], b = &arrayB[0])
            {
                complexCalcFast(a, b, arrayA.Length);

                for (int i = 0; i < arrayB.Length; i++)
                    Console.WriteLine(arrayB[i]);
            }
        }
    }
}
