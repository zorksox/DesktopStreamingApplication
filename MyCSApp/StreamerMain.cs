using System.Runtime.InteropServices;
    
namespace Streamer
{
    unsafe internal class StreamerMain
    {
        [DllImport(@"CudaLib.dll")]
        private static extern void complexCalcFast(int* a, int* b, int n);

        static void Main(string[] args)
        {
            int[] arrayA = { 1, 2, 3, 4, 5 };
            int[] arrayB = { 0, 0, 0, 0, 0 };

            fixed (int* a = &arrayA[0], b = &arrayB[0])
            {
                complexCalcFast(a, b, arrayA.Length);

                for (int i = 0; i < arrayB.Length; i++)
                    Console.WriteLine(arrayB[i]);
            }
        }
    }
}