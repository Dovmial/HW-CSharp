// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

void Task1(bool start)
{
    if (start == false)
        return;

    string pathToProcess = "notepad.exe";

    Process process = new Process();
    process.StartInfo.FileName = pathToProcess;
    process.Start();
    Console.WriteLine($"Процесс запущен");
    process.WaitForExit();
    Console.WriteLine($"Handle = {process.Id}");
    Console.WriteLine($"Код завершения {process.ExitCode}");
}

void Task2(bool start)
{

    if (start == false)
        return;

    Process process = new Process();
    string pathToProcess = "notepad.exe";
    process.StartInfo.FileName = pathToProcess;
    process.Start();

    Console.WriteLine("1 - ожидать процесс\n" +
        "2 - Закрыть процесс");

    ConsoleKeyInfo key = Console.ReadKey(true);


    if (ConsoleKey.D1 == key.Key || ConsoleKey.NumPad1 == key.Key)
    {
        Console.WriteLine("ожидание...");
        Console.WriteLine($"Handle = {process.Id}");
        process.WaitForExit();
        Console.WriteLine($"Код завершения {process.ExitCode}");
    }
    else if (ConsoleKey.D2 == key.Key || ConsoleKey.NumPad2 == key.Key)
    {
        process.Kill();
        Console.WriteLine("процесс убит\n");
    }

}

void Task3(bool start)
{
    if (start == false)
        return;
    //путь к соседнему проекту в решении
    string pathToProcess = @"../../../../Calc/bin/Debug/net6.0/Calc1.exe";
    ProcessStartInfo startInfo = new ProcessStartInfo(pathToProcess);
    startInfo.Arguments = "4 8 /";
    Process.Start(startInfo);
    Console.ReadKey();
}

void Task4(bool start)
{
    if (start == false)
        return;

    string pathToProcess = @"..\..\..\..\FindWord\bin\Debug\net6.0\FindWord.exe";
    ProcessStartInfo startInfo = new ProcessStartInfo(pathToProcess);
    startInfo.Arguments = @"..\..\..\Text.txt while";
    Process.Start(startInfo);
    Console.ReadKey();
}

//Abort thread
void Task5(bool start)
{
    bool isWorking = true;
    var task = new ThreadStart(() =>
    {
        while (true)
        {
            Console.WriteLine(new String(' ', 15) + "second thread");
            Thread.Sleep(500);
        }
    });
    Thread secondThread = new Thread(task);
    secondThread.Start();

    while (isWorking)
    {
        Console.WriteLine("1 - остановить поток");
        ConsoleKeyInfo key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                secondThread.IsBackground = true;
                isWorking = false;
                break;
            default:
                Console.WriteLine(" неверный выбор");
                break;
        }
    }
}

Task1(false);
Task2(false);
Task3(false);
Task4(false);
Task5(true);

