using System;
using System.Windows.Forms;

namespace HorseRidingApp
{
    public class Horse
    {
        public string Name { get; set; }
        public bool IsRacing { get; set; }
        public int Place { get; set; }
        public int Speed { get; set; }
        public ProgressBar ProgressBarHorse { get; set; }
        public Label LabelHorse { get; set; }
        public Horse(ProgressBar pb, Label lbl, int idx)
        {
            Name = $"Horse {idx + 1}";
            Place = 0;
            Speed = 0;
            IsRacing = false;
            ProgressBarHorse = pb;
            LabelHorse = lbl;
        }

        public void HorseRun(Random random)
        {
            Speed = random.Next(1, 200);
        }

        public void Reset()
        {
            Place = 0;
            Speed = 0;
            IsRacing = false;
            ProgressBarHorse.Invoke(new Action(() => ProgressBarHorse.Value = 0));
            LabelHorse.Invoke(new Action(() => LabelHorse.Text = ""));
        }
    }
}
