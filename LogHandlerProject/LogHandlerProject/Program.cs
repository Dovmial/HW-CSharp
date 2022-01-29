using System;

namespace LogHandlerProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = LogHandler.LogStringHandler(LogHandler.GetLogString("log.txt"));
            LogHandler.WriteToFile(data, "Data.txt" );
        }
    }
}
