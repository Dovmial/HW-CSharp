using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciiApp
{
    static class Extension
    {
        delegate void SetText(string text);
        public static void SetTextInvoke(this RichTextBox tb, string text)
        {
            tb.Invoke(new SetText(t => { tb.AppendText($"{t} "); }), text);
        }
    }
}
