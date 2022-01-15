using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRally.Races
{
    public class Race
    {
        /// <summary>
        /// Kilometers
        /// </summary>
        public double Length { get; private set; }
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="length">kilometers</param>
        public Race(string name, double length)
        {
            Name = name;
            Length = length;
        }
    }
}
