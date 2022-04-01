using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookDownloadApp
{
    public partial class Form1 : Form
    {
        ParserHTML parser = new ParserHTML();


        public Form1()
        {
            InitializeComponent();
        }

        private void ProgressbarStart()
        {
            int stepProgressBar = progressBar1.Maximum / (parser.TimeDelay /1000);

            while (progressBar1.Value != progressBar1.Maximum)
            {

                progressBar1.Invoke(
                    new Action(() =>
                        progressBar1.Increment(stepProgressBar)));
                if (progressBar1.Value > progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                    break;
                }
                Thread.Sleep(1000);
            }

        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            Task.Run(() => ProgressbarStart());

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
            btnDownload.Enabled = false;
            Book book;
            Task.Run(() =>
            {
                parser.GetBooksTop100();
                for (int i = 0; i < parser.Books.Count; ++i)
                {
                    book = parser.Books[i];
                    dataGridView1.Invoke(
                        new Action(() =>
                            dataGridView1.Rows.Add(
                                i + 1, book.ImageBook, book.Title, "Читать")));
                }
            });
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;

            if (i < parser.Books.Count && e.ColumnIndex == 3)
            {
                richTextBox1.Text = await parser.GetHtmlAsync(parser.Books[i].Url);
                lblText.Text = parser.Books[e.RowIndex].Title;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Task.Run(async () => await SearchResut());
        }

        /*
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            Task.Run(async () => await SearchResut());
        }*/

        private async Task SearchResut()
        {
            lblWaitSearch.Invoke(new Action(() => lblWaitSearch.Visible = true));
            parser.BooksSearch.Clear(); //очистить список ранее найденных книг
            await parser.SearchAsync(tbSearch.Text);
            ShowResult();
            lblWaitSearch.Invoke(new Action(() => lblWaitSearch.Visible = false));
        }

        private void ShowResult()
        {
            rbtSearchText.Invoke(new Action (()=>rbtSearchText.Clear()));
            if (parser.BooksSearch.Count == 0)
            {
                rbtSearchText.Invoke(new Action(() => rbtSearchText.Text = parser.Code404error));
            }
            else
            {
                foreach (var book in parser.BooksSearch)
                {
                    rbtSearchText.Invoke(new Action(() => rbtSearchText.AppendText($"{book}\n\n")));
                }
            }
        }
    }
}
