using System;

namespace LogHandlerProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var iterator = LogHandler.GetLogString("log.txt");
            var data = LogHandler.LogStringHandler(iterator);

            LogHandler.WriteToFile(data, "Data.txt" );
            LogHandler.ToXML(iterator, "log.xml");

        }
    }
}
