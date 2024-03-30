using SuperSimpleTcp;
using System.Text;

namespace TCPServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SimpleTcpServer server;

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            server = new SimpleTcpServer(textBox1.Text);
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;

        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
        
            this.Invoke((MethodInvoker)delegate
            {
                textBox2.Text += $"{e.IpPort} : {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
            });
        }

        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
           
            this.Invoke((MethodInvoker)delegate
            {
                textBox2.Text += $"{e.IpPort} đã ngắt.{Environment.NewLine}";
                listBox1.Items.Remove(e.IpPort);
            });
        }

        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBox2.Text += $"{e.IpPort} đã kết nối.{Environment.NewLine}";
                listBox1.Items.Add(e.IpPort);
            });
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.Start();
            textBox2.Text += $"Kết nối . . .{Environment.NewLine}";
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (server.IsListening)
            {
                if (!string.IsNullOrEmpty(textBox3.Text) && listBox1.SelectedItem != null )
                {
                    server.Send (listBox1.SelectedItem.ToString(), textBox3.Text);
                    textBox2.Text += $"Server: {textBox3.Text}{Environment.NewLine}";
                    textBox3.Text = string.Empty ;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
