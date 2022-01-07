using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseParts 
{ 
    public class Wall: IPart
    {
        public float Cost { get; set; }
        public float State { get; set; }
        public Window Window { get; set; }
        public Wall()
        {
            Cost = 2f;
            State = 0;
            Window = new Window();
        }
        public override string ToString()
        {
            return $"\tWall: {State / Cost * 100}%";
        }
    }


    public class WallWithDoor : Wall, IPart
    {
        public Door Door { get; set; }
        public WallWithDoor(): base()
        {
            Door = new Door();
        }
    }
}
