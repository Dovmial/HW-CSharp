namespace RouletteCasino
{
    public partial class Form1 : Form
    {
        private Random _random;
        private GameHandler _gameHandler;

        private List<Label> lblCredits;
        private List<Label> lblBets;
        private List<Label> lblNumbers;

       
        public Form1(Random random)
        {
            InitializeComponent();
            _random = random;

            _gameHandler = new GameHandler(_random);
            _gameHandler.PlayerLoseEvent += PlayerLoseMessage;
            _gameHandler.PlayerWinEvent += PlayerWinMessage;

            btnSpin.Enabled = false;

            InitFormLabels();
        }


        private void InitFormLabels()
        {
            lblCredits = new List<Label>(_gameHandler.CountPlayers)
            {
                lblCredit1, lblCredit2, lblCredit3, lblCredit4, lblCredit5
            };
            lblBets = new List<Label>(_gameHandler.CountPlayers)
            {
                lblBet1, lblBet2, lblBet3, lblBet4, lblBet5
            };
            lblNumbers = new List<Label>(_gameHandler.CountPlayers)
            {
                lblNumber1, lblNumber2, lblNumber3, lblNumber4, lblNumber5
            };

            for (int i = 0; i < _gameHandler.CountPlayers; ++i)
            {
                lblBets[i].Text = "0";
                lblCredits[i].Text = $"${_gameHandler.Players[i].Credits}";
            }
        }

        private async void btnDoBet_Click(object sender, EventArgs e)
        {
            btnSpin.Enabled = true;
            btnDoBet.Enabled = false;

            await Task.Run(() => { _gameHandler.DoBetAsync(); });

            UpdateInfo();
        }

        private async void btnSpin_Click(object sender, EventArgs e)
        {
            await _gameHandler.SpinAsync(lblGameNumber);
            btnDoBet.Enabled = true;
            btnSpin.Enabled = false;
            await CheckResultSpinAsync();

            UpdateInfo();
        }

        private async Task CheckResultSpinAsync()
        {
            _gameHandler.GetSpinResults();

            await Task.Run(() =>
            {
                int size = _gameHandler.CountPlayers;
                for (int i = 0; i < size; ++i)
                {
                    lblCredits[i].SetTextInvoke($"${_gameHandler.Players[i].Credits}");
                    lblBets[i].SetTextInvoke($"${_gameHandler.Players[i].Bet}");
                }
            });
        }

        private void PlayerLoseMessage(Player player)
        {
            Task.Run(() => {MessageBox.Show($"{player.Name} выбыл. Новый игрок"); });
        }

        private void PlayerWinMessage(Player player)
        {
            Task.Run(() => { MessageBox.Show($"{player.Name} победил!"); });
        }
        private void UpdateInfo()
        {
            int size = _gameHandler.Players.Count;
            for (int i = 0; i < size; ++i)
            {
                lblCredits[i].SetTextInvoke($"${_gameHandler.Players[i].Credits}");
                lblNumbers[i].SetTextInvoke(_gameHandler.Players[i].Number.ToString());
                lblBets[i].SetTextInvoke($"${_gameHandler.Players[i].Bet}");
            }
        }
    }
}