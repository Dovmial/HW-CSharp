using System;
using RZHD;

namespace RZHD
{
    partial class Train
    {
        public void info()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Model train: {NameTrain}\t" +
                $"Number Train: {NumberTrain}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Path: {StartPoint} -- {FinishPoint}");
            Console.Write($"Arrival time: {ArrivalDate}\t");
            Console.WriteLine($"Departure time: {DepartureDate}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

namespace ConsoleCSharp01_11_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] models = { "Sapsan", "TGV La Poste", "ЧС7-152", "Sokol", "Lastochka" };
            string[] numbers = { "6323", "7245", "6278", "5256", "5895" };
            string[] pathArrival = {
                "Москва","Екатеринбург Пасс", "СибирьПолис", "АляскаГрад",  "Новошамбалавск"};
            string[] pathDepart = {
                "Троя","Константинополь", "Карфаген", "Спарта",  "Мохенджо-Даро"};
            Train[] trains = new Train[5];
            for (int i = 0; i < 5; ++i)
            {
                trains[i] = new Train(Train.TrainType.PASSENGER, models[i], numbers[i]);
                trains[i].StartPoint = pathDepart[i];
                trains[i].FinishPoint = pathArrival[i];
            }

            foreach (var t in trains)
                t.info();
        }
    }
}
