// See https://aka.ms/new-console-template for more information

if (args.Length == 0)
{
    Console.WriteLine("Нет аргументов");
    Console.ReadKey();
    return;
}

else if(args.Length > 3)
{
    Console.WriteLine("слишком много аргументов (> 3)");
    return;
}

int a, b;
int.TryParse(args[0], out a);
int.TryParse(args[1], out b);

Console.WriteLine($"Выражение: {a} {args[2]} {b}");
switch (args[2])
{
    case "+":
        Console.WriteLine(a + b);
        break;
    case "-":
        Console.WriteLine(a - b);
        break;
    case "*":
        Console.WriteLine(a * b);
        break;
    case "/":
        if (b == 0)
            throw new DivideByZeroException();
        Console.WriteLine((double)a / (double)b);
        break;
    default:
        throw new Exception($"{args[2]} - нет такой операции!");
}
Console.ReadKey();
