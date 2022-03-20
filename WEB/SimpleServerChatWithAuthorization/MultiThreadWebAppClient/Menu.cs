using System;

namespace ConsoleClient
{
    internal class Menu
    {
        public static void SignInMod(out char mod)
        {
            Console.WriteLine("\nАвторизация - 1\nРегистрация - 2");
            ConsoleKeyInfo choose = Console.ReadKey();
            switch (choose.Key)
            {
                case ConsoleKey.NumPad1:
                    Console.WriteLine("\nАвторизация:");
                    mod = 'a';
                    break;
                case ConsoleKey.NumPad2:
                    Console.WriteLine("\nРегистрация:");
                    mod = 'r';
                    break;
                default:
                    mod = 'q';
                    break;
            }
        }

        public static string GetData(char mod, out string userLogin)
        {
            if (mod == 'q')
            {
                userLogin = "";
                return $"{mod}";
            }
                
            Console.Write("\nВведите логин: ");
            userLogin = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string userParol = Console.ReadLine();
            return $"{mod}%{userLogin}%{userParol}";
        }
    }
}
