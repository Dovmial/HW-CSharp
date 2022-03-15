using System;

namespace ConsoleCSharp25_10_2021
{
    //delegate double Distance(double x, double y);
    class Program
    {
        enum Tasks { EXIT, TASK1, TASK2, TASK3, TASK4, TASK5, TASK6, CLEAR = 100 };
        static void Main(string[] args)
        {
            while (true)
            {
                Tasks task = Menu(); //User choice
                taskSplitter();
                SetTextColorTASK();

                switch (task)
                {
                    case Tasks.TASK1:
                        Task1(); break;

                    case Tasks.TASK2:
                        Task2(); break;

                    case Tasks.TASK3:
                        Task3(); break;

                    case Tasks.TASK4:
                        Task4(); break;

                    case Tasks.TASK5:
                        Task5(); break;

                    case Tasks.TASK6:
                        Task6(); break;

                    case Tasks.EXIT:
                        return;
                    case Tasks.CLEAR:
                        Console.Clear(); break;
                    default:
                        Console.WriteLine("Error! This task is not existing"); break;
                }
                taskSplitter();
            }
        }

        //решения задач
        static void Task1()
        {
            SetTitleTask((int)Tasks.TASK1, "Count WhiteSpaces");

            Console.WriteLine("Enter string ['.' for end]:");
            int s = 0;
            int whiteSpace = 0;
            SetTextColorInput();

            while (s != '.')
            {
                s = Console.Read();
                if (s == ' ')
                    ++whiteSpace;
            }

            EndlineBufferReader();
            SetTextColorTASK();
            Console.WriteLine("\nWhiteSpaces: " + whiteSpace.ToString());
        }

