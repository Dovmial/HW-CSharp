using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HouseParts;

namespace Brigade
{
    public class Team
    {
        private Worker[] _workers;
        private TeamLeader _teamLeader;
        public Team(int countBuilders)
        {
            _workers = new Worker[countBuilders];
            for (int i = 0; i < _workers.Length; ++i)
                _workers[i] = new Worker();
            
            _teamLeader = new TeamLeader();
        }
        public void Building(House house)
        {
            while (house.CompleteState() < 100)
            {
                foreach (Worker worker in _workers)
                {
                    worker.Creating(house);
                    if (house.Complete)
                    {
                        Console.WriteLine($"{_teamLeader.createReport(house)}\n\n\n");
                        return;
                    }  
                    worker.Rest();
                }
                
                Console.WriteLine($"{_teamLeader.createReport(house)}\n\n\n");
            }
        }
    }
}
