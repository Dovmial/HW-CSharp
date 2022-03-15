using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApps.Model
{
    public class Triangle : AbstractFigure
    {
        public Triangle(double a, double b, double c) : base(a, b, c)
        {
            if (_parameters[0] + _parameters[1] <= _parameters[2] &&
                _parameters[0] + _parameters[2] <= _parameters[1] &&
                _parameters[1] + _parameters[2] <= _parameters[0])
            {
                throw new ArgumentException("Трегольника с такими сторонами не существует");
            }
        }
        public override void AreaCalc()
        {
            if (Perimeter == default)
                PerimeterCalc();
            double p  = Perimeter / 2.0;
            Area = Math.Sqrt(p * (p - _parameters[0]) * (p - _parameters[1]) * (p - _parameters[2]));
        }

        public override void PerimeterCalc()
        {
            Perimeter = _parameters[0] + _parameters[1] + _parameters[2];
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
