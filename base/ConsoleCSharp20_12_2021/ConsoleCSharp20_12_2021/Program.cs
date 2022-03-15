using System;

namespace ConsoleCSharp20_12_2021
{
    public enum Tasks { Complex = 1, NaturalFraction = 2, Exit = 0 };
    internal class Program
    {
        static void Task1() 
        {
            Complex z = new Complex(1, 1);
            Complex z1;
            z1 = z - (z * z * z - 1) / (3 * z * z);
            Console.WriteLine("\n\tz1 = {0}", z1);
        }
        static void Task2()
        {
            Fraction f = new Fraction(3, 4);
            int a = 10;
            Fraction f1 = f * a;
            Fraction f2 = a * f;
            double d = 1.5;
            Fraction f3 = f + d;

            Console.WriteLine($"\n\tf  = {f} ");
            Console.WriteLine($"\tf1 = f * 10 =  {f1}");
            Console.WriteLine($"\tf2 = 10 * f =  {f2}");
            Console.WriteLine($"\tf3 = f + 1.5 = {f3} = {f3.Reduction()}");
        }

        static void MainMenu()
        {
            Console.WriteLine("\n\t\tЗадачи:");
            Console.WriteLine("\t1 - комплексное число;");
            Console.WriteLine("\t2 - натуральная дробь;");
            Console.WriteLine("\t0 - выход;\n");

            Console.Write("\t>>> ");
            int choose = 0;
            int.TryParse(Console.ReadLine(), out choose);


            switch ((Tasks)choose)
            {
                case Tasks.Complex:
                    Task1(); break;

                case Tasks.NaturalFraction:
                    Task2(); break;

                case Tasks.Exit: Environment.Exit(0); break;

                default:
                    throw new ArgumentOutOfRangeException("выбрано неверное значение");
            }
        }
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    MainMenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
