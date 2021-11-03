using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonders
{
    class StatueZevs: Wonder
    {
        public StatueZevs()
        {
            Name = "Статуя Зевса";
            Description = $"Название: {Name}\n" + 
                "Время создания: 435 г. до н. э\n" +
                "Место: Олимпия (Греция)\n" +
                "Создатели: Фидий\n" +
                "Разрушение: V в.\n" +
                "Причина: сгорела в Константинополе во время пожара на Ипподроме в V в.\n\t" +
                "Или погибла вместе с храмом от пожара в 426 году\n" +
                "Назначение сооружения: храмовая статуя в храме Зевса в Олимпии\n";
        }
    }
}
