
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LogHandlerProject
{
    public static class LogHandler
    {

        /// <summary>
        /// Итератор по лог-файлу
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetLogString(string path)
        {
            using (StreamReader log = File.OpenText(path))
            {
                for (string line = log.ReadLine(); line != null; line = log.ReadLine())
                {
                    yield return line;
                }
            }
        }
       
        public static IEnumerable<AnswearModel> LogStringHandler(IEnumerable<string> logString)
        {
            return 
                 from line in logString
                 let words = line.Split(' ')
                 where words[3] == "200"
                 group line by words[1] into g
                 select new AnswearModel
                 {
                     Ip = g.Key,
                     MaxAnswear = g.Max(a => int.Parse(a.Split(' ')[4])),
                     AverageAnswear = g.Average(a=>int.Parse(a.Split(' ')[4])),
                     SumAnswear = g.Sum(a=>int.Parse(a.Split()[4]))
                 };
        }

        public static void WriteToFile(IEnumerable<AnswearModel> query, string pathToWrite)
        {
            using (var file = File.AppendText(pathToWrite))
            {
                foreach (var group in query)
                {
                    file.WriteLine($"{group.Ip}:\n" +
                        $"\tmaxAnswear = {group.MaxAnswear}\n" +
                        $"\taverageAnswear = {group.AverageAnswear}\n" +
                        $"\tSumAnswear = {group.SumAnswear}\n");
                }
            }
        }
    }
}
