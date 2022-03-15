using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchWordApp
{
    public partial class Form1 : Form
    {
        private FileHandler _fileHandler;
        public Form1()
        {
            InitializeComponent();
            lblResult.Text = "";
            _fileHandler = new FileHandler();
            btnWordSearch.Enabled = false;
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                tbPathFile.Text = _fileHandler.FilePath = openFileDialog1.FileName;
            btnWordSearch.Enabled = true;
        }
        private async void btnWordSearch_Click(object sender, EventArgs e)
        {
            
            if (tbWord.Text == "")
                return;
            string word = tbWord.Text;
            int countWord = await _fileHandler.CountWordAsync(word);
            lblResult.Text = $"{word}: {countWord}";
        }
    }
}
