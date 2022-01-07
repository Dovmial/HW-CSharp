using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseParts;

namespace Brigade
{
    public interface IWorker
    {
        IPart checkHouseState(House house);
    }
}
