using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApps.Model
{
    public class Rectangle : AbstractFigure
    {
        public Rectangle(double a, double b): base (a, b){}
        public override void AreaCalc()
        {
            Area = _parameters[0]*_parameters[1];
        }

        public override void PerimeterCalc()
        {
            Perimeter = 2 * (_parameters[0] + _parameters[1]);
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