        static void Task2()
        {
            SetTitleTask((int)Tasks.TASK2, "Lucky Ticket");
            Console.Write("Enter the number of a ticket (< 1'000'000): ");
            int numberTicket;

            SetTextColorInput();
            if (!int.TryParse(Console.ReadLine(), out numberTicket))
            {
                Console.WriteLine("Error! Incorrect data. Need a number!\n");
                return;
            }
            if (numberTicket > 999999 || numberTicket < 0)
            {
                Console.WriteLine("Error! Incorrect number\n");
                return;
            }

            String countZeros = "";
            for (int i = 100000; i > 1; i /= 10)
            {
                if (numberTicket / i == 0)
                    countZeros += "0";
            }
            String strNumberTicket = countZeros + numberTicket.ToString();
            int sumLeft, sumRight;
            sumLeft = sumRight = 0;

            for (int i = 0, j = 3; i < 3; ++i, ++j)
            {
                sumLeft  += (int)Char.GetNumericValue(strNumberTicket[i]);
                sumRight += (int)Char.GetNumericValue(strNumberTicket[j]);
            }

            SetTextColorTASK();
            string result = $"The ticket is {(sumLeft == sumRight ? "LUCKY!" : "ORDINARY")}";

            Console.WriteLine(result);
        }
        static void Task3()
        {
            SetTitleTask((int)Tasks.TASK3, "Change case");
            Console.WriteLine("Enter string.");
            SetTextColorInput();
            string str = Console.ReadLine();
            string result = "";
            for (int i = 0; i < str.Length; ++i)
            {
                if (Char.IsLower(str[i]))
                    result += (char)(str[i] - 32);
                else if (Char.IsUpper(str[i]))
                    result += (char)(str[i] + 32);
                else
                    result += str[i];
            }
            SetTextColorTASK();
            Console.WriteLine(result);
        }
        static void Task4()
        {
            SetTitleTask((int)Tasks.TASK4, "Fahrenheit -> Celsius");
            Console.Write("TF = ");
            SetTextColorInput();
            double TF = Double.Parse(Console.ReadLine());
            double TC = (TF - 32.0) * 5.0 / 9.0;
            SetTextColorTASK();
            Console.WriteLine($"TC = {TC}");
        }
        static void Task5()
        {
            SetTitleTask((int)Tasks.TASK5, "Triangle");
            Console.WriteLine("Enter apexs of a triangle");
            double [] coords = new double [6]; //x1,x2,x3,y1,y2,y3

            for(int i = 0; i<3; ++i)
            {
                    Console.Write($"Apex {i+1}: x{i+1} = ");
                    SetTextColorInput();
                    coords[i] = Double.Parse(Console.ReadLine());
                    SetTextColorTASK();
                    Console.Write($"Apex {i+1}: y{i+1} = ");
                    SetTextColorInput();
                    coords[i+3] = Double.Parse(Console.ReadLine());
                    SetTextColorTASK();
            }
            
            Func<double, double, double, double, double> Distance = (x1, y1, x2, y2)
                => Math.Sqrt(Math.Pow(x2 - x1, 2.0) + Math.Pow(y2 - y1, 2.0));
            double distanceA = Distance(coords[0], coords[3], coords[1], coords[4]); //AB -> a
            double distanceB = Distance(coords[1], coords[4], coords[2], coords[5]); //BC -> b
            double distanceC = Distance(coords[2], coords[5], coords[0], coords[3]); //CA -> c

            double perimetr = distanceA + distanceB + distanceC;
            double p = perimetr / 2.0;
            double sqwear = Math.Sqrt(p * (p - distanceA) * (p - distanceB) * (p - distanceC)); //Geron

            Console.WriteLine($"\nPerimetr = {perimetr} (units)\nSqwear = {sqwear} (sq. units)");
        }
        static void Task6()
        {
            SetTitleTask((int)Tasks.TASK6, "number -> word-string");
           
            int number;
            while (true)
            {
                Console.Write("Enter number [100 - 999]: ");
                SetTextColorInput();
                if (!int.TryParse(Console.ReadLine(), out number) || number < 100 || number > 999)
                {
                    Console.WriteLine("Error! incorrect input\n");
                    SetTextColorTASK();
                    continue;
                }
                SetTextColorTASK();
                break;
            }
            
            string[] hundreds = {
                "сто","двести","триста",
                "четыреста","пятьсот", "шестьсот",
                "семьсот", "восемьсот", "девятьсот" };
            string[] tens = {
                "двадцать", "тридцать", "сорок",
                "пятьдесят", "шестьдесят", "семьдесят",
                "восемьдесят", "девяносто" };
            string[] numbers20 = {
                "десять", "одиннадцать", "двенадцать",
                "тринадцать", "четырнадцать", "пятнадцать",
                "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
            string[] digits = { "",
                "один", "два", "три",
                "четыре", "пять", "шесть",
                "семь", "восемь", "девять" };

            string numberName = "";
            int digitHundred =  number / 100;
            numberName += hundreds[digitHundred-1];

            int remainder = number % 100;
            if(10 <= remainder && remainder < 20 )
            {
                numberName += $" {numbers20[remainder - 10]}";
            }
            else if (remainder < 10)
            {
                numberName += $" {digits[remainder]}";
            }
            else
            {
                int digitTen = remainder / 10;
                int digit = remainder % 10;
                numberName += $" {tens[digitTen - 2]} {digits[digit]}";
            }
            Console.WriteLine($"\n{number} - {numberName}");
        }

        //secondary functions
        static Tasks Menu()
        {
            SetTextColorMenu();
            Console.WriteLine("\n\t\tMAIN MENU");
            for (int i = 1; i < 7; ++i)
                Console.WriteLine($"{i} - Task {i}");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("100 - clear consol");
            Console.Write("\tStart task №");
            SetTextColorInput();

            Tasks answear = (Tasks)Int32.Parse(Console.ReadLine());

            return answear;
        }

        static void SetTextColorInput()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        static void SetTextColorTASK()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        static void SetTextColorMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static void EndlineBufferReader()
        {
            Console.Read();
            Console.Read();
        }

        static void taskSplitter()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n");
            for (int i = 0; i < 40; ++i)
                Console.Write("▒▓");
            Console.WriteLine("\n");
        }

        static void SetTitleTask(int task, String str)
        {
            Console.WriteLine($"\t\t\tTASK #{task} - {str}\n");
        }
    }
}
