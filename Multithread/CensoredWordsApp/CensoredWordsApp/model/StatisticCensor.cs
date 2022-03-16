using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensoredWordsApp.model
{
    public class StatisticCensor
    {
        public Dictionary<FileInfo, int> FileInfos { get; set; } = new Dictionary<FileInfo, int>();
        public Dictionary<string, int> CountsCensoredWords { get; set; } = new Dictionary<string, int>();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Censored files: {FileInfos.Count}\n");
            var sorted = CountsCensoredWords.OrderByDescending(x => x.Value);
            foreach (var kvp in sorted)
                sb.Append($"{kvp.Key}: {kvp.Value}\n");
            sb.Append($"\n\nabout file:\n");
            foreach(var fileName in FileInfos)
            {
                sb.Append($"File name: {fileName.Key.Name}:\n replaces: {fileName.Value}\n");
                sb.Append($"\tpath: {fileName.Key.FullName}\n\tsize: {fileName.Key.Length} bytes\n\n");
            }

            return sb.ToString();
        }

        public void Reset()
        {
            CountsCensoredWords.Clear();
            FileInfos.Clear();
        }
    }
}
