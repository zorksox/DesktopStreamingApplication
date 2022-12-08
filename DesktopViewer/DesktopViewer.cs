using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace DesktopViewer
{
    public partial class DesktopViewer : Form
    {
        Size Original = new Size(384, 216);
        Size SizeToAdd = new Size(48, 27);
        Position Position;
        Protocol Protocol = Protocol.UDP;
        int port = 12345;
        string ip = "127.0.0.1";
        Thread? Thread;

        public DesktopViewer()
        {
            InitializeComponent();
        }

        private void Start()
        {
            if (Protocol == Protocol.UDP)
            {
                Thread = new Thread(new ThreadStart(ReceiveUDPData));
                Thread.IsBackground = true;
                Thread.Start();
            }
            else if (Protocol == Protocol.TCP)
            {
                Thread = new Thread(new ThreadStart(ReceiveTCPData));
                Thread.IsBackground = true;
                Thread.Start();
            }
        }

        private void ReceiveTCPData()
        {
            SetText("Waiting for TCP server....");
            TcpListener TcpServer = new TcpListener(IPAddress.Loopback, port);
            TcpServer.Start();
            TcpClient TcpClient = TcpServer.AcceptTcpClient();
            NetworkStream Stream = TcpClient.GetStream();
            Span<byte> byteSpan = new byte[20000];
            int byteCount = 0;
            ImageConverter ImageConverter = new ImageConverter();

            while (true)
            {
                if (!TcpClient.Connected)
                    TcpClient = TcpServer.AcceptTcpClient();

                byteCount = 0;
                byteCount = Stream.Read(byteSpan);

                if (byteCount > 0)
                {
                    byte[] byteArray = byteSpan.Slice(0, byteCount).ToArray();
                    BackgroundImage = ImageConverter.ConvertFrom(byteArray) as Bitmap;
                }
            }
        }

        private void SetText(string message)
        {
            Invoke((MethodInvoker)delegate { Text = message; });
        }

        private void ReceiveUDPData()
        {
            UdpClient client = new UdpClient(port);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, port);
            byte[] bytes;

            while (true)
            {
                bytes = client.Receive(ref groupEP);
                BackgroundImage?.Dispose();
                BackgroundImage = new ImageConverter().ConvertFrom(bytes) as Bitmap;
                Text = bytes.Last().ToString();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Oemplus: IncreaseSize(); break;
                case Keys.OemMinus: DecreaseSize(); break;
                case Keys.Back: Size = Original; break;
                case Keys.NumPad1 or Keys.D1: Position = Position.BottomLeft; break;
                case Keys.NumPad2 or Keys.D2: Position = Position.BottomMiddle; break;
                case Keys.NumPad3 or Keys.D3: Position = Position.BottomRight; break;
                case Keys.NumPad4 or Keys.D4: Position = Position.MiddleLeft; break;
                case Keys.NumPad6 or Keys.D6: Position = Position.MiddleRight; break;
                case Keys.NumPad7 or Keys.D7: Position = Position.TopLeft; break;
                case Keys.NumPad8 or Keys.D8: Position = Position.TopMiddle; break;
                case Keys.NumPad9 or Keys.D9: Position = Position.TopRight; break;
                case Keys.Escape: Application.Exit(); break;
            }

            SetPosition();
        }

        private void SetPosition()
        {
            switch (Position)
            {
                case Position.BottomLeft: MoveToBottomLeft(); break;
                case Position.BottomMiddle: MoveToBottomMiddle(); break;
                case Position.BottomRight: MoveToBottomRight(); break;
                case Position.MiddleLeft: MoveToLeftMiddle(); break;
                case Position.MiddleRight: MoveToRightMiddle(); break;
                case Position.TopLeft: MoveToTopLeft(); break;
                case Position.TopMiddle: MoveToTopMiddle(); break;
                case Position.TopRight: MoveToTopRight(); break;
            }
        }

        private void IncreaseSize()
        {
            Size = Size.Add(Size, SizeToAdd);
            SetPosition();
        }

        private void DecreaseSize()
        {
            Size = Size.Subtract(Size, SizeToAdd);
            SetPosition();
        }

        private void MoveToBottomLeft()
        {
            Position = Position.BottomLeft;
            int top = Screen.PrimaryScreen.Bounds.Bottom - Size.Height;
            int left = 0;

            Location = new Point(left, top);
        }

        private void MoveToBottomRight()
        {
            Position = Position.BottomRight;
            int top = Screen.PrimaryScreen.Bounds.Bottom - Size.Height;
            int left = Screen.PrimaryScreen.Bounds.Right - Size.Width;

            Location = new Point(left, top);
        }

        private void MoveToBottomMiddle()
        {
            Position = Position.BottomMiddle;
            int top = Screen.PrimaryScreen.Bounds.Bottom - Size.Height;
            int left = (Screen.PrimaryScreen.Bounds.Right - Size.Width) / 2;

            Location = new Point(left, top);
        }

        private void MoveToLeftMiddle()
        {
            Position = Position.MiddleLeft;
            int top = (Screen.PrimaryScreen.Bounds.Bottom - Size.Height) / 2;
            int left = 0;

            Location = new Point(left, top);
        }

        private void MoveToRightMiddle()
        {
            Position = Position.MiddleRight;
            int top = (Screen.PrimaryScreen.Bounds.Bottom - Size.Height) / 2;
            int left = Screen.PrimaryScreen.Bounds.Right - Size.Width;

            Location = new Point(left, top);
        }

        private void MoveToTopLeft()
        {
            Position = Position.TopLeft;
            int top = 0;
            int left = 0;

            Location = new Point(left, top);
        }

        private void MoveToTopMiddle()
        {
            Position = Position.TopMiddle;
            int top = 0;
            int left = (Screen.PrimaryScreen.Bounds.Right - Size.Width) / 2;

            Location = new Point(left, top);
        }

        private void MoveToTopRight()
        {
            Position = Position.TopRight;
            int top = 0;
            int left = Screen.PrimaryScreen.Bounds.Right - Size.Width;

            Location = new Point(left, top);
        }

        private void DesktopViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
#pragma warning disable SYSLIB0006
            Thread?.Abort();
#pragma warning restore SYSLIB0006
        }

        private void UDPButton_Clicked(object sender, EventArgs e)
        {
            Text = "UDP mode";
            Protocol = Protocol.UDP;
        }

        private void TCPButton_Clicked(object sender, EventArgs e)
        {
            Text = "TCP mode";
            Protocol = Protocol.TCP;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start();
        }
    }

    enum Position
    {
        TopLeft,
        TopMiddle,
        TopRight,
        MiddleLeft,
        BottomLeft,
        BottomMiddle,
        BottomRight,
        MiddleRight
    }

    enum Protocol
    {
        UDP,
        TCP
    }
}