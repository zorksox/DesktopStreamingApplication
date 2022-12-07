using System;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Text;
using SharpDX.Direct3D11;

namespace DesktopStreamer
{
    public partial class MainWindow : Form
    {
        string ip = "127.0.0.1";
        int port = 12345;
        Protocol Protocol = Protocol.TCP;
        Thread Thread;

        public MainWindow()
        {
            InitializeComponent();

            if (Protocol == Protocol.UDP)
            {
                Thread = new Thread(new ThreadStart(SendUDP));
                Thread.Start();
            }
            else if (Protocol == Protocol.TCP)
            {
                Thread = new Thread(new ThreadStart(SendTCP));
                Thread.Start();
            }
        }

        void SendTCP()
        {
            TcpClient TcpClient = new TcpClient("localhost", 12345);
            NetworkStream Stream = TcpClient.GetStream();

            try
            {
                while (TcpClient.Connected)
                    Stream.Write(Encoding.UTF8.GetBytes("next"), 0, 4);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        void SendUDP()
        {
            Socket Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress DestinationIP = IPAddress.Parse(ip);
            ScreenShot Shot = new ScreenShot(true);
            MemoryStream MemoryStream = new MemoryStream();
            IPEndPoint ViewerEndPoint = new IPEndPoint(DestinationIP, port);
            byte frameNumber = 0;

            while (true)
            {
                MemoryStream.Dispose();
                MemoryStream = new MemoryStream();
                Shot.GenerateSmallBitmap().Save(MemoryStream, GetJpegEncoder(), GetEncoderParams());
                MemoryStream.WriteByte(frameNumber++);
                Socket.SendTo(MemoryStream.ToArray(), ViewerEndPoint);
            }
        }

        private ImageCodecInfo GetJpegEncoder()
        {
            return ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
        }

        private EncoderParameters GetEncoderParams()
        {
            var Params = new EncoderParameters() 
            { 
                Param = new[] { new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 50L) } 
            };

            return Params;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Thread.Abort();
        }
    }

    enum Protocol
    {
        UDP,
        TCP
    }
}
