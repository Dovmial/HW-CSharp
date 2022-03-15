using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApps.Model
{
    public class Circle : AbstractFigure
    {
        public Circle(double radius) : base(radius) { }
        public override void AreaCalc()
        {
            Area = Math.PI*_parameters[0]*_parameters[0];
        }

        public override void PerimeterCalc()
        {
            Perimeter = 2.0 * Math.PI * _parameters[0];
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
