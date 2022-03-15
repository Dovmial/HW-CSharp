using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseParts
{
    public class Window: IPart
    {
        public float Cost { get; set; }
        public float State { get; set; }
        public Window()
        {
            Cost = 0.5f;
            State = 0;
        }
        public override string ToString()
        {
            return $"\tWindow: {State / Cost * 100}%";
        }
    }
}
