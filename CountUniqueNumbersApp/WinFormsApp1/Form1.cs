using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        string? pathSourceFile;
        List<int> numbers = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLoadNumbers_Click(object sender, EventArgs e)
        {
            if (pathSourceFile == null)
            {
                MessageBox.Show("Choose file!");
                return;
            }
            var text = await File.ReadAllTextAsync(pathSourceFile);
            
            char[] separators = { ' ', ',', '\n', ';' };
            numbers = text.Split(separators)
                             .Where(x => x != "")
                             .AsParallel()
                             .Distinct()
                             .Select(n => int.Parse(n))
                             .ToList();

            lblCountElements.Text = $"Amount unique numbers: {numbers.Count}";
        }

        private void btnChooseFileSource_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbSourceFile.Text = pathSourceFile = openFileDialog1.FileName;
            }
        }

    }
}
