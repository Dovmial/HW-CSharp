using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeApp.BackPacks
{
    public class CampingBackPack : BackPackAbstract
    {
        public CampingBackPack(string itemsList) : base(itemsList) { }
    }

    public class SportBackPack : BackPackAbstract
    {
        public SportBackPack(string itemList) : base(itemList) { }
    }

    public class UrbanBackPack : BackPackAbstract
    {
        public UrbanBackPack(string itemList) : base(itemList) { }
    }
}
