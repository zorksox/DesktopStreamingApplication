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
        string ip = "50.72.93.105";
        int port = 12345;
        Protocol Protocol = Protocol.UDP;
        Thread Thread;
        TcpClient TcpClient;

        public MainWindow()
        {
            InitializeComponent();

            ip = new WebClient().
                DownloadString("http://icanhazip.com").
                Replace("\\r\\n", "").
                Replace("\\n", "").Trim();

            ipTextBox.Text = ip;
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
            TcpClient = new TcpClient(ip, 12345);
            TcpClient.ReceiveBufferSize = 20000;
            TcpClient.SendBufferSize = 20000;
            TcpClient.SendTimeout = 1000;
            NetworkStream Stream = TcpClient.GetStream();
            int frameCount = 0;

            try
            {
                while (TcpClient.Connected)
                {
                    MemoryStream MemoryStream = new MemoryStream();
                    Shot.GenerateSmallBitmap().Save(MemoryStream, GetJpegEncoder(), GetEncoderParams());
                    Stream.Write(MemoryStream.ToArray(), 0, (int)MemoryStream.Length);
                    SetText(sentFramesLabel, frameCount++.ToString());
                    MemoryStream.Close();
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
            int frameCount = 0;

            while (true)
            {
                MemoryStream.Dispose();
                MemoryStream = new MemoryStream();
                Shot.GenerateSmallBitmap().Save(MemoryStream, GetJpegEncoder(), GetEncoderParams());
                SetText(sentFramesLabel, frameCount++.ToString());
                Socket.SendTo(MemoryStream.ToArray(), ViewerEndPoint);
            }
        }

        private void SetText(Control c, string message)
        {
            c.Invoke((MethodInvoker)delegate { c.Text = message; });
        }

        private ImageCodecInfo GetJpegEncoder()
        {
            return ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
        }

        private EncoderParameters GetEncoderParams()
        {
            var Params = new EncoderParameters() 
            { 
                Param = new[] { new EncoderParameter(Encoder.Quality, 50L) } 
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

        private void ipTextBox_TextChanged(object sender, EventArgs e)
        {
            ip = ipTextBox.Text;
        }
    }



    enum Protocol
    {
        UDP,
        TCP
    }
}
