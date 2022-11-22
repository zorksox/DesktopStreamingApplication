using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopStreamer
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {

            //get image1, image2
            //compute diff
            //display on screen

            InitializeComponent();

            int[] a = { 0, 1, 2, 3, 4, 5 };
            int[] b = { 0, 0, 0, 0, 0, 0 };

            ImageManip.Difference(a, b);
        }
    }
}
