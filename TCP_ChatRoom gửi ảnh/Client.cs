using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab3_Bai06.Server;
using System.Threading;

namespace Lab3_Bai06
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        // Phần gửi ảnh sẽ thực hiện ở chat riêng 2 người trong chat room 
        private TcpClient tcpClient;
        IPEndPoint server_endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên!");
                return;
            }
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(server_endpoint);
                this.Text = txtName.Text.Trim();
                this.btnConnect.Enabled = false;
                Packet sendData = new Packet()
                {
                    ChatDataIdentifier = DataIdentifier.LogIn,
                    ChatName = txtName.Text.Trim(),
                    ChatMessage = ""
                };
                byte[] data = sendData.GetDataStream();
                NetworkStream net_stream = tcpClient.GetStream();
                net_stream.Write(data, 0, data.Length);
                net_stream.Flush();
                Thread clientThread = new Thread(Receive)
                {
                    IsBackground = true
                };
                clientThread.Start();
            }
            catch
            {
                MessageBox.Show("Kết nối không thành công!");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (tcpClient == null)
                {
                    MessageBox.Show("Vui lòng kết nối với server trước!");
                    return;
                }
                if (string.IsNullOrEmpty(txtMessage.Text))
                {
                    MessageBox.Show("Vui lòng nhập tin nhắn!");
                    return;
                }
                Packet sendData = new Packet()
                {
                    ChatDataIdentifier = DataIdentifier.Message,
                    ChatName = txtName.Text.Trim(),
                    ChatMessage = txtMessage.Text
                };
                byte[] data = sendData.GetDataStream();
                NetworkStream net_stream = tcpClient.GetStream();
                net_stream.Write(data, 0, data.Length);
                net_stream.Flush();
                DisplayMessage($"Tôi: {txtMessage.Text}");
                txtMessage.Text = string.Empty;
                txtName.ReadOnly = true;
            }
            catch
            {
                MessageBox.Show("Kết nối đã bị đóng!");
            }
        }
        private void DisplayMessage(string message)
        {
            if (lstChatBox.InvokeRequired)
            {
                var invoker = new MessageDelegate(DisplayMessage);
                lstChatBox.Invoke(invoker, new object[] { message });
            }
            else
            {
                if (message.Contains('\n'))
                {
                    message = message.Replace('\n', ' ');
                }
                lstChatBox.Items.Add(message);
            }
        }
        private void UpdateParticipants(string username)
        {
            if (lstParticipants.InvokeRequired)
            {
                var invoker = new ParticipantsDelegate(UpdateParticipants);
                lstParticipants.Invoke(invoker, new object[] { username });
            }
            else
            {
                lstParticipants.Items.Add(username);
            }
        }
        private void Receive()
        {
            while (true)
            {
                NetworkStream net_stream = tcpClient.GetStream();
                byte[] data = new byte[1024];
                int byte_count = net_stream.Read(data, 0, data.Length);
                if (byte_count == 0)
                {
                    break;
                }
                Packet receivedData = new Packet(data);
                if (receivedData.ChatDataIdentifier == DataIdentifier.Message)
                {
                    DisplayMessage($"{receivedData.ChatName}: {receivedData.ChatMessage}");
                    if (!lstParticipants.Items.Contains(receivedData.ChatName))
                    {
                        UpdateParticipants(receivedData.ChatName);
                    }
                }
                else
                {
                    if (receivedData.ChatMessage != "")
                    {
                        DisplayMessage(receivedData.ChatMessage);
                    }
                }
            }
        }
        private void lstParticipants_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstParticipants.SelectedIndex;
            if (index != -1)
            {
                Me me = new Me() // Server 
                {
                    Text = txtName.Text.Trim()
                };
                me.Show();
                You you = new You() //Client 
                {
                    Text = lstParticipants.Items[index].ToString()
                };
                you.Show();
            }
            else
            {
                MessageBox.Show("Không tồn tại người dùng nào!");
            }
        }
        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Packet sendData = new Packet()
            {
                ChatDataIdentifier = DataIdentifier.LogOut,
                ChatName = txtName.Text.Trim(),
                ChatMessage = ""
            };
            if (tcpClient.Connected)
            {
                byte[] logout_message = sendData.GetDataStream();
                NetworkStream net_stream = tcpClient.GetStream();
                net_stream.Write(logout_message, 0, logout_message.Length);
                net_stream.Flush();
                tcpClient.Client.Shutdown(SocketShutdown.Send);
            }
        }
        private delegate void MessageDelegate(string message);
        private delegate void ParticipantsDelegate(string username);
        private delegate void OnConnectEventHandler(bool is_connected);
    }
}
