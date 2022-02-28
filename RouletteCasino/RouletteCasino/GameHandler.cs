using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteCasino
{
    public delegate void PlayerStatus(Player player);
    public class GameHandler
    {
        public event PlayerStatus PlayerLoseEvent;
        public event PlayerStatus PlayerWinEvent;
        public int CountPlayers { get; private set; }
        public int SpinGameNumber { get; private set; }
        public List<Player> Players;

        private Random _random;
        public GameHandler(Random random)
        {
            CountPlayers = 5;
            Players = new List<Player>(CountPlayers);
            _random = random;
            InitPlayers();
        }


        private void InitPlayers()
        {
            for (int i = 0; i < CountPlayers; ++i)
            {
                Players.Add(new Player(_random.Next(1, 1000), i));
            }
        }

        private void Bet(Player player)
        {
            player.Bet = _random.Next(0, player.Credits + 1);
            player.Credits -= player.Bet;
            player.Number = _random.Next(0, 51);
        }

        public void DoBetAsync()
        {
            new Thread(() => { Bet(Players[0]); }).Start();
            new Thread(() => { Bet(Players[1]); }).Start();
            new Thread(() => { Bet(Players[2]); }).Start();
            new Thread(() => { Bet(Players[3]); }).Start();
            new Thread(() => { Bet(Players[4]); }).Start();
        }
        public void GetSpinResults()
        {
            List<Task<bool>> tasks = new List<Task<bool>>
            {
                new Task<bool>(() => { return SpinResults(Players[0]); }),
                new Task<bool>(() => { return SpinResults(Players[1]); }),
                new Task<bool>(() => { return SpinResults(Players[2]); }),
                new Task<bool>(() => { return SpinResults(Players[3]); }),
                new Task<bool>(() => { return SpinResults(Players[4]); })
            };

            foreach (var task in tasks)
                task.Start();
            Thread.Sleep(50);

            //замена проигравшего
            for(int i = 0; i< tasks.Count; ++i)
            {
                if (tasks[i].Result)
                {
                    Players[i] = new Player(_random.Next(1, 1000), i);
                }
            }  
        }


        public async Task SpinAsync(Label lbl)
        {
            await Task.Run(() => Spin(lbl));
        }
        /// <summary>
        /// имитация выпадения числа
        /// </summary>
        /// <param name="lblGameNumber"></param>
        private void Spin(Label lblGameNumber)
        {
            for (int i = 0; i < 15; ++i)
            {
                SpinGameNumber = _random.Next(0, 51);
                lblGameNumber.SetTextInvoke(SpinGameNumber.ToString());
                Thread.Sleep(100);
            }
        }


        /// <summary>
        ///  расчеты раунда
        /// </summary>
        /// <param name="player"></param>
        private bool SpinResults(Player player)
        {
            if (CheckPlayerWin(player))
            { 
                player.Credits += 2 * player.Bet;
                PlayerWinEvent(player);
            }
               


            else if (CheckPlayerFailure(player))
            {
                if (PlayerLoseEvent != null)
                {
                    PlayerLoseEvent(player);
                }

                return true;
            }
            player.Bet = 0;
            return false;
        }

        /// <summary>
        /// Проверка на банкротство
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool CheckPlayerFailure(Player player)
        {
            return player.Credits == 0;
        }

        private bool CheckPlayerWin(Player player) => player.Number == SpinGameNumber;
    }
}
