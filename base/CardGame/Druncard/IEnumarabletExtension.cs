using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameDrunkard
{
    public static class IEnumarabletExtension
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rnd)
        {
            return source.OrderBy((item) => rnd.Next());
        }

    }
}
