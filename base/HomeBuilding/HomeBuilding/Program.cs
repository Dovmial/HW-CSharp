using System;
using HouseParts;
using Brigade;
using LoggerProject;

namespace HouseBuilding
{
    public class Program
    {
        static void Main(string[] args)
        {
            Logger logger = Logger.Instance();

            Console.WriteLine("\n\n\t\tHouse building.");
            Console.Write("\n\tAmount of Workers: ");
            
            int countWorkers = int.Parse(Console.ReadLine());
            Team team = new Team(countWorkers);
            House house = new House();

            logger.Logging(DateTime.Now, TypeMesssage.Info, "Alex", "Бригада приступает к строительству");
            team.Building(house);
            logger.Logging(DateTime.Now, TypeMesssage.Info, "Alex", "Бригада завершила постройку");
            
        }
    }
}
