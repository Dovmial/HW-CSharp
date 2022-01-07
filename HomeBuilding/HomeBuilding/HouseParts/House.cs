using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseParts
{
    public class House: IEnumerable
    {
        public Basement Basement { get; set; }
        public List<Wall> Walls = new List<Wall>();
        public List<Window> Windows = new List<Window>();
        public Door Door { get; set; }
        public Roof Roof { get; set; }
        public bool Complete { get; set; } = false;

        private List<IPart> parts = new List<IPart>();
        private float _resultCost;
        public House()
        {
            Init();
            CreateListParts();
        }
        public IPart this[int index]
        {
            get 
            { 
                if(index >=0 && index < parts.Count) 
                {
                    return parts[index];
                }
                throw new IndexOutOfRangeException();
            }
            set { parts[index] = value; }
        }
       
        public float CompleteState()
        {
            float sum = 0;
            foreach (IPart part in parts)
            {
                sum += part.State;
            }
            return sum / _resultCost * 100;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return parts.GetEnumerator();
        }
        private void Init()
        {
            Basement = new Basement();
            Walls.Add(new WallWithDoor());
            Door = (Walls[0] as WallWithDoor).Door;
            Roof = new Roof();
            Windows.Append(Walls[0].Window);
            for (int i = 1; i < 4; i++)
            {
                Walls.Add(new Wall());
            }
            foreach (Wall wall in Walls)
            {
                Windows.Add(wall.Window);
            }
        }

        private void CreateListParts()
        {
            parts.Add(Basement);
            foreach (Wall wall in Walls)
                parts.Add(wall);
            foreach (Window window in Windows)
                parts.Add(window);
            parts.Add(Door);
            parts.Add(Roof);

            _resultCost = 0;
            foreach (IPart part in parts)
                _resultCost += part.Cost;
        }
    }
}
