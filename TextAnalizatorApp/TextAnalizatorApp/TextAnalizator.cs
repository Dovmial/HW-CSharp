using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalizatorApp
{
    public class TextAnalizator
    {
        public Statistic Statistic { get; set; } = new Statistic();

        public async ValueTask AnalizeAsync(string text)
        {
            await Task.Run(() =>
            {
                Statistic.Clear();
                Statistic.countChars = text.Length;
                Statistic.countWords = text.Split(' ').Length;
                foreach (char ch in text)
                {
                    if (ch == '.')
                        ++Statistic.countSentences;
                    else if (ch == '?')
                        ++Statistic.countInterrogativeSentence;
                    else if (ch == '!')
                        ++Statistic.countExclamatorySentences;
                }
                Statistic.countSentences += 
                    Statistic.countInterrogativeSentence +
                    Statistic.countExclamatorySentences;
            });
        }
    }
}
