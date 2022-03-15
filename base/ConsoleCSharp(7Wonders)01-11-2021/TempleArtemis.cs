using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonders
{
    class TempleArtemis: Wonder
    {
        public TempleArtemis()
        {
            Name = "Храм Артемиды";
            Description = $"Название: {Name}\n" +
                "Время создания: 560 г. до н. э.\n" +
                    "Место: Эфес (Турция)\n" +
                    "Создатели: Херсифрон разработал проект Храма и начал его строить.\n\t" +
                    " Пеоний и Деметрий закончили строение\n" +
                    "Разрушение: 370 г. до н. э.356 г.до н. э. (Геростратом) или 262 г.н.э. (готами)\n" +
                    "Причина: пожар\n" +
                    "Назначение сооружения: был построен в честь богини Артемиды\n";
        }
    }
}
