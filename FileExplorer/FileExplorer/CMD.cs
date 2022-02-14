using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FileExplorer
{
    public delegate bool FunctionCMD(string[] argList);
    enum CommandNames { EXIT, CD, LS, HELP };
    public class CMD
    {
        public DirectoryInfo CurrentDirectory { get; set; }
        public List<Command> Commands { get; private set; }
        public CMD(string path)
        {
            CurrentDirectory = new DirectoryInfo(path);
            Commands = new List<Command>()
            {
                new Command("cd", "Смена текущего каталога", Cd),
                new Command("ls", "Отобразить содержимое каталога", Ls),
                new Command("help", "Справка", Help),
                new Command("exit", "Выход", Exit),
            };
        }
        public void CommandHandler()
        {
            string[] argList = { "help" };
            Help(argList);
            do
            {
                argList = GetCommandLine();
                switch (argList[0].ToLower())
                {
                    case "cd":
                        Cd(argList);
                        break;
                    case "ls":
                        Ls(argList);
                        break;
                    case "help":
                        Help(argList);
                        break;
                    case "exit":
                        Exit(argList);
                        break;
                    case "":
                        continue;
                    default:
                        Console.WriteLine($"  {argList[0]} - неизвестная команда");
                        break;
                }

            } while (true);
        }

        private string[] GetCommandLine()
        {
            Console.Write($"{CurrentDirectory.FullName}>>> ");
            var command = Console.ReadLine();
            command ??= "";

            command = command.ToLower().Trim();
            return command.Split(' ');
        }

        /// <summary>
        /// не реализовано комбинирование перехода через несколько папок (../../../)
        /// </summary>
        /// <param name="argList"></param>
        /// <returns></returns>
        public bool Cd(string[] argList)
        {
            if (!CheckCountArgList(argList, 2))
                return false;
            string path = argList[1];
            switch (path)
            {
                case "..":
                case @"\..":
                    CurrentDirectory = Directory.GetParent(Path.GetFullPath(CurrentDirectory.FullName));
                    return true;
            }
            if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory() + path.ToLower())))
            {
                CurrentDirectory = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory() + path));
                return true;
            }
            else if (Directory.Exists(path))
            {
                CurrentDirectory = new DirectoryInfo(path);
                return true;
            }
            Console.WriteLine("\tУказан неверный путь.");
            return false;
        }

        public bool Ls(string[] argList)
        {

            if (!CheckCountArgList(argList, 1))
                return false;

            var subDirectories = CurrentDirectory.GetDirectories();
            var files = CurrentDirectory.GetFiles();
            foreach (var dir in subDirectories)
            {
                Console.WriteLine($"{dir.CreationTime}: {dir.Name}");
            }
            foreach (var file in files)
            {
                Console.WriteLine($"{file.CreationTime}: {file.Name} - {file.Length} bytes");
            }
            Console.WriteLine($"\n  Директорий: {subDirectories.Length}\tФайлов: {files.Length}");
            return true;
        }

        public bool Help(string[] argList)
        {
            if (!CheckCountArgList(argList, 1))
                return false;
            Console.WriteLine("  Help:");
            foreach (var command in Commands)
            {
                Console.WriteLine($"\t{command.Name} -\t{command.Description}");
            }
            Console.WriteLine();
            return true;
        }

        public bool Exit(string[] argList)
        {
            Environment.Exit(0);
            return true;
        }

        /// <summary>
        /// проверка на лишние арументы строки
        /// </summary>
        /// <param name="argList">список аргументов</param>
        /// <param name="count">проверяемый индекс лишнего аргумента</param>
        /// <returns></returns>
        private bool CheckCountArgList(string[] argList, int count)
        {
            if (argList.Length > count)
            {
                Console.WriteLine($"неизвестный аргумент - {argList[count]}\n");
                return false;
            }
            return true;
        }
    }
}
