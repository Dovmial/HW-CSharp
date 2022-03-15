using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteCasino
{
    public class Player
    {
        public string Name { get; set; }
        public int Bet { get; set; }
        public int Credits { get; set; }
        public int Number { get; set; }
        public Player(int credits, int idx)
        {
            Credits = credits;
            Bet = 0;
            Number = -1;
            Name = $"Player {idx + 1}";
        }
    }
}
