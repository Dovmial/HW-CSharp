using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseParts;

namespace Brigade
{
    public class TeamLeader : IWorker
    {
        IPart IWorker.checkHouseState(House house)
        {
            throw new NotImplementedException();
        }

        public string createReport(House house)
        {
            string report = "Report:\n";
            foreach(IPart part in house)
            {
                report +=  part.ToString() + "\n";
            }
            return report + $"\nDone: {house.CompleteState()}%";
        }
    }
}
