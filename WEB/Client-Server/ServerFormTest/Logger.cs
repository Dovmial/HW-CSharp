using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServerFormTest
{
     public  class Logger
    {
        public static object _lockObj = new object();
        public static void Write(ClientUser user)
        {
            lock (_lockObj)
            {
                string filename = "log.txt";
                File.AppendAllTextAsync(filename, user.ToString());
            }
        }
    }
}
