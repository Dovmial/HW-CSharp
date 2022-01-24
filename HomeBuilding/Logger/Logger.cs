using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoggerProject
{
   

    public class Logger //Singleton
    {
        private static Logger _instance;
        private List<MessageOfParametr> configParametrs = new List<MessageOfParametr>();
        public static Logger Instance()
        {
            if (_instance == null)
                _instance = new Logger();
            return _instance;
        }
        private Logger()
        {
            using (FileStream configFile = new FileStream("config.ini", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader config = new StreamReader(configFile, Encoding.UTF8))
                {
                    string line;
                    string[] parts;
                    while ((line = config.ReadLine()) != null)
                    {
                        parts = line.Split('=');
                        switch (parts[0])
                        {
                            case "date":
                                configParametrs.Add(
                                    new MessageOfParametr(parts[1] == "1", Parametrs.Date));
                                break;
                            case "typeMessage":
                                configParametrs.Add(
                                    new MessageOfParametr(parts[1] == "1", Parametrs.Type));
                                break;
                            case "userName":
                                configParametrs.Add(
                                    new MessageOfParametr(parts[1] == "1", Parametrs.UserName));
                                break;
                            case "message":
                                configParametrs.Add(
                                    new MessageOfParametr(parts[1] == "1", Parametrs.Messages));
                                break;
                        }
                    }
                }
            }
        }
        public void Logging(DateTime date, TypeMesssage type, string nameUser, string message)
        {
            foreach (var m in configParametrs)
            {
                switch (m.Parametr)
                {
                    case Parametrs.Date:
                        m.MessagePost = $"{date.ToLocalTime()} ";
                        break;
                    case Parametrs.Type:
                        m.MessagePost = $"{type} ";
                        break;
                    case Parametrs.UserName:
                        m.MessagePost = $"{nameUser} ";
                        break;
                    case Parametrs.Messages:
                        m.MessagePost = $"[{message}] ";
                        break;
                }
            }

            using (FileStream logFile = new FileStream("log.txt", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter log = new StreamWriter(logFile, Encoding.UTF8))
                {
                    foreach (var p in configParametrs)
                    {
                        if (p.Instance)
                            log.Write(p.MessagePost);
                    }
                    log.Write("\n\n");
                }
            }
        }
    }
}
