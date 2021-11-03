using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonders
{
    class Piramids: Wonder
    {
        public Piramids()
        {
            Name = "Комплекс пирамид в Гизе";
            Description = $"Название: {Name}\n" +
                "Время создания: Неизвестно\n" +
                "Место: Гиза (Египет)\n" +
                "Создатели: неизвестно\n" +
                "Разрушение: единственное из 7 чудес, сохранившееся до наших дней\n" +
                "Назначение сооружения: неизвестно\n";
        }
    }
}
