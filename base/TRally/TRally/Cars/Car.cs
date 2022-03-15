using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace TRally.Cars
{
    public abstract class Car
    {
        public int Speed { get; protected set; }
        public int MaxSpeed { get; set; }
        public string Name { get; set; }
        public double TraveledDistance { get; set; }
        
        public double TargetDistance { get; set; }

        protected Random _random;
        protected double _timeInterval;
        public Car(string name, int maxSpeed, Random random)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            Speed = 0;
            TraveledDistance = 0;
            TargetDistance = 0;
            _random = random;
        }
        public void Drive()
        {
            Speed = _random.Next(MaxSpeed+1);
            TraveledDistance += (double)Speed * (double)_timeInterval/60.0;
            if (TraveledDistance > TargetDistance)
                TraveledDistance = TargetDistance;
        }

        public void GoToStart(double targetDistance, int timeInterval)
        {
            TargetDistance = targetDistance;
            _timeInterval = timeInterval;
            Console.WriteLine($"{Name} ready!");
        }
        public void Start()
        {
            Console.WriteLine($"{ Name} started!");
        }
       
        public string StateInfo()
        {
            double procentageDistance = TraveledDistance / TargetDistance;
            string message = $"{procentageDistance.ToString("\t#0.##%", CultureInfo.InvariantCulture)}";
                
            if (procentageDistance >= 1)
            {
                procentageDistance = 1;
                Handler.RaceHandler.End += Finish;
            }
            return message;
        }
        public void Finish()
        {
            Speed = 0;
            Console.WriteLine($"\tWinner: {Name}\n");
        }
    }
}
