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

        private async void Server_Connection_ClickAsync(object sender, EventArgs e)
        {
            /*IPAddress myself = IPAddress.Parse("127.0.0.1");*/
            ipEndPoint = new IPEndPoint(IPAddress.Any, 8038);

            socket = new Socket(
            ipEndPoint.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);
            socket.Bind(ipEndPoint);
            socket.Listen(100);
            var handler = await socket.AcceptAsync();
            string response;
            Server_Connection.Text = "等待连接";
            Client_Connection.Visible = false;
            while (true)
            {
                // Receive message.
                var buffer = new byte[1_024];
                var received = await handler.ReceiveAsync(buffer, SocketFlags.None);
                 response = Encoding.UTF8.GetString(buffer, 0, received);

                var eom = "<|EOM|>";
                if (response.IndexOf(eom) > -1 /* is end of message */)
                {
                    Console.WriteLine(
                        $"Socket server received message: \"{response.Replace(eom, "")}\"");

                    var ackMessage = "<|ACK|>";
                    var echoBytes = Encoding.UTF8.GetBytes(ackMessage);
                    await handler.SendAsync(echoBytes, 0);
                    Console.WriteLine(
                        $"Socket server sent acknowledgment: \"{ackMessage}\"");

                    break;
                }
            }

            this.Close();
            Battle battle = new Battle();
            battle.rival = response[..9];
            battle.role = "Server";
            battle.socket = socket;
            battle.Show();
        }

        private async void Client_Connection_Click(object sender, EventArgs e)
        {
            IPEndPoint ipEndPoint = new(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text));
            socket = new(
            ipEndPoint.AddressFamily,
            SocketType.Stream,
            ProtocolType.Tcp);

            await socket.ConnectAsync(ipEndPoint);
            while (true)
            {
                // Send message.
                var message = "Hi friends 👋!<|EOM|>";
                var messageBytes = Encoding.UTF8.GetBytes(message);
                _ = await socket.SendAsync(messageBytes, SocketFlags.None);
                Console.WriteLine($"Socket client sent message: \"{message}\"");

                // Receive ack.
                var buffer = new byte[1_024];
                var received = await socket.ReceiveAsync(buffer, SocketFlags.None);
                var response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response == "<|ACK|>")
                {
                    Console.WriteLine(
                        $"Socket client received acknowledgment: \"{response}\"");
                    break;
                }
                // Sample output:
                //     Socket client sent message: "Hi friends 👋!<|EOM|>"
                //     Socket client received acknowledgment: "<|ACK|>"
            }
            this.Close();
            Battle battle = new Battle();
            battle.rival = textBox1.Text;
            battle.role = "Client";
            battle.socket = socket;
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
