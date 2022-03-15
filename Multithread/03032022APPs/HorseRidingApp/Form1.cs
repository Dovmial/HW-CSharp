using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace HorseRidingApp
{

    public partial class Form1 : Form
    {
        object lockObj = new object();
        event Action<Horse> _finishEvent;

        #region Random (save-thread)
        [ThreadStatic] static Random _random;
        private static Random _Random
        {
            get
            {
                if (_random == null)
                    return _random = new Random();
                return _random;
            }
        }
        #endregion

        private readonly int _count = 5;
        private List<ProgressBar> _progressBars;
        private List<Horse> _horses = new List<Horse>();
        private List<Label> _lblPlaces;
        private List<string> _finishList = new List<string>();

        public Form1()
        {
            _random = new Random();
            _finishEvent += HorseFinishEvent;
            InitializeComponent();
            InitLists();
            btnResetResults.Enabled = false;
        }
        private void InitLists()
        {
            _progressBars = new List<ProgressBar>(){
                pbHorse1, pbHorse2, pbHorse3, pbHorse4, pbHorse5
            };
            _progressBars.ForEach(p => p.Maximum = 10000);

            _lblPlaces = new List<Label>()
            {
                lblPlace1, lblPlace2, lblPlace3, lblPlace4, lblPlace5
            };
            _lblPlaces.ForEach(l => l.Text = "");

            for (int i = 0; i < _count; ++i)
                _horses.Add(new Horse(_progressBars[i], _lblPlaces[i], i));
        }
        private async void btnStartRiding_Click(object sender, EventArgs e)
        {
            btnStartRiding.Enabled = false;
            await Task.Run(() => Parallel.ForEach(_horses, (horse) => Riding(horse)));
            btnResetResults.Enabled = true;
        }

        private void Riding(Horse horse)
        {
            while (horse.ProgressBarHorse.Value < horse.ProgressBarHorse.Maximum)
            {
                horse.HorseRun(_Random);
                if (horse.ProgressBarHorse.Value + horse.Speed > horse.ProgressBarHorse.Maximum)
                    horse.Speed = horse.ProgressBarHorse.Maximum - horse.ProgressBarHorse.Value;

                horse.ProgressBarHorse.Invoke(new Action(() => horse.ProgressBarHorse.Increment(horse.Speed)));
                Thread.Sleep(100);
            }
            _finishEvent(horse);
        }

        private void HorseFinishEvent(Horse horse)
        {
            lock (lockObj)
            {
                _finishList.Add(horse.Name);
                horse.Place = _finishList.Count;
                rttResults.Invoke(
                    new Action(() =>
                        rttResults.AppendText($"{horse.Name}:   {horse.Place} place\n"))
                    );
            }
            horse.IsRacing = false;
            horse.LabelHorse.Invoke(new Action(() =>
                horse.LabelHorse.Text = horse.Place.ToString())
            );
        }

        private async void btnResetResults_Click(object sender, EventArgs e)
        {
            await Task.Run(() => ClearResults());

            btnResetResults.Enabled = false;
            btnStartRiding.Enabled = true;
        }

        private void ClearResults()
        {
            Parallel.Invoke(
                new Action(() => _horses.ForEach(horse => horse.Reset())),
                new Action(() => _finishList.Clear()),
                new Action(() => rttResults.Invoke(
                    new Action(() => rttResults.Clear())))
                );
        }
    }
}
