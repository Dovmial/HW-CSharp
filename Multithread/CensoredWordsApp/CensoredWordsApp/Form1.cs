using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CensoredWordsApp.model;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace CensoredWordsApp
{
    public partial class Form1 : Form
    {

        private readonly object _lock = new object();
        CancellationTokenSource _tokenSource = new CancellationTokenSource();

        /// <summary>
        /// The folder with files to need checking
        /// </summary>
        private string? _pathStartFolder;

        private static StatisticCensor _statisticCensor = new StatisticCensor();

        /// <summary>
        /// the name of directory with founded temp files to need censor
        /// </summary>
        private string _directoryTempFiles = "Temp censored files";
        //private string _directoryCensoredFiles = "Temp Censored files";
        private CensoredWords _censoredWords = new CensoredWords();

        private DirectoryInfo _directoryWork;
        private DirectoryInfo _directoryTemp;

        /// <summary>
        /// pause threads
        /// </summary>
        private ManualResetEventSlim limiter = new ManualResetEventSlim(true);

        public Form1()
        {
            InitializeComponent();

            _directoryTemp = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), _directoryTempFiles));
            CreateWorkFolders();
        }

        private void CreateWorkFolders()
        {
            if (!_directoryTemp.Exists)
                _directoryTemp.Create();
        }

        private void btnDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _pathStartFolder = folderBrowserDialog1.SelectedPath;
                tbDirectoryPath.Text = _pathStartFolder;
                _directoryWork = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), _pathStartFolder));
            }
        }
        private void btnFileCensoredPath_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _censoredWords.PathCensoredWords = openFileDialog1.FileName;
                tbCensoredWordsSource.Text = _censoredWords.PathCensoredWords;
            }
        }
        private async void btnLoadCensoredWords_Click(object sender, EventArgs e)
        {
            if (_censoredWords.PathCensoredWords == null)
            {
                MessageBox.Show("Choose a filepath");
                return;
            }

            await Task.Run(() =>
            {
                char[] separators = { '.', ',', '\n', ';', ' ' };
                using (var file = File.OpenText(_censoredWords.PathCensoredWords))
                {
                    _censoredWords.CensoredWordsList = file
                        .ReadToEnd()
                        .Split(separators, StringSplitOptions.TrimEntries)
                        .Where(s => s != "")
                        .ToList();
                }
            });
            MessageBox.Show(string.Join('\n', _censoredWords.CensoredWordsList));
            label3.Text = $" {_censoredWords.CensoredWordsList.Count}";
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (_censoredWords.CensoredWordsList.Count == 0)
            {
                MessageBox.Show("Please, load censored words.");
                return;
            }
            if (_pathStartFolder == null)
            {
                MessageBox.Show("Choose path to files.");
                return;
            }
            Stopwatch stopwatch = Stopwatch.StartNew();

            await MoveFilesAsync(_tokenSource.Token);
            await CensorRunAsync(_tokenSource.Token);


            stopwatch.Stop();
            System.Diagnostics.Process.Start("explorer.exe", _directoryWork.FullName);
            MessageBox.Show(_statisticCensor.ToString());
            lblStopwatch.Text = stopwatch.Elapsed.ToString();
        }

        private async Task MoveFilesAsync(CancellationToken token)
        {
            var files = _directoryWork.EnumerateFiles("*.txt", SearchOption.AllDirectories);
            FileHandler fileHandler = new FileHandler();
            await Task.Run(() =>
            {
                Parallel.ForEach(files, file =>
                    {
                        try
                        {
                            if (fileHandler.IsExistWord(file.FullName, _censoredWords.CensoredWordsList, limiter, token))
                                file.MoveTo(Path.Combine(_directoryTemp.FullName, file.Name));
                        }
                        catch (OperationCanceledException ex)
                        {
                            MessageBox.Show("Operation is stopped");
                        }
                    });
            });
            if (token.IsCancellationRequested)
                return;
            progressBar1.Value = progressBar1.Maximum / 2;
        }

        private async Task CensorRunAsync(CancellationToken token)
        {
            FileHandler fileHandler = new FileHandler();
            FileInfo[] filesPath = _directoryTemp.GetFiles();

            await Task.Run(() =>
            {
                Parallel.ForEach(filesPath, file =>
                {
                    try
                    {
                        fileHandler.ReplaceCensor(
                            file,
                            new FileInfo(Path.Combine(_pathStartFolder, file.Name)),
                            _censoredWords.CensoredWordsList,
                            ref _statisticCensor,
                            limiter,
                            token);
                    }
                    catch (OperationCanceledException ex)
                    {
                        MessageBox.Show("Operation is stopped");
                    }
                });
            });
            if (token.IsCancellationRequested)
                return;
            progressBar1.Value = progressBar1.Maximum;
        }

        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            if (limiter.IsSet)
            {
                limiter.Reset(); // Pause
                label4.Text = "Status: Pause";
            }
            else
            {
                limiter.Set(); // Resume
                label4.Text = "Status: Work";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_tokenSource.IsCancellationRequested)
            {
                _tokenSource.Dispose();
                _tokenSource = new CancellationTokenSource();
                btnStop.Text = "Stop";
                return;
            }
            _tokenSource.Cancel();
            btnStop.Text = "Unblock";
        }

        private void btnClearStatistic_Click(object sender, EventArgs e)
        {
            _statisticCensor.Reset();
            progressBar1.Value = 0;        
        }
    }
}
