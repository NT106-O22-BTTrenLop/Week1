using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace Lab3_Bai06
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        // Phần gửi ảnh sẽ thực hiện ở chat riêng 2 người trong chat room 
        private TcpListener tcpServer;
        private Dictionary<string, TcpClient> dic_clients = new Dictionary<string, TcpClient>();

        private void btnListen_Click(object sender, EventArgs e)
        {
            lstChatBox.Items.Add("Đang kết nối...");
            this.btnListen.Enabled = false;
            Thread serverThread = new Thread(new ThreadStart(Listen))
            {
                IsBackground = true
            };
            serverThread.Start();
        }
        private void UpdateStatus(string status)
        {
            if (lstChatBox.InvokeRequired)
            {
                var invoker = new StatusDelegate(UpdateStatus);
                lstChatBox.Invoke(invoker, new object[] { status });
            }
            else
            {
                lstChatBox.Items.Add(status);
            }
        }
        private void Broadcast(Packet sendData, TcpClient sender)
        {
            byte[] message = sendData.GetDataStream();
            foreach (TcpClient receiver in dic_clients.Values)
            {
                if (receiver != sender)
                {
                    NetworkStream net_stream = receiver.GetStream();
                    net_stream.Write(message, 0, message.Length);
                    net_stream.Flush();
                }
            }
        }
        private void Receive(object obj)
        {
            TcpClient client = obj as TcpClient;
            while (client.Connected)
            {
                NetworkStream net_stream = client.GetStream();
                byte[] data = new byte[1024];
                int byte_count = net_stream.Read(data, 0, data.Length);
                if (byte_count == 0)
                {
                    break;
                }
                Packet receivedData = new Packet(data);
                Packet sendData = new Packet()
                {
                    ChatDataIdentifier = receivedData.ChatDataIdentifier,
                    ChatName = receivedData.ChatName
                };
                string status = "";
                switch (receivedData.ChatDataIdentifier)
                {
                    case DataIdentifier.LogIn:
                        if (!dic_clients.ContainsKey(receivedData.ChatName))
                        {
                            dic_clients.Add(receivedData.ChatName, client);
                            status = $"< {receivedData.ChatName} vừa tham gia trò chuyện tại {client.Client.RemoteEndPoint} >";
                        }
                        sendData.ChatMessage = "";
                        break;

                    case DataIdentifier.LogOut:
                        foreach (KeyValuePair<string, TcpClient> kvp in dic_clients)
                        {
                            if (kvp.Value.Equals(client))
                            {
                                dic_clients.Remove(kvp.Key);
                                break;
                            }
                        }
                        status = $"< {receivedData.ChatName} vừa rời khỏi cuộc trò chuyện >";
                        sendData.ChatMessage = $"< {receivedData.ChatName} đã ngưng hoạt động >";
                        break;

                    case DataIdentifier.Message:
                        status = $"{receivedData.ChatName}: {receivedData.ChatMessage}";
                        sendData.ChatMessage = receivedData.ChatMessage;
                        break;
                }
                Broadcast(sendData, client);
                UpdateStatus(status);
            }
        }
        private void Listen()
        {
            tcpServer = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            tcpServer.Start();
            try
            {
                while (true)
                {
                    TcpClient client = tcpServer.AcceptTcpClient();
                    Thread receiveThread = new Thread(Receive)
                    {
                        IsBackground = true
                    };
                    receiveThread.Start(client);
                }
            }
            catch
            {
                tcpServer = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            }
        }

        private delegate void StatusDelegate(string status);
        public enum DataIdentifier
        {
            LogIn,
            LogOut,
            Message,
            File,
            Null
        }

        public class Packet
        {
            private DataIdentifier dataIdentifier;
            private string username;
            private string message;

            public DataIdentifier ChatDataIdentifier
            {
                get { return dataIdentifier; }
                set { dataIdentifier = value; }
            }

            public string ChatName
            {
                get { return username; }
                set { username = value; }
            }

            public string ChatMessage
            {
                get { return message; }
                set { message = value; }
            }

            public Packet()
            {
                this.dataIdentifier = DataIdentifier.Null;
                this.username = "";
                this.message = "";
            }

            public Packet(byte[] data)
            {
                this.dataIdentifier = (DataIdentifier)BitConverter.ToInt32(data, 0);
                int username_length = BitConverter.ToInt32(data, 4);
                int message_length = BitConverter.ToInt32(data, 8);
                if (username_length > 0)
                    this.username = Encoding.UTF8.GetString(data, 12, username_length);
                else
                    this.username = "";
                if (message_length > 0)
                    this.message = Encoding.UTF8.GetString(data, 12 + username_length, message_length);
                else
                    this.message = "";
            }
            public byte[] GetDataStream()
            {
                List<byte> data = new List<byte>();
                data.AddRange(BitConverter.GetBytes((int)this.dataIdentifier));
                if (this.username != "")
                    data.AddRange(BitConverter.GetBytes(this.username.Length));
                else
                    data.AddRange(BitConverter.GetBytes(0));
                if (this.message != "")
                    data.AddRange(BitConverter.GetBytes(this.message.Length));
                else
                    data.AddRange(BitConverter.GetBytes(0));
                if (this.username != "")
                    data.AddRange(Encoding.UTF8.GetBytes(this.username));
                if (this.message != "")
                    data.AddRange(Encoding.UTF8.GetBytes(this.message));
                return data.ToArray();
            }
        }
    }
}
