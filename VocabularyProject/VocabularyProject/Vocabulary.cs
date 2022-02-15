using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyProject
{
    public class Vocabulary: IDisposable
    {
        public TypeVocabulary TypeTranslate { get; set; }
        public string Path { get; set; }
        private XMLHandler _xmlHandler;

        public SortedDictionary<string, IEnumerable<string>> Lexicon { get; set; }
              = new SortedDictionary<string, IEnumerable<string>>();
        public Vocabulary(TypeVocabulary type)
        {
            _xmlHandler = new XMLHandler();
            TypeTranslate = type;
            Path = new PathVocabulary().GetPath(type);

            if (File.Exists(Path))
                _xmlHandler.Read(this);
        }

        public void AddWord(string word, string translate)
        {
            string key = word.ToLower();
            if (!Lexicon.ContainsKey(key))
                Lexicon.Add(word.ToLower(), new List<string>() { translate });
        }
        public void AddWord(string word, IEnumerable<string> translates)
        {
            string key = word.ToLower();
            if (!Lexicon.ContainsKey(key))
                Lexicon.Add(word.ToLower(), translates);
        }
        public void AddTranslate(string word, string translale)
        {
            if (!Lexicon.ContainsKey(word.ToLower()))
            {
                Console.WriteLine("Сначала добавьте новое слово в словарь\n");
                return;
            }
            Lexicon[word] ??= new List<string>();
            Lexicon[word] = Lexicon[word].Append(translale);
        }
        public void Update(string word, string oldTranslate, string updateTranslate)
        {
            string key = word.ToLower();
            if (!Lexicon.ContainsKey(word.ToLower()))
            {
                Console.WriteLine("Сначала добавьте новое слово в словарь\n");
                return;
            }

            if (Lexicon[key].Contains(oldTranslate))
            {
                var list = Lexicon[key].ToList();
                list.Remove(oldTranslate);
                list.Add(updateTranslate);
                list.Sort();
                Lexicon[key] = list;
                list = null;
            }
            else
            {
                Console.WriteLine($"Ошибка! {oldTranslate} - не найдено слово");
            }

        }
        public void Update(string word, IEnumerable<string> translates, bool isConcatCollections = false)
        {
            string key = word.ToLower();
            if (!Lexicon.ContainsKey(key))
            {
                Console.WriteLine("Сначала добавьте новое слово в словарь\n");
                return;
            }
            if (isConcatCollections)
                Lexicon[key] = Lexicon[key].Concat(translates);
            else
                Lexicon[key] = translates;
        }

        public void Update(string word, string updateWord)
        {
            string key = word.ToLower();
            if (!Lexicon.ContainsKey(key))
            {
                Console.WriteLine("Сначала добавьте новое слово в словарь\n");
                return;
            }
            var data = Lexicon[key];
            Lexicon.Remove(key);
            Lexicon.Add(updateWord, data);
        }
        public IEnumerable<string>? Find(string word)
        {
            string key = word.ToLower();
            if (!Lexicon.ContainsKey(key))
            {
                Console.WriteLine("Слово не найдено!\n");
                return null;
            }
            return Lexicon[key];
        }
        public void ExportWord(string word, IEnumerable<string>? translates)
        {
            if(translates == null)
            {
                Console.WriteLine("  Список перевода пуст!");
                return;
            }
               
            _xmlHandler.ExportWord(word, translates);
        }
        public bool IsEmpty()
        {
            return Lexicon.Count == 0;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string word in Lexicon.Keys)
            {
                sb.Append($"  {word}:\n");
                foreach (string translatesList in Lexicon[word])
                {
                    sb.Append($"\t{translatesList}\n");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        private void Save()
        {
            _xmlHandler.Write(this);
        }
        public void Dispose()
        {
            Save();
        }
    }
}
