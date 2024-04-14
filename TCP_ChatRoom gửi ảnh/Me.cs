using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab3_Bai06.Server;

namespace Lab3_Bai06
{
    public partial class Me : Form
    {
        public Me()
        {
            InitializeComponent();
        }
        // Phần gửi ảnh sẽ thực hiện ở chat riêng 2 người trong chat room 
        private Socket tcpMe;
        private Socket tcpYou;
        private EndPoint remote_endpoint = (EndPoint)new IPEndPoint(IPAddress.Loopback, 10000);
        private delegate void SafeCallDelegate(string status);
        private SafeCallDelegate safeCall;

        private void btnSend_Click(object sender, EventArgs e)
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
                tcpMe.Close();
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            
            Packet sendData = null;
            string file_message = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string typeOfFile = Path.GetExtension(ofd.FileName);
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
                    MessageBox.Show("Định dạng file không được chấp nhận!");
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
        private void Listen()
        {
            tcpMe = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint local_endpoint = (EndPoint)new IPEndPoint(IPAddress.Loopback, 9000);
            tcpMe.Bind(local_endpoint);
            tcpMe.Listen(1);
            while (true)
            {
                tcpYou = tcpMe.Accept();
                while (tcpYou.Connected)
                {
                    byte[] data = new byte[20000];
                    int byte_count = tcpYou.ReceiveFrom(data, ref remote_endpoint);
                    if (byte_count == 0)
                    {
                        break;
                    }
                    Packet receivedData = new Packet(data);
                    string status = "";
                    status = "";
                    switch (receivedData.ChatDataIdentifier)
                    {
                        case DataIdentifier.LogIn:
                            status = $"< Bây giờ, bạn có thể trò chuyện với {receivedData.ChatName} >";
                            break;

                        case DataIdentifier.LogOut:
                            status = $"< {receivedData.ChatName} vừa rời khỏi cuộc trò chuyện >";
                            break;

                        case DataIdentifier.Message:
                            status = $"{receivedData.ChatName}: {receivedData.ChatMessage}";
                            break;
                        case DataIdentifier.File:
                            status = $"< {receivedData.ChatName} đã gửi cho bạn 1 file >";
                            DialogResult dr = MessageBox.Show("Bạn có muốn đọc nó không?",
                                                      "",
                                                      MessageBoxButtons.OK,
                                                      MessageBoxIcon.Question);
                            if (dr == DialogResult.OK)
                            {
                                rtbChatBox.Text += receivedData.ChatMessage;
                            }
                            break;
                    }
                    UpdateChatHistory(status);
                }
            }
        }

        private void Me_Load(object sender, EventArgs e)
        {
            Thread meThread = new Thread(new ThreadStart(Listen));
            meThread.Start();
        }
        private void Me_FormClosing(object sender, FormClosingEventArgs e)
        {
            Packet sendData = new Packet()
            {
                ChatDataIdentifier = DataIdentifier.LogOut,
                ChatName = this.Text.Trim(),
                ChatMessage = ""
            };
            byte[] logout_message = sendData.GetDataStream();
            tcpYou.SendTo(logout_message, remote_endpoint);
            tcpYou.Shutdown(SocketShutdown.Send);
        }
    }
}
