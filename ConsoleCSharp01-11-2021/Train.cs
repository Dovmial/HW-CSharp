using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZHD
{
    partial class Train
    {
        public enum TrainType { PASSENGER, FREIGHT, MILITARY, SERVICE, HOSPITAL };
        string NameTrain { get; set; }
        string NumberTrain { get; set; }
        static public TrainType Type { get; set; }
        public int CountCarriages { get; set; }
        public int CountLocomotives { get; set; }
        public double Speed { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string FinishPoint { get; set; }
        public string StartPoint { get; set; }
        public string NextPoint { get; set; }
        public Train()
        {
            Type = TrainType.PASSENGER;
            ArrivalDate = DateTime.Now;
            DepartureDate = DateTime.Now;
            NextPoint = "";
            StartPoint = "";
            FinishPoint = "";
            NameTrain = "000000";
            Speed = 0;
            CountCarriages = 0;
            CountLocomotives = 1;
        }
        public Train(TrainType type_, string name_, string numberTrain_) : this()
        {
            Type = type_;
            NameTrain = name_;
            NumberTrain = numberTrain_;
        }
        static Train()
        {
            
        }
        public void addCarriage(int num)
        {
            CountCarriages += num;
        }
        public void removeCarriage(int num)
        {
            if (num > CountCarriages)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error. Incorrect number of carriage\n");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            CountCarriages -= num;
        }
        public void addLocomotive(int num)
        {
            CountLocomotives += num;
        }
        public void removeLocomotives(int num)
        {
            if (num >= CountLocomotives)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error. Incorrect number of locomotives\n");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            CountLocomotives -= num;
        }


    }
}
