using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryUDP;

namespace UDPWinFormsClientEquipment
{
    public partial class Form1 : Form
    {
        List<string> _goods = new List<string>();
        UDPObject client = new UDPObject(8002, 8001);
        static TimeQueryHandler _timeQueryHandler = new TimeQueryHandler();

        public Form1()
        {
            InitializeComponent();
            btnPrice.Enabled = false;
        }

        private async void btnPrice_Click(object sender, EventArgs e)
        {
            if (!CheckPossibilityRequest())
                return;
            client.SendMessage(listBox1.SelectedItem?.ToString() ?? "Null");
            lblPrice.Text = $"{await client.ReceiveMessageAsync()} Rub";
        }

        private async Task GetListProductsAsync()
        {
            client.SendMessage("GET PRODUCTS");
            string goods = await client.ReceiveMessageAsync();
            _goods = goods?.Split('%').ToList();
        }

        private async void btnGetProducts_Click(object sender, EventArgs e)
        {
            await GetListProductsAsync();
            listBox1.Items?.AddRange(_goods.ToArray());
            if(listBox1.Items?.Count > 0)
                btnPrice.Enabled = true;
        }

        private bool CheckPossibilityRequest()
        {
            if (!_timeQueryHandler.AddNowTime())
            {
                MessageBox.Show("No more than 10 requests per hour allowed. Try Later.");
                return false;
            }
            return true;
        }
    }
}
