using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDrunkard
{
    public class GameManager
    {
        public List<Player> Players { get; private set; }
        public Card[] Deck { get; private set; }

        private Random _random;

        public GameManager(List<Player> players, Card[] deck, Random random)
        {
            Players = players;
            foreach(var player in Players)
                HandlerGameEvents.Subscribing(player);
            Deck = deck;
            _random = random;
        }
        
        public void Deal()
        {
            int dealingCards = Deck.Length / Players.Count;

            for (int k = 0; k < Players.Count; k++)
            {
                for (int i = 0; i < dealingCards; i++)
                    Players[k].Cards.Enqueue(Deck[i + dealingCards * k]);
            }
        }
        public void Start()
        {
            List<Card> tableCards = new List<Card>();
            for (int i = 1; i<501 ; ++i)
            {
                Console.WriteLine($"\tRound {i}: ");
                
                tableCards.Clear();
                
                foreach (var player in Players)
                {
                    tableCards.Add(player.Give());
                }
                
                int index = tableCards.IndexOf(tableCards.Max());
                Players[index].Take(tableCards);
               
                
                for (int j=0; j<Players.Count; ++j)
                {
                    Console.WriteLine($"{Players[j].Cards.Count}");
                    if (Players[j].Cards.Count == 0) 
                    { 
                        HandlerGameEvents.Unsubscribing(Players[j]);
                        PlayerOut(Players[j]);
                        --j;
                    }
                } 
                HandlerGameEvents.EndRoundEvent();
                if (CheckEndGame() == true)
                {
                    ResultGame(Players.First(), i);
                    break;
                }
                Console.WriteLine("\nEnd of the round.");
                
                //Thread.Sleep(2000);
            }
        }
        public void Shuffle()
        {
            Deck = Deck.Shuffle(_random).ToArray();
        }
        private bool CheckEndGame()
        {
            return Players.Count == 1;
        }
        private void ResultGame(Player player, int countRounds)
        {
            Console.WriteLine($"\n\n\t\tGAME OVER\n\t\tWINNER: {Players.First().Name}");
            Console.WriteLine($"\t\tCount of rounds: {countRounds}");
        }
        private void PlayerOut(Player player)
        {
            Players.Remove(player);
        }

    }
}
