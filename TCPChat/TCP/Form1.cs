using SuperSimpleTcp;
using System.Text;
using System.Windows.Forms;

namespace TCP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SimpleTcpClient client;



        private void Form1_Load(object sender, EventArgs e)
        {
            client = new(textBox1.Text);
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            client.Events.DataReceived += Events_DataReceived;
            button2.Enabled = false;
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBox2.Text += $"Server: {Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";
            });
            
        }

        private void Events_Disconnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBox2.Text += $"Server đã ngắt.{Environment.NewLine}";
            });
            
        }

        private void Events_Connected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                textBox2.Text += $"Server đã kết nối.{Environment.NewLine}";
            });
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect();
                button2.Enabled = true;
                button1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    client.Send(textBox3.Text);
                    textBox2.Text += $"Me: {textBox3.Text}{Environment.NewLine}";
                    textBox3.Text = string.Empty;
                }
            }
        }
    }
}
