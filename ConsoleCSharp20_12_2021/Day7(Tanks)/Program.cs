using System;
using System.Collections.Generic;
using MyClassLib.WordOfTanks;

namespace Day7_Tanks_
{

    internal class Program
    {
        static public string Show(string name1, string name2)
        {
            string asciiImage =
                "\t     __|__" + "                  " + "    __|__\n" +
                "\t ___/** **\\=======#" + "    #=======/** **\\____\n" +
                $"\t/HH*{name1}*EE\\" + $"            :|EE*{name2}*HH;\n" +
                "\t(@=@=@=@=@=@=@)" + "            (@=@=@=@=@=@=@)";
            return asciiImage;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tWord of Tanks\n\n");
            List<Tank> t34Squad = new List<Tank>();
            List<Tank> pantherSquad = new List<Tank>();

            for (int i = 0; i < 5; ++i)
            {
                t34Squad.Add(new Tank("Т-34"));
                pantherSquad.Add(new Tank("Panther"));
            }

            int[] scores = { 0, 0 }; //счет
            BattleStatus result;
            string resultMessage;

            for (int i = 0; i < t34Squad.Count; ++i)
            {
                Console.WriteLine(Show(" T-34 ", "Panther") + '\n');

                result = t34Squad[i] * pantherSquad[i];

                switch (result)
                {
                    case BattleStatus.Win : 
                        ++scores[0];
                        resultMessage = "Победа: Т-34";
                        break;
                    case BattleStatus.Lose:
                        ++scores[1];
                        resultMessage = "Победа: Пантера";
                        break;
                    default:
                        resultMessage = "Обе машины проиграли";
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("T-34\n" + t34Squad[i].ToString() + '\n');
                Console.WriteLine("Panther\n" + pantherSquad[i].ToString() + '\n');
                Console.ResetColor();

                Console.WriteLine(resultMessage + "\n\n");
            }

            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine($"\t\tСчет\n\tТ-34\t\tПантеры\n\t {scores[0]} \t  :\t {scores[1]}\n");
            Console.ResetColor();
        }
    }
}
