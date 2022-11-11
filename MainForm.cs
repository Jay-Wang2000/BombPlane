using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BombPlanes_final
{
    public partial class MainForm : Form
    {
        IPEndPoint ipEndPoint;
        Socket socket;
        public enum State
        {
            preparing,
            waiting,
            gaming
        }
        public MainForm()
        {
            InitializeComponent();

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private  void Server_Connection_ClickAsync(object sender, EventArgs e)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            socket = new Socket(
            ipEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);
            socket.Bind(ipEndPoint);
            socket.Listen(100);
            string response;
            Server_Connection.Text = "等待连接";
            Client_Connection.Visible = false;
            AI.Visible = false;
            var handler =socket.Accept();
            while (true)
            {
                // Receive message.
                var buffer = new byte[1_024];
                var received = handler.Receive(buffer, SocketFlags.None);
                 response = Encoding.UTF8.GetString(buffer, 0, received);

                var eom = "<|EOM|>";
                if (response.IndexOf(eom) > -1 /* is end of message */)
                {
                    MessageBox.Show("连接请求");
                    var ackMessage = "<|ACK|>";
                    var echoBytes = Encoding.UTF8.GetBytes(ackMessage);
                    handler.Send(echoBytes, 0);
                    break;
                }
            }

            this.Hide();
            Battle battle = new Battle();
            battle.rival = response[..2];
            battle.role = "Server";
            battle.socket = handler;
            battle.BringToFront();
            battle.Show();
        }

        private void Client_Connection_Click(object sender, EventArgs e)
        {
            IPEndPoint ipEndPoint = new(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text));
            socket = new(
            ipEndPoint.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp);

            socket.Connect(ipEndPoint);
            while (true)
            {
                // Send message.
                var message = "<|EOM|>";
                var messageBytes = Encoding.UTF8.GetBytes(message);
                _ = socket.Send(messageBytes, SocketFlags.None);

                // Receive ack.
                var buffer = new byte[1_024];
                var received = socket.Receive(buffer, SocketFlags.None);
                var response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response == "<|ACK|>")
                {
                    MessageBox.Show("连接成功！");
                    break;
                }
            }
            this.Hide();
            Battle battle = new Battle();
            battle.rival = textBox1.Text;
            battle.role = "Client";
            battle.socket = socket;
            battle.BringToFront();
            battle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Battle battle = new Battle();
            battle.rival = "AI";
            battle.role = "AI对战";
            battle.Show();
        }
    }
}
