using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LibraryUDP.Model;
using LibraryUDP;


namespace UDPWinFormsServerEquipment
{
    public partial class Form1 : Form
    {
        UDPObject server = new UDPObject(8001, 8002);
        List<Good> _goods = new List<Good>(){
            new Good(25000.45m, "processor"),
            new Good(55000.55m, "graphic card"),
            new Good(7000.34m, "RAM")
        };
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStartServer_Click(object sender, EventArgs e)
        {
            btnStartServer.Enabled = false;
            string message = "Start server..\n";
            richTextBox1.AppendText(message);
            while (true)
            {
                message = await server.ReceiveMessageAsync();
                richTextBox1.AppendText($"{message}\n");
                if (message == "GET PRODUCTS")
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in _goods)
                        sb.Append($"{item.Name}%");
                    server.SendMessage(sb.ToString());
                }
                var good = _goods.Find(g => g.Name == message);
                
                server.SendMessage(good?.Price.ToString()??"Null");
            }
        }
    }
}
