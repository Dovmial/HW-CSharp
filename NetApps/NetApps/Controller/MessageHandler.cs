using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetApps.Model;

namespace NetApps.Controller
{
    public static class MessageHandler
    {
        /// <summary>
        /// Обработка сообщения для расчета
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string Calc(string message)
        {
            string[] args = message.Split();
            switch (args[0].ToLower())
            {
                case "треугольник":
                    {
                        if (args.Length != 4)
                        {
                            throw new ArgumentException("Некорректное количество аргументов. Должно быть 3 стороны");
                        }
                        double a, b, c;
                        double.TryParse(args[1], out a);
                        double.TryParse(args[2], out b);
                        double.TryParse(args[3], out c);

                        Triangle triangle = new Triangle(a, b, c);
                        triangle.AreaCalc();
                        return triangle.ToString();
                    }
                case "прямоугольник":
                    {
                        if (args.Length != 3)
                        {
                            throw new ArgumentException(
                                "Некорректное количество аргументов. Должны быть ширина и высота прямоуольника");
                        }
                        double a, b;
                        double.TryParse(args[1], out a);
                        double.TryParse(args[2], out b);

                        Rectangle rect = new Rectangle(a, b);
                        rect.AreaCalc();
                        rect.PerimeterCalc();
                        return rect.ToString();
                    }

                case "круг":
                    {
                        if (args.Length != 2)
                        {
                            throw new ArgumentException(
                                "Некорректное количество аргументов. Должен быть указан только радиус");
                        }
                        double r;
                        double.TryParse(args[1], out r);
                        Circle circle = new Circle(r);
                        circle.AreaCalc();
                        circle.PerimeterCalc();
                        return circle.ToString();
                    }
                default:
                    return $"{args[0]} - неизвестная фигура(треугольник, прямоугольник, круг)";
            }
        }
    }
}
