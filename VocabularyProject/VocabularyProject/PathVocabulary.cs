using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyProject
{
    public class PathVocabulary
    {
        public  string EngRus { get; set; } = "eng-rus.xml";
        public  string RusEng { get; set; } = "rus-eng.xml";
        public  string GetPath(TypeVocabulary type)
        {
            switch (type)
            {
                case TypeVocabulary.EnglishToRussian:
                    return EngRus;
                case TypeVocabulary.RussianToEnglish:
                    return RusEng;
                default:
                    return EngRus;
            }
        }
    }
}
