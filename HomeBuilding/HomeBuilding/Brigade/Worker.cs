using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseParts;

namespace Brigade
{
    public class Worker : IWorker
    {
        public float JobEnergy { get; set; } //count of working
        private float _energy;
        public Worker(float job = 1f)
        {
            _energy = job;
            JobEnergy = _energy;
        }
        /// <summary>
        /// Construction status
        /// </summary>
        /// <param name="house"></param>
        /// <returns>IPart or null</returns>
        public IPart checkHouseState(House house)
        {
            IPart partToJob = null;
            foreach (IPart part in house)
            {
                if (part.State < part.Cost)
                {
                    partToJob = part;
                    break;
                }
            }
           return partToJob;
        }
        public void Creating(House house)
        {
            IPart part;
            while (JobEnergy > 0)
            {
                part = checkHouseState(house);
                if (part == null)
                {
                    house.Complete = true;
                    return;
                }
                float inProgress = part.Cost - part.State; //осталось построить
                if (inProgress >= JobEnergy)
                {
                    part.State += JobEnergy;
                    JobEnergy = 0;
                }
                else
                {
                    part.State += inProgress;
                    JobEnergy -= inProgress;
                }
            }
        }

        public void Rest()
        {
            JobEnergy = _energy;
        }
    }
}
