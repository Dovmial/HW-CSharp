using System;
using System.Linq;

namespace ConsoleCSharp28_10_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Task2();
            Task3();
            Task4();
            Task5();
        }

        static void Task2()
        {
            Console.WriteLine("\t\t####-- Task2 --####\n");
            int m, n;
            Console.Write("M = ");
            m = int.Parse(Console.ReadLine());
            Console.Write("N = ");
            n = int.Parse(Console.ReadLine());

            int[] arr1 = new int[m];
            int[] arr2 = new int[n];

            Random random = new Random();
            for (int i = 0; i < m; ++i)
                arr1[i] = random.Next(50);
            for (int i = 0; i < n; ++i)
                arr2[i] = random.Next(50);

            int minSize = m < n ? m : n;

            int[] arr3 = new int[minSize];
            Array.Fill(arr3, -1);
            int countElements = 0;


            foreach (int el in arr1)
                if (arr2.Contains(el))
                {
                    if (!arr3.Contains(el))
                        arr3[countElements++] = el;

                }

            Array.Sort(arr1);
            Array.Sort(arr2);
            Console.Write("Arr1: ");
            printArr(arr1);
            Console.Write("Arr2: ");
            printArr(arr2);

            Array.Resize(ref arr3, countElements);
            Console.Write("Arr3: ");
            printArr(arr3);
        }
        static void Task3()
        {
            Console.WriteLine("\t\t####-- Task3 --####\n");
            Console.WriteLine("Введите строку.");
            string inputStr = Console.ReadLine().Replace(" ", "").ToLower();

            string palindrom = new string(inputStr.ToCharArray().Reverse().ToArray());

            if (palindrom.ToLower().Equals(inputStr))
                Console.WriteLine("\tСтрока - палиндром\n");
            else
                Console.WriteLine("\tОбычная строка\n");
        }
        static void Task4()
        {
            Console.WriteLine("\t\t####-- Task4 --####\n");
            Console.WriteLine("Введите строку.");

            string inputStr = Console.ReadLine().Trim(' ', '.', ',', '?', '!', '\n', ';', '[', ']');

            int countWords = 0;
            for (int i = 0; i < inputStr.Length;)
            {
                if (Char.IsLetterOrDigit(inputStr[i]))
                {
                    while (Char.IsLetterOrDigit(inputStr[i++]))
                    {
                        if (i == inputStr.Length)
                            break;
                    }
                    ++countWords;
                    continue;
                }
                ++i;
            }
            Console.WriteLine($"\tКоличество слов: {countWords}\n");
        }
        static void Task5()
        {
            Console.WriteLine("\t\t####-- Task5 --####\n");
            int[,] arr2D = new int[5, 5];
            Random random = new Random();

            for (int i = 0; i < arr2D.GetLength(0); ++i)
                for (int j = 0; j < arr2D.GetLength(1); ++j)
                    arr2D[i, j] = random.Next(-100, 100);

            int minValueIndexI, minValueIndexJ, maxValueIndexI, maxValueIndexJ;
            minValueIndexI = minValueIndexJ = maxValueIndexI = maxValueIndexJ = 0;

            int min, max;
            min = max = arr2D[0, 0];
            for (int i = 0; i < arr2D.GetLength(0); ++i)
            {
                for (int j = 0; j < arr2D.GetLength(1); ++j)
                {
                    if (min > arr2D[i, j])
                    {
                        minValueIndexI = i;
                        minValueIndexJ = j;
                        min = arr2D[i, j];
                    }
                    if (max < arr2D[i, j])
                    {
                        maxValueIndexI = i;
                        maxValueIndexJ = j;
                        max = arr2D[i, j];
                    }
                }
            }
            printArr2D(arr2D, min, max);
            Console.WriteLine();
            Console.WriteLine($"Min: {min}\tMax: {max}");

            int startI, startJ, endI, endJ;

            if (minValueIndexI * 5 + minValueIndexJ < maxValueIndexI * 5 + maxValueIndexJ)
            {
                startI = minValueIndexI;
                startJ = minValueIndexJ;
                endI = maxValueIndexI;
                endJ = maxValueIndexJ;
            }
            else
            {
                startI = maxValueIndexI;
                startJ = maxValueIndexJ;
                endI = minValueIndexI;
                endJ = minValueIndexJ;
            }

            int sum = 0;
            for (int i = 0; i < 5; ++i)
                for (int j = 0; j < 5; ++j) 
                    if ( ((i * 5 + j) > (startI * 5 + startJ)) && ((i * 5 + j) < (endI * 5 + endJ)))
                        sum += arr2D[i, j];

            Console.WriteLine($"Сумма элементов между ({min}, {max}): {sum}\n");

        }
        static void printArr(int[] arr)
        {
            foreach (int i in arr)
                Console.Write($"{i} ");
            Console.WriteLine();
        }

        static void printArr2D(int[,] arr, int min, int max)
        {
            for (int i = 0; i < arr.GetLength(0); ++i)
            {
                for (int j = 0; j < arr.GetLength(1); ++j)
                {
                    if(arr[i,j] == min || arr[i,j] == max)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($"{arr[i, j]} ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.Write($"{arr[i, j]} ");
                }  
                Console.WriteLine();
            }
        }
    }
}
