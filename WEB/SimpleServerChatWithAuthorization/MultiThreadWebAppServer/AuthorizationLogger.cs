using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer
{
    public class AuthorizationLogger
    {
        public string FilePath { get; set; } = "users.txt";

        public List<string> ReadFile()
        {
            if (File.Exists(FilePath))
            {
                return File.ReadAllLines(FilePath).ToList();
            }
            return new List<string>();
        }

        public void SaveData(string data)
        {
            File.AppendAllText(FilePath, $"{data}\n");
        }
    }
}
