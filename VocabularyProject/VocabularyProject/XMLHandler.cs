
using System.Xml.Linq;

namespace VocabularyProject
{
    internal class XMLHandler
    {
        public void Write(Vocabulary vocabulary)
        {
            var keys = vocabulary.Lexicon.Keys;

            XDocument doc = new XDocument();
            XElement dictionary = new XElement("vocabulary");
            foreach (string key in keys)
            {
                XElement word = new XElement("word");
                XAttribute wordNameAttr = new XAttribute("key", key);
                word.Add(wordNameAttr);
                XElement listTranslates = new XElement("translates");

                foreach (var translateValue in vocabulary.Lexicon[key])
                {
                    XElement valueElement = new XElement("translate", translateValue);
                    listTranslates.Add(valueElement);
                }

                word.Add(listTranslates);
                dictionary.Add(word);
            }
            doc.Add(dictionary);
            doc.Save(vocabulary.Path);
        }
        public void ExportWord(string keyWord, IEnumerable<string> translates)
        {
            XDocument doc = new XDocument();
            XElement word = new XElement("word");
            XAttribute keyAttr = new XAttribute("key", keyWord);
            word.Add(keyAttr);
            XElement listTranslates = new XElement("translates");

            foreach (string translateValue in translates)
            {
                XElement valueElement = new XElement("translate", translateValue);
                listTranslates.Add(valueElement);
            }
            word.Add(listTranslates);
            doc.Add(word);
            doc.Save($"{keyWord}.xml");
            Console.WriteLine($" {keyWord}.xml создан!");
        }

        public void Read(Vocabulary vocabulary)
        {
            List<string> translates;
            XDocument xml = XDocument.Load(vocabulary.Path);

            foreach (XElement word in xml.Element("vocabulary").Elements("word"))
            {
                translates = new List<string>();
                XAttribute wordAttr = word.Attribute("key");
                foreach (var transl in word.Element("translates").Elements("translate"))
                {
                    translates.Add(transl.Value);
                }
                vocabulary.AddWord(wordAttr.Value, translates);
            }
        }
    }
}
