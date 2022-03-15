using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRally.Cars.TypeCars
{
    public class PassengerCar : Car
    {
        public PassengerCar(string name, int maxSpeed, Random random)
            : base(name, maxSpeed, random)
        {
        }
    }
}
