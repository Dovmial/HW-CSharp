using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseParts
{
    public class Basement: IPart
    {
        public float Cost { get; set; }
        public float State { get; set; }
        public Basement()
        {
            Cost = 8f;
            State = 0;
        }
        public override string ToString()
        {
            return $"\tBasement: {State/Cost*100}%";
        }
    }
}
