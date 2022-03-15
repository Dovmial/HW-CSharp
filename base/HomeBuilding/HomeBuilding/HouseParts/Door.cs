using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseParts
{
    public class Door : IPart
    {
        public float Cost { get; set; }
        public float State { get; set ; }
        public Door()
        {
            Cost = 0.5f;
            State = 0;
        }
        public override string ToString()
        {
            return $"\tDoor: {State / Cost * 100}%";
        }
    }
}
