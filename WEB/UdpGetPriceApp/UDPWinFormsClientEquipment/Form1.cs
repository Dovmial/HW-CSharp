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
            btnPrice.Enabled = false;
            if (!CheckPossibilityRequest())
            {
                btnPrice.Enabled = true;
                return;
            }
                
            client.SendMessage(listBox1.SelectedItem?.ToString() ?? "Null");
            lblPrice.Text = $"{await client.ReceiveMessageAsync()} Rub";
            btnPrice.Enabled = true;
        }

        private async Task GetListProductsAsync()
        {
            client.SendMessage("GET PRODUCTS");
            string goods = await client.ReceiveMessageAsync();
            _goods = goods?.Split('%').ToList();
        }

        private async void btnGetProducts_Click(object sender, EventArgs e)
        {
            try
            {
                await GetListProductsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            listBox1.Items.Clear();
            listBox1.Items?.AddRange(_goods.ToArray());
            if (listBox1.Items?.Count > 0)
                btnPrice.Enabled = true;

        }

        private bool CheckPossibilityRequest()
        {
            if (!_timeQueryHandler.AddNowTime())
            {
                var timeExpired = _timeQueryHandler.TimeQueries[0].AddMinutes(1.0) - DateTime.Now;
                MessageBox.Show($"No more than 10 requests per minute allowed. " +
                    $"Try Later.\n\t{-(int)timeExpired.TotalSeconds} sec");
                return false;
            }
            return true;
        }
    }
}
