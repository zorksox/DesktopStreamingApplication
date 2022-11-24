using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DesktopStreamer
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            //Bitmap bmp1 = new Bitmap("ds.png");
            //Bitmap bmp2 = new Bitmap("ds2.png");
            //Bitmap difference = bmp1.Subtract(bmp2);
            //pictureBox1.Image = difference;

            int[] a = new int[1000];

            for (int i = 0; i < a.Length; i++)
                a[i] = i;

            int[] b = new int[a.Length];

            ImageManip.Calc(a,b);

            for (int i = 0; i < b.Length; i++)
                Console.WriteLine(b[i]);
        }

        void SetImage()
        {
            Bitmap bmp = new Bitmap(1920, 1080);
            Rectangle bounds = new Rectangle(0, 0, 1920, 1080);

            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);

            pictureBox1.Image = bmp;
        }
    }
}
