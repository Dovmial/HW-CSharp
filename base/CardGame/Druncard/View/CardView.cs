using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardGameDrunkard;

namespace CardGameDrunkard.View
{
    public static class CardView
    {
        private static string[] _nominal = { "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        public static void View(Card card)
        {
            switch (card.Suit)
            {
                case Suit.Diamonds:
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{_nominal[(int)card.FaceValue-6]}\u2666  ");
                    Console.ResetColor();
                    break;
                case Suit.Hearts:
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{_nominal[(int)card.FaceValue - 6]}\u2665  ");
                    Console.ResetColor();
                    break;
                case Suit.Clubs:
                    
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"{_nominal[(int)card.FaceValue - 6]}\u2663  ");
                    Console.ResetColor();
                    break;
                case Suit.Spades:
                   
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"{_nominal[(int)card.FaceValue - 6]}\u2660  ");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
