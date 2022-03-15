using System;
using Wonders;

namespace ConsoleCSharp_7Wonders_28_10_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Wonder[] sevenWonders = new Wonder[7];

            sevenWonders[0] = new Piramids();
            sevenWonders[1] = new ColossusRhodes();
            sevenWonders[2] = new HangingGardens();
            sevenWonders[3] = new LightHouseAlexandria();
            sevenWonders[4] = new MausoleumMausolus();
            sevenWonders[5] = new StatueZevs();
            sevenWonders[6] = new TempleArtemis();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            foreach(var won in sevenWonders)
            {
                Console.WriteLine(won.Description);
                ++Console.ForegroundColor;
            }
        }
    }
}
