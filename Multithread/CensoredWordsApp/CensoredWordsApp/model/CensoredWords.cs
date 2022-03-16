using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CensoredWordsApp.model
{
    public class CensoredWords
    {
        public string PathCensoredWords { get; set; }
        public List<string> CensoredWordsList = new List<string>();
    }
}
