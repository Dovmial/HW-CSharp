using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetApps.Model
{
    public abstract class AbstractFigure
    {
        protected double[] _parameters;
        public double Area { get; protected set; }
        public double Perimeter  { get; protected set; }

        public AbstractFigure(params double[] parameters) 
            =>_parameters = parameters;
      
        public abstract void AreaCalc();
        public abstract void PerimeterCalc();
        public override string ToString()
        {
            return $"Периметр: {Perimeter}\t\tПлощадь: {Area}\n";
        }
    }
}
