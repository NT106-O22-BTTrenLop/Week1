using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_Bai06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            Server sv = new Server();
            sv.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Client cl = new Client();
            cl.Show();
        }

        private void btnYou_Click(object sender, EventArgs e)
        {
            You y = new You();
            y.Show();
        }

        private void btnMe_Click(object sender, EventArgs e)
        {
            Me m = new Me();
            m.Show();
        }
    }
}
