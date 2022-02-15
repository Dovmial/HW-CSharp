

namespace VocabularyProject
{
    public  class UserInterface
    {
        public void MainMenu()
        {
            Console.WriteLine("Выбор словаря:\n");
            Console.WriteLine("\t1 - Англо-Русский");
            Console.WriteLine("\t2 - Русско-Аглийский");
        }

        public int getAnswear(int minValue, int maxValue)
        {
            int choose;
            Console.Write("\n\t> ");
            if (int.TryParse(Console.ReadLine(), out choose)
                && choose >= minValue
                && choose <= maxValue)
                return choose;
            else
                return -1;
        }

        public void SecondMenu()
        {
            Console.WriteLine("\n\n  1 - Добавить новое слово в словарь");
            Console.WriteLine("  2 - Заменить слово");
            Console.WriteLine("  3 - Изменить перевод к слову");
            Console.WriteLine("  4 - Найти перевод");
            Console.WriteLine("  5 - Экспортировать слово с переводом в новый файл");
            Console.WriteLine("  6 - Назад (выбор словаря)");
            Console.WriteLine("  0 - Выход");
        }

        public string GetString()
        {
            string? str = Console.ReadLine();
            return str == null? "": str ;
        }

        public void GetCollection(IEnumerable<string> list)
        {
            string str;
            while ((str = Console.ReadLine()) != "#")
                (list as List<string>).Add(str);
        }

        public void MenuTypeUpdateTranslate()
        {
            Console.WriteLine("\t1 - Добавить перевод");
            Console.WriteLine("\t2 - Заменить перевод");
        }
    }
}
