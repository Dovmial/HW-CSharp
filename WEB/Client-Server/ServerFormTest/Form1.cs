using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerFormTest
{
    public partial class ServerForm : Form
    {
        ServerBack server;
        public ServerForm()
        {
            InitializeComponent();
            server = new ServerBack();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            server.StartAsync(richTextBox1);
            btnStartServer.Enabled = false;
        }
    }
}
