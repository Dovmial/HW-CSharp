// See https://aka.ms/new-console-template for more information

using VocabularyProject;
UserInterface ui = new UserInterface();

int minChoose = 1, maxChoose = 2;
int choose;

START:
ui.MainMenu();
while (true)
{
    choose = ui.getAnswear(minChoose, maxChoose);

    if (choose == -1)
        Console.WriteLine("Некорректный выбор\n");
    else
        break;
}

TypeVocabulary type = (TypeVocabulary)Enum.ToObject(typeof(TypeVocabulary), choose);
using (Vocabulary vocabulary = new Vocabulary(type))
{
    bool isWork = true;
    while (isWork)
    {
        ui.SecondMenu();
        choose = ui.getAnswear(minChoose = 0, maxChoose = 6);
        FunctionAction action = (FunctionAction)Enum.ToObject(typeof(FunctionAction), choose);

        switch (action)
        {
            case FunctionAction.EXIT:
                isWork = false;
                break;
            case FunctionAction.ADDWORD:
                {
                    Console.Write("\n  Слово: ");
                    string word = ui.GetString();
                    Console.WriteLine("\n  Добавьте перевод слова (# - для завершения):");
                    IEnumerable<string> listTranslates = new List<string>();
                    ui.GetCollection(listTranslates);
                    vocabulary.AddWord(word, listTranslates);
                    listTranslates = null;
                    break;
                }
            case FunctionAction.REPLACEWORD:
                {
                    Console.Write("\n  Слово: ");
                    string word = ui.GetString();
                    Console.Write("\n  Заменить на: ");
                    string newWord = ui.GetString();
                    vocabulary.Update(word, newWord);
                    break;
                }
            case FunctionAction.UPDATETRANSLATE:
                {
                    Console.Write("\n  Слово: ");
                    string word = ui.GetString();
                    Console.WriteLine("\n  Добавьте перевод слова (# - для завершения):");
                    IEnumerable<string> listTranslates = new List<string>();
                    ui.GetCollection(listTranslates);
                    foreach (var i in listTranslates)
                        Console.WriteLine();
                    ui.MenuTypeUpdateTranslate();
                    choose = ui.getAnswear(minChoose = 1, maxChoose = 2);
                    if (choose == 1)
                        vocabulary.Update(word, listTranslates, true);
                    else
                        vocabulary.Update(word, listTranslates, false);
                    listTranslates = null;
                    break;
                }
            case FunctionAction.FINDWORD:
                {
                    if (vocabulary.IsEmpty())
                    {
                        Console.WriteLine("  Словарь пуст.");
                        break;
                    }
                    Console.Write("\n Слово: ");
                    string word = ui.GetString();
                    IEnumerable<string>? translates = vocabulary.Find(word);
                    if (translates == null)
                        break;
                    translates.ToList().Sort();
                    foreach (string translat in translates)
                    {
                        Console.WriteLine($"\t{translat}");
                    }
                    break;
                }
            case FunctionAction.EXPORTWORD:
                {
                    if (vocabulary.IsEmpty())
                    {
                        Console.WriteLine("  Словарь пуст.");
                        break;
                    }
                    Console.Write("\n Слово: ");
                    string word = ui.GetString();
                    IEnumerable<string>? translates = vocabulary.Find(word);
                    vocabulary.ExportWord(word, translates);
                    
                    break;
                }
            case FunctionAction.BACK:
                goto START;
            default:
                break;
        }
    }
}