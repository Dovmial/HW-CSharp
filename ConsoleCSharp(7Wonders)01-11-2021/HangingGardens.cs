using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonders
{
    class HangingGardens: Wonder
    {
        public HangingGardens()
        {
            Name = "Висячие сады Семирамиды";
            Description = $"Название: {Name}\n" +
                "Время создания: 605 г. до н. э.\n" +
                    "Место: Вавилон (Ирак, Месопотамия)\n" +
                    "Создатели: были возведены по приказу Навуходоносора II\n" +
                    "Разрушение: II в. до н. э.\n" +
                    "Причина: в 126 году до н. э. разрушены персами.\n" +
                    "Назначение сооружения: были созданы для жены царя Навуходоносора II\n";
        }
    }
}
