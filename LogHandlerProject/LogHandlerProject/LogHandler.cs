
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using System.Text;

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

        public static IEnumerable<AnswearModel> LogStringHandler(IEnumerable<string> logStrings)
        {
            return
                 from line in logStrings
                 let words = line.Split(' ')
                 where words[3] == "200"
                 group line by words[1] into g
                 select new AnswearModel
                 {
                     Ip = g.Key,
                     MaxAnswear = g.Max(a => int.Parse(a.Split(' ')[4])),
                     AverageAnswear = g.Average(a => int.Parse(a.Split(' ')[4])),
                     SumAnswear = g.Sum(a => int.Parse(a.Split()[4]))
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

        public static void ToXML(IEnumerable<string> logStrings, string pathTo)
        {
            using (XmlTextWriter writer = new XmlTextWriter(pathTo, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;

                string[] parts;
                writer.WriteStartDocument();
                writer.WriteStartElement("Log");
               
                foreach (string line in logStrings)
                {
                    parts = line.Split(' ');
                    writer.WriteStartElement("Line");
                    writer.WriteElementString("Date_Time",    parts[0]);
                    writer.WriteElementString("IP_Address",   parts[1]);
                    writer.WriteElementString("Query",        parts[2]);
                    writer.WriteElementString("Answear_Code", parts[3]);
                    writer.WriteElementString("Answear_Size", parts[4]);
                    writer.WriteElementString("Answear_Time", parts[5]);
                    writer.WriteEndElement();
                }

               
                writer.WriteEndElement();
            }
        }
    }
}
