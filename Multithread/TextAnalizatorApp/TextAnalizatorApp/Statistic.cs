using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalizatorApp
{
    public class Statistic
    {
        public int countWords;
        public int countChars;

        public int countSentences;
        public int countInterrogativeSentence;
        public int countExclamatorySentences;

        public override string ToString()
        {
            return $"           Слов: {countWords}\n" +
                   $"       Символов: {countChars}\n" +
                   $"    Предложений: {countSentences}\n" +
                   $"Восклицательных: {countExclamatorySentences}\n" +
                   $" Вопросительных: {countInterrogativeSentence}\n";
        }

        public void Clear()
        {
            countWords = 0;
            countChars = 0;
            countSentences = 0;
            countExclamatorySentences = 0;
            countInterrogativeSentence = 0;
        }
    }
}
