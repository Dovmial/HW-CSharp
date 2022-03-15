// See https://aka.ms/new-console-template for more information
using TRally.Races;
using TRally.Handler;
using TRally.Cars;
using TRally.Cars.TypeCars;

Random random = new Random();
Race race = new Race("Rally Dakar", 150.0);

List<Car> cars = new List<Car>();
cars.Add(new Bus         ("Ikarus",     80,  random));
cars.Add(new Bus         ("PAZ",        65,  random));
cars.Add(new Bus         ("Gazel",      90,  random));
cars.Add(new SportCar    ("Bugati",     400, random));
cars.Add(new SportCar    ("Audi",       350, random));
cars.Add(new SportCar    ("Ferrari",    340, random));
cars.Add(new FreightCar  ("Kamaz",      120, random));
cars.Add(new FreightCar  ("Maz" ,       130, random));
cars.Add(new FreightCar  ("Zil" ,       110, random));
cars.Add(new PassengerCar("Lada" ,      210, random));
cars.Add(new PassengerCar("Toyota",     190, random));
cars.Add(new PassengerCar("Nissan",     230, random));

List<Car> carsContestant = new List<Car>();
int index = 0;
for (int i = 0; i < 4; ++i)
{
    index = random.Next(cars.Count);
    if (carsContestant.Contains(cars[index]))
    {
        --i;
        continue;
    }
    carsContestant.Add(cars[index]);
}

RaceHandler raceHandler = new RaceHandler(race, 5, carsContestant);
Console.WriteLine($"\t\tNew Race: {race.Name} - Distance: {race.Length}km\n");
raceHandler.GoToStart();
raceHandler.StartRace();
Console.WriteLine("The race was a success.\n");