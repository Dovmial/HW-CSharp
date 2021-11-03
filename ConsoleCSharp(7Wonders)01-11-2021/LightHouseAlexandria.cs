using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonders
{
    class LightHouseAlexandria: Wonder
    {
        public LightHouseAlexandria()
        {
            Name = "Александрийский маяк";
            Description = $"Название: {Name}\n" +
                "Время создания: 303 г. до н. э.\n" +
                   "Место: Александрия Египетская\n" +
                   "Создатели: греки, династия Птолемеев\n" +
                   "Разрушение: XIV в.\n" +
                   "Причина: землетрясение\n" +
                   "Назначение сооружения: для судоходства.\n";
        }
    }
}
