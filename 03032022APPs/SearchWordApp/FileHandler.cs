using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SearchWordApp
{
    public class FileHandler
    {
        private readonly object _locker = new object();
        public string FilePath { get; set; }
      
        public async ValueTask<int> CountWordAsync(string word)
        {
            int count = 0;
            await Task.Run(() =>
            {
                lock (_locker)
                {
                    using (var file = File.OpenText(FilePath))
                    {
                        string? line;
                        while ((line = file.ReadLine()) != null)
                        {
                            foreach (string w in line.Split(' '))
                            {
                                if (w.ToLower() == word)
                                    ++count;
                            }
                        }
                    }
                }
            });
            return count;
        }
    }
}
