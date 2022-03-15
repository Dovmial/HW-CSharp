// See https://aka.ms/new-console-template for more information

if(args.Length != 2)
{
    throw new ArgumentException("должно быть 2 аргумента");
}

IEnumerable<string> ReadString(string path)
{
    using (var file = File.OpenText(path))
    {
        string? str;
        while ((str = file.ReadLine()) != null)
        {
            yield return str;
        }
    }
}

/// <summary>
/// Количество найденных слов
/// </summary>
int count = 0;

var strings = ReadString(args[0]);
List<string> words = new List<string>();
foreach (string str in strings)
{
    words = str.Split(' ').ToList();
    foreach (string word in words)
    {
        if (word == args[1])
            ++count;
    }
}
Console.WriteLine($"Количество слов \"{args[1]}\": { count}");