// See https://aka.ms/new-console-template for more information

/*
 * Три туриста вышли паралельно.
 * Каждому передать по рюкзаку.
 * Отображение через консоль.
 * Например (Турист Иван прошел 230 шагов.
 * С рюкзаком Походным, в рюкзаке находится котелов, теплая куртка, вода)
*/

using HikeApp;
using HikeApp.BackPacks;

Tourist tourist1 = new Tourist(
    "Иван",
    "Турист",
     new CampingBackPack
        ("веревки, консервы, котелок, вода, палатка, спальник, эльфийка"),
     1000
    );

Tourist tourist2 = new Tourist(
    "Альберт",
    "Любитель",
     new UrbanBackPack
        ("бургеры, вода, карта"),
     500
    );

Tourist tourist3 = new Tourist(
    "Джон",
    "Спортсмен",
     new CampingBackPack
        ("кроссовки, допинг-коктейль, портативные колонки"),
     100
    );

void GoTrip(object obj)
{
    Tourist tourist = (Tourist)obj;
    while (true)
    {
        tourist.Steps++;
        Thread.Sleep(tourist.SpeedDelay);
    }
}

ParameterizedThreadStart ps = new ParameterizedThreadStart(GoTrip);

var tourThread1 = new Thread(ps);
var tourThread2 = new Thread(ps);
var tourThread3 = new Thread(ps);

tourThread1.IsBackground = true;
tourThread2.IsBackground = true;
tourThread3.IsBackground = true;

tourThread1.Start(tourist1);
tourThread2.Start(tourist2);
tourThread3.Start(tourist3);

bool isStop = false;

Task.Run(() =>
    {
        while (!isStop)
        {
            if (Console.ReadKey().Key == ConsoleKey.Escape)
                isStop = true;
            Thread.Sleep(1000);
        }
    });

while (!isStop)
{
    Console.Clear();
    Console.WriteLine("ESC - выйти\n");
    Console.WriteLine(tourist1);
    Console.WriteLine(tourist2);
    Console.WriteLine(tourist3);
    Thread.Sleep(2000);
}


