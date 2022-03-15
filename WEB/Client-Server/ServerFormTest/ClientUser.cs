using System;
using System.Net;


namespace ServerFormTest
{
    public class ClientUser
    {
        public IPAddress Ip { get; private set; }
        public string message;
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; set; }

        public ClientUser(IPAddress ip, DateTime timeStart)
        {
            Ip = ip;
            DateStart = timeStart;
        }
        public override string ToString()
        {
            return $"{DateStart.ToLocalTime()}: Enter [{Ip}] {message} {DateEnd.ToLocalTime()} - Exit\n";
           
        }
    }
}
