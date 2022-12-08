using System;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace DesktopStreamer
{
    public partial class MainWindow : Form
    {
        string ip = "127.0.0.1";
        int port = 12345;
        Protocol Protocol = Protocol.UDP;
        Thread Thread;
        TcpClient TcpClient;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start()
        {
            if (Protocol == Protocol.UDP)
            {
                Thread = new Thread(new ThreadStart(SendUDP));
                Thread.IsBackground = true;
                Thread.Start();
            }
            else if (Protocol == Protocol.TCP)
            {
                Thread = new Thread(new ThreadStart(SendTCP));
                Thread.IsBackground = true;
                Thread.Start();
            }
        }

        void SendTCP()
        {
            ScreenShot Shot = new ScreenShot();
            TcpClient = new TcpClient("localhost", 12345);
            NetworkStream Stream = TcpClient.GetStream();
            int frameCount = 0;

            try
            {
                while (TcpClient.Connected)
                {
                    MemoryStream MemoryStream = new MemoryStream();
                    Shot.GenerateSmallBitmap().Save(MemoryStream, GetJpegEncoder(), GetEncoderParams());
                    Stream.Write(MemoryStream.ToArray(), 0, (int)MemoryStream.Length);
                    SetText("" + frameCount++);
                    MemoryStream.Dispose();
                }
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

        private void SetText(string message)
        {
            Invoke((MethodInvoker)delegate { Text = message; });
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
            Thread?.Abort();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void UDPButton_Clicked(object sender, EventArgs e)
        {
            Protocol = Protocol.UDP;
        }

        private void TCPButton_Clicked(object sender, EventArgs e)
        {
            Protocol = Protocol.TCP;
        }
    }



    enum Protocol
    {
        UDP,
        TCP
    }
}
