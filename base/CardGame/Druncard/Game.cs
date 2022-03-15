using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDrunkard
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public Card[] Deck { get; private set; } = new Card[36];
        private GameManager _gameManager;
        public Game(List<Player> players, Random random)
        {
            if (players.Count < 2)
                throw new ArgumentException("Player must be more then 1");
            if (random == null)
                throw new ArgumentNullException("Argument random is Null!");

            Players = players;
            InitDeck();
            
            _gameManager = new GameManager(Players, Deck, random);
        }
        private void InitDeck()
        {
            int index = 0;
            foreach (var face in Enum.GetValues(typeof(FaceValue)))
            {
                foreach (var suit in Enum.GetValues(typeof(Suit)))
                {
                    Deck[index] = new Card((FaceValue)face, (Suit)suit);
                    index++;
                }
            }
        }
        
        public void Start()
        {
            _gameManager.Shuffle();
            _gameManager.Deal();
            _gameManager.Start();
        }
       
        
    }
}
