using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientFormTest
{
    public partial class ServerForm : Form
    {

        public ServerForm()
        {
            InitializeComponent();
            lblHelp.Text = "\tКоманды:\n\"время\" - ообразить время\n\"дата\" - запросить дату у сервера";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ClientBack client = new ClientBack();
            string answear = await Task.Run(() => client.Send(rtbSendClient.Text));
            rtbSendClient.Clear();
            rtbServerAnswear.AppendText($"[{DateTime.Now.ToLocalTime()}]: {answear}");
        }
    }
}
