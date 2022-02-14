using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FileExplorer
{
    
    public class Explorer
    {
        public CMD cmd { get; private set; }
        public Explorer()
        {
            cmd = new CMD(".");
            cmd.CommandHandler();
        }
       
    }
}
