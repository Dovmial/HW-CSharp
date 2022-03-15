using System;
using System.Collections.Generic;

namespace CustomStackProject
{
    public class Program
    {
        static void Print<T>(IEnumerable<T> collection)
        {
            Console.WriteLine();
            foreach (var s in collection)
            {
                Console.Write($"{s} ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            const int SIZE = 10;
            CustomStack<int> stack = new CustomStack<int>(SIZE);
            Random random = new Random();

            for (int i = 0; i < SIZE; ++i)
                stack.Put(random.Next(20));

            Print(stack);
            Console.WriteLine($"Stack overflow:");
            stack.Put(150000);
            Print(stack);
            stack.Put(123);
            Print(stack);

            Console.WriteLine($"Peek: {stack.Peek()}");
            Console.WriteLine($"Take: {stack.Take()}");

            Print(stack);
        }
    }
}
