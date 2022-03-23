using System;
using System.Collections.Generic;
using System.Linq;

namespace UDPWinFormsClientEquipment
{
    public class TimeQueryHandler
    {
        public int LimitQuery {get; private set;} = 10;
        public List<DateTime> TimeQueries { get; private set; }

        public TimeQueryHandler()
        {
            TimeQueries = new List<DateTime>(LimitQuery);
        }

        /// <summary>
        /// Add Time current query
        /// </summary>
        public bool AddNowTime()
        {
            DateTime now = DateTime.Now;
            if(TimeQueries.Count > 0)
            {
                if(now > TimeQueries[0].AddHours(1.0))
                    TimeQueries = TimeQueries.Where(t => t < now.AddHours(-1.0)).ToList();

                if (TimeQueries.Count == LimitQuery)
                    return false;
            }
            TimeQueries.Add(now);
            return true;
        }
    }
}
