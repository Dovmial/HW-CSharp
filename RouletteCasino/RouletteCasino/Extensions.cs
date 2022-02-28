using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteCasino
{
    static class Extensions
    {
        delegate void SetText(string text);
        public static void SetTextInvoke(this Label tb, string text)
        {
            tb.Invoke(new SetText(t => tb.Text = t), text);
        }

    }
}
