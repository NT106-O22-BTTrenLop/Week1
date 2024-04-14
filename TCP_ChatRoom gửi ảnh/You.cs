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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Lab3_Bai06
{
    public partial class You : Form
    {
        public You()
        {
            InitializeComponent();
        }
        // // Phần gửi ảnh sẽ thực hiện ở chat riêng 2 người trong chat room 
        private static Socket tcpYou;
        private EndPoint remote_endpoint = (EndPoint)new IPEndPoint(IPAddress.Loopback, 9000);

        private void You_Load(object sender, EventArgs e)
        {
            tcpYou = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint local_endpoint = (EndPoint)new IPEndPoint(IPAddress.Loopback, 10000);
            tcpYou.Bind(local_endpoint);
            try
            {
                tcpYou.Connect(remote_endpoint);
                Packet sendData = new Packet()
                {
                    ChatDataIdentifier = DataIdentifier.LogIn,
                    ChatName = this.Text,
                    ChatMessage = ""
                };
                byte[] login_message = sendData.GetDataStream();
                tcpYou.SendTo(login_message, remote_endpoint);
                Thread youThread = new Thread(Receive)
                {
                    IsBackground = true
                };
                youThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                MessageBox.Show("Vui lòng nhập tin nhắn!");
                return;
            }
            else
            {
                try
                {
                    Packet sendData = new Packet()
                    {
                        ChatDataIdentifier = DataIdentifier.Message,
                        ChatName = this.Text,
                        ChatMessage = txtMessage.Text
                    };
                    byte[] data = sendData.GetDataStream();
                    tcpYou.SendTo(data, remote_endpoint);
                    UpdateChatHistory($"Tôi: {txtMessage.Text}");
                    txtMessage.Clear();
                }
                catch
                {
                    MessageBox.Show("Kết nối không thành công!");
                }
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string typeOfFile = "";
            Packet sendData = null;
            string file_message = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                typeOfFile = Path.GetExtension(ofd.FileName);
                if (typeOfFile == ".txt" || typeOfFile == ".jpg" || typeOfFile == ".png")
                {
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        StreamReader sr = new StreamReader(fs);
                        file_message = sr.ReadToEnd();
                    }
                    sendData = new Packet()
                    {
                        ChatDataIdentifier = DataIdentifier.File,
                        ChatName = this.Text,
                        ChatMessage = file_message
                    };
                }
                else
                {
                    MessageBox.Show("Định dạng file không phù hợp!");
                }
            }
            byte[] data = sendData.GetDataStream();
            tcpYou.SendTo(data, remote_endpoint);
            UpdateChatHistory($"< Bạn vừa gửi file: {ofd.FileName} >");

        }
        private void UpdateChatHistory(string status)
        {
            if (rtbChatBox.InvokeRequired)
            {
                var invoker = new SafeCallDelegate(UpdateChatHistory);
                rtbChatBox.Invoke(invoker, new object[] { status });
            }
            else
            {
                if (status.Contains('\n'))
                {
                    status = status.Replace('\n', ' ');
                }
                rtbChatBox.AppendText(status + '\n');
            }
        }
        private void Receive()
        {
            while (true)
            {
                byte[] data = new byte[20000]; //kích thước file (bytes)
                int byte_count = tcpYou.ReceiveFrom(data, ref remote_endpoint);
                if (byte_count == 0)
                {
                    break;
                }
                Packet receivedData = new Packet(data);
                if (receivedData.ChatDataIdentifier == DataIdentifier.Message)
                {
                    UpdateChatHistory($"{receivedData.ChatName}: {receivedData.ChatMessage}");
                }
                if (receivedData.ChatDataIdentifier == DataIdentifier.LogOut)
                {
                    UpdateChatHistory($"< {receivedData.ChatName} vừa rời khỏi cuộc trò chuyện >");
                }
                if (receivedData.ChatDataIdentifier == DataIdentifier.File)
                {
                    UpdateChatHistory($"< {receivedData.ChatName} đã gửi cho bạn 1 file >");
                    DialogResult dr = MessageBox.Show("Bạn có muốn đọc không?",
                                                      "",
                                                      MessageBoxButtons.OK,
                                                      MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        rtbChatBox.Text += receivedData.ChatMessage;
                    }
                }
            }
        }
        private void You_FormClosing(object sender, FormClosingEventArgs e)
        {
            Packet sendData = new Packet()
            {
                ChatDataIdentifier = DataIdentifier.LogOut,
                ChatName = this.Text.Trim(),
                ChatMessage = ""
            };
            if (tcpYou.Connected)
            {
                byte[] logout_message = sendData.GetDataStream();
                tcpYou.SendTo(logout_message, remote_endpoint);
                tcpYou.Shutdown(SocketShutdown.Both);
            }
        }
        private delegate void SafeCallDelegate(string status);

    }
}
