using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BombPlanes_final
{
    public partial class Battle : Form
    {
        int _numOfHittedPlane = 0;
        public string role { get; set; }

        public Socket socket { get; set; }
        public enum State
        {
            preparing,
            waiting,
            gaming
        }
        public State _state = State.preparing;
        public string rival { get; set; }
        public Battle()
        {
            InitializeComponent();
        }

        public void AddLog(string str)
        {
            if (listView1.Items.Count > 100)
            {
                listView1.Items.RemoveAt(99);
            }
            listView1.Items.Insert(0, str);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (_state)
            {
                case State.preparing:
                    _state = State.gaming;
                    MainButton.Text = "轰炸";
                    break;
                case State.gaming:
                    if (role.Equals("Server"))
                    {
                        ServerPlayAsync();
                    }
                    else if (role.Equals("Client"))
                    {
                        ClientPlayAsync();
                    }
                    else
                    {
                        AIPlay();
                    }
                    break;
            }
        }

        private void Battle_FormClosed(object sender, FormClosedEventArgs e)
        {
            socket.Shutdown(SocketShutdown.Both);
            AddLog("服务端断开成功！");
        }
        public void end(string outcome)  //显示自己输赢
        {
            _state = State.preparing;
            MainButton.Text = "准备";
            gridNetworkMyself.PlaneVisiblibity = false;
            gridNetworkCounter.Clear();
            gridNetworkMyself.Clear();
            _numOfHittedPlane = 0;
            MessageBox.Show(outcome);

        }
        private async Task ServerPlayAsync()
        {
            var buffer = new byte[1_024];
            var received = await socket.ReceiveAsync(buffer, SocketFlags.None);
            var response = Encoding.UTF8.GetString(buffer, 0, received);
            BombResult bombResult = gridNetworkMyself.Bomb(new(response[0], response[1]));
            if (bombResult == BombResult.head)
                _numOfHittedPlane++;
            AddLog("hitted " + response + " " + bombResult.ToString());

            while (_numOfHittedPlane < 3)
            {
                var message = gridNetworkCounter.SelectedButtonPoint.X.ToString() + bombResult.ToString();
                var messageBytes = Encoding.UTF8.GetBytes(message);
                _ = await socket.SendAsync(messageBytes, SocketFlags.None);
                AddLog("sent " + message);

                buffer = new byte[1_024];
                received = await socket.ReceiveAsync(buffer, SocketFlags.None);
                response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response.Equals("I lose!"))
                {
                    end("You Win!");
                    return;
                }
                else
                {
                    gridNetworkCounter.DrawBombResultWithString(new(response[0], response[1]), response.Substring(2, -1));
                    bombResult = gridNetworkMyself.Bomb(new(response[0], response[1]));
                    if (bombResult == BombResult.head)
                        _numOfHittedPlane++;
                    AddLog("hitted " + response + " " + bombResult.ToString());
                }
            }
            _ = await socket.SendAsync(Encoding.UTF8.GetBytes("I lose!"), SocketFlags.None);
            end("You lose!");
        }
        private async Task ClientPlayAsync()
        {
            var message = gridNetworkCounter.SelectedButtonPoint.X.ToString()
                    + gridNetworkCounter.SelectedButtonPoint.X.ToString();
            var messageBytes = Encoding.UTF8.GetBytes(message);
            _ = await socket.SendAsync(messageBytes, SocketFlags.None);
            AddLog("sent" + message);
            do
            {
                var buffer = new byte[1_024];
                var received = await socket.ReceiveAsync(buffer, SocketFlags.None);
                var response = Encoding.UTF8.GetString(buffer, 0, received);

                if (response.Equals("I lose!"))
                {
                    end("You Win!");
                    return;
                }
                else
                {
                    gridNetworkMyself.DrawBombResultWithString(new(response[0], response[1]), response.Substring(2, -1));
                    BombResult bombResult = gridNetworkMyself.Bomb(new(response[0], response[1]));
                    AddLog("hitted " + response + " " + bombResult.ToString());
                    if (bombResult.Equals(BombResult.head))
                        _numOfHittedPlane++;
                    message = gridNetworkCounter.SelectedButtonPoint.X.ToString() + bombResult.ToString();
                    messageBytes = Encoding.UTF8.GetBytes(message);
                    _ = await socket.SendAsync(messageBytes, SocketFlags.None);
                    AddLog("sent" + message);
                }

            } while (_numOfHittedPlane < 3);
            _ = await socket.SendAsync(Encoding.UTF8.GetBytes("I lose!"), SocketFlags.None);
            end("You lose!");
        }
        private void AIPlay()
        {
            int counterHittedPioint=0;
            while (counterHittedPioint < 3 && _numOfHittedPlane < 3)
            {
                if (gridNetworkCounter.Bomb(gridNetworkCounter.SelectedButtonPoint).Equals(BombResult.head))
                    counterHittedPioint++;
                if (gridNetworkMyself.Bomb(AIChoose()).Equals(BombResult.head))
                    _numOfHittedPlane++;
            }
            if (counterHittedPioint < 3)
                end("You Win");
            else
                end("You Lose!");
        }

        private Point AIChoose()
        {
            return new(0, 0);
        }
    }

}
