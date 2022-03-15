namespace FibonacciiApp
{
    public partial class Form1 : Form
    {
        private int _delay; // ms задержка потока
        private ManualResetEventSlim eventSuspend;
        private CancellationTokenSource _cancelTokenSource;
        private Fibonacci _fibonacci;

        private ulong _min;
        private ulong _max;
        public Form1()
        {
            InitializeComponent();

            btnResume.Enabled = false;
            btnSuspend.Enabled = false;
            btnStop.Enabled = false;

            _delay = 500;
            eventSuspend = new ManualResetEventSlim(true);
            tbDelay.Text = _delay.ToString();

            _fibonacci = new Fibonacci();

        }

        /// <summary>
        /// Show in RichTextBox fibonacci numbers
        /// </summary>
        /// <param name="token"></param>
        private void PrintNumbers(CancellationToken token)
        {
            if (!ulong.TryParse(tbMin.Text, out _min))
                _min = 2;
            if (!ulong.TryParse(tbMax.Text, out _max))
                _max = ulong.MaxValue;

            var query = from f in _fibonacci.FibonacciList
                        where f >= _min && f <= _max
                        select f;

            lock (richTextBox1)
            {
                foreach (ulong numFibo in query)
                {
                    eventSuspend.Wait();
                    if (token.IsCancellationRequested)
                        break;
                    
                    richTextBox1.SetTextInvoke(numFibo.ToString());
                    
                    Thread.Sleep(_delay);
                }
            }
        }

        private async void btnFibonacci_Click(object sender, EventArgs e)
        {
            if(_cancelTokenSource != null)
                _cancelTokenSource.Cancel();
            
            _cancelTokenSource = new CancellationTokenSource();
            var token = _cancelTokenSource.Token;
            richTextBox1.Clear();

            btnSuspend.Enabled = true;
            btnStop.Enabled = true;

            await Task.Run(() => PrintNumbers(token));

            btnResume.Enabled = false;
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            if (eventSuspend.IsSet)
            {
                btnSuspend.Enabled = false;
                btnResume.Enabled = true;
                btnFibonacci.Enabled = false;
                eventSuspend.Reset();
            }
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            if (!eventSuspend.IsSet)
            {
                btnResume.Enabled = false;
                btnSuspend.Enabled = true;
                btnFibonacci.Enabled = true;
                eventSuspend.Set();
            }
        }

        private void btnDelay_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbDelay.Text, out _delay))
            {
                _delay = 1000;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            eventSuspend.Set();
            _cancelTokenSource.Cancel();
            btnResume.Enabled = false;
            btnSuspend.Enabled = false;
            btnFibonacci.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}