using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseParts
{
    public interface IPart
    {
        float Cost { get; set; }
        float State { get; set; }

    }
}
