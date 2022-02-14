using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer
{
    
    public class Command
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public FunctionCMD Function{get; set; }

        public Command(string name, string description, FunctionCMD function)
        {
            Name = name;
            Description = description;
            Function = function;
        }
    }
}
