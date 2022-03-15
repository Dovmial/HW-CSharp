using TRally.Cars;
using TRally.Races;
using System.Threading;

namespace TRally.Handler
{
    public class RaceHandler
    {
        public Race Race { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();

        public static event Action? Start, Drive, End;
        public static event Action<double, int>? Ready;
        public int TimeInterval { get; set; }
        public RaceHandler(Race race, int timeInterval, List<Car> cars)
        {
            Race = race;
            Cars = cars;
            TimeInterval = timeInterval;
            EventsRegistration();
        }

        private void EventsRegistration()
        {
            foreach (Car car in Cars)
            {
                Start += car.Start;
                Ready += car.GoToStart;
                Drive += car.Drive;
            }
        }
        public void GoToStart()
        {
            Ready?.Invoke(Race.Length, TimeInterval);
        }
        public void StartRace()
        {
            Console.WriteLine("\n\tSTART!!!!");
            Start?.Invoke();
            Racing();
        }
        private void Racing()
        {
            for (int i = 1; ; ++i)
            {
                if (End != null)
                {
                    EndRace();
                    break;
                }
                Console.WriteLine($"\n{i}-th check point:");
                Drive?.Invoke();
                Console.WriteLine(RaceState());
                Thread.Sleep(2000);
            }
        }

        private void EndRace()
        {
            End?.Invoke();
        }

        public string RaceState()
        {
            string raceState = "";
            Cars.Sort((car1, car2) =>  car2.TraveledDistance.CompareTo(car1.TraveledDistance)) ;
            for(int i = 0; i < Cars.Count; ++i)
            {
                raceState += $"\t{i + 1} - {Cars[i].Name}: {Cars[i].StateInfo()}\n";
            }
            return raceState;
        }
    }
}
