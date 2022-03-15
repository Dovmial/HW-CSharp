using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonders
{
    class ColossusRhodes: Wonder
    {
        public ColossusRhodes()
        {
            Name = "Колосс Родосский";
            Description = $"Название: {Name}\n"+
               "Время создания: между 292 и 280 гг. до н. э.\n" +
               "Место: Родос (Греция)\n" +
               "Создатели: Харес\n" +
               "Разрушение: 224 (или 226) г. до н. э.бронзовый корпус был демонтирован в 654 г.н.э.\n" +
               "Причина: землетрясение\n"+
               "Назначение сооружения: был установлен скульптором Харесом\n\t" +
               "для увековечивания памяти о победе Родоса над Деметрием Полиоркетом (304 г. до н. э.) .\n";
        }
    }
}
