using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Linq;

namespace DesktopStreamer
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            //SetImage();
            Bitmap bmp1 = new Bitmap("ds_mini.png");
            Bitmap bmp2 = new Bitmap("ds2_mini.png");
            Console.WriteLine(bmp1.PixelFormat);
            Bitmap difference = bmp1.GetDifference(bmp2);
            var encoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
            var encParams = new EncoderParameters() { Param = new[] { new EncoderParameter(Encoder.Quality, 99L) } };
            bmp1.Save("ds.jpg", encoder, encParams);
            difference.Save("difference.jpg", encoder, encParams);
            //SetImage();
            pictureBox1.Image = difference;

            //int[] a = new int[1000];
            //for (int i = 0; i < a.Length; i++)
            //    a[i] = i;

            //Console.WriteLine(a[10]);
            //int[] b = new int[a.Length];
            //ImageManip.Calc(a,b);
            //Console.WriteLine(b[10]);
            //int[] c = new int[a.Length];
            //ImageManip.Calc(a, b, c);
            //Console.WriteLine(c[10]);
            //ImageManip.CalcBytes(a, b, c);
            //Console.WriteLine(c[10]);

        }

        void SetImage()
        {
            Bitmap bmp = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
            Rectangle bounds = new Rectangle(0, 0, 1920, 1080);

            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            Console.WriteLine(bmp.PixelFormat);
            bmp.Save("./screen.png", ImageFormat.Png);
            pictureBox1.Image = bmp;
        }
    }
}
