using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseParts
{
    public class Roof : IPart
    {
        public float State { get; set; }
        public float Cost { get; set; }
        public Roof()
        {
            State = 0;
            Cost = 5f;
        }
        public override string ToString()
        {
            return $"\tRoof: {State / Cost * 100}%";
        }
    }
}
