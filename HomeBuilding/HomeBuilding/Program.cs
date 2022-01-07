using System;
using HouseParts;
using Brigade;
namespace HouseBuilding
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\t\tHouse building.");
            Console.Write("\n\tAmount of Workers: ");
            int countWorkers = int.Parse(Console.ReadLine());
            Team team = new Team(countWorkers);
            House house = new House();
            team.Building(house);
        }
    }
}
