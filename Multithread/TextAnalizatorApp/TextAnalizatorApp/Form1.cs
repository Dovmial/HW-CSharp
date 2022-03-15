using System;
using System.IO;
using System.Windows.Forms;

namespace TextAnalizatorApp
{
    public partial class Form1 : Form
    {
        TextAnalizator _textAnalizator = new TextAnalizator();
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnAnalize_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text.Trim();
            await _textAnalizator.AnalizeAsync(text);
            MessageBox.Show("Analize is completed\n");
        }

        private async void btnShowReport_Click(object sender, EventArgs e)
        {
            if(rbWindowCheck.Checked)
                MessageBox.Show(_textAnalizator.Statistic.ToString());
            else
            {
                await File.WriteAllTextAsync("Report.txt",_textAnalizator.Statistic.ToString());
                MessageBox.Show("data sent to \"Report.txt\"");
            }
        }
    }
}
