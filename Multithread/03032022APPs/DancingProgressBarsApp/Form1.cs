using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace DancingProgressBarsApp
{
    public partial class Form1 : Form
    {
        private int _countProgressBars;
        private Point _startPointProgressBars = new Point(224, 12);
        private int _stepY;
        private Random _random;

        private List<ProgressBar> _progressBars = new List<ProgressBar>();
        public Form1()
        {
            InitializeComponent();
            _countProgressBars = 0;
            _stepY = 29;
            btnStartProgressBars.Enabled = false;
            btnReset.Enabled = false;
            _random = new Random();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbCountProgressBars.Text, out _countProgressBars))
                return;
            if (_countProgressBars == 0)
                return;
            InitProgressBars(_countProgressBars);
            btnStartProgressBars.Enabled = true;
            tbCountProgressBars.Enabled = false;
            btnCreate.Enabled = false;
        }

        private void InitProgressBars(int count)
        {
            for (int i = 0; i < count; ++i)
            {
                _progressBars.Add(
                    new ProgressBar()
                    {
                        Location = new Point(
                            _startPointProgressBars.X,
                            _startPointProgressBars.Y + i * _stepY),
                        Width = 196,
                        Style = ProgressBarStyle.Continuous,
                        ForeColor = Color.FromArgb(
                            _random.Next(256),
                            _random.Next(256),
                            _random.Next(256))
                    });
                Controls.Add(_progressBars[i]);
            }
        }

        private async void btnStartProgressBars_Click(object sender, EventArgs e)
        {
            btnStartProgressBars.Enabled = false;
            btnStartProgressBars.Enabled = false;

            await Task.Run(() =>
            {
                int delay = 100;
                Parallel.ForEach(_progressBars, pb => LoadedProgressBarsAsync(pb, delay));
            });
            btnReset.Enabled = true;
        }

        private void LoadedProgressBarsAsync(ProgressBar pb, int sleepMS)
        {
            Random random = new Random();

            int step = random.Next(1, 6);
            while (pb.Value < pb.Maximum)
            {
                if (pb.Value + step > 100)
                    step = 100 - pb.Value;
                pb.IncrementInvoke(step);
                Thread.Sleep(sleepMS);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearProgressBars();
            btnCreate.Enabled = true;
            tbCountProgressBars.Enabled = true;
            btnReset.Enabled = false;
        }
        private void ClearProgressBars()
        {
            foreach (ProgressBar pb in _progressBars)
                Controls.Remove(pb);
            _progressBars.Clear();
        }
    }
}
