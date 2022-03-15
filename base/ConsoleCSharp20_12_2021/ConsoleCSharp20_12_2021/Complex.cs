using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCSharp20_12_2021
{
    public struct Complex
    {
        public double Real { get; set; }
        public double Imaginary{ get; set; } 
        public Complex (double Re, double Im)
        {
            Real = Re;
            Imaginary = Im;
        }
        public static Complex operator +(Complex z1, Complex z2)
        {
            return new Complex
            {
                Real = z1.Real + z2.Real,
                Imaginary = z1.Imaginary + z2.Imaginary
            };
        }
        public static Complex operator-(Complex z1, Complex z2)
        {
            return new Complex
            {
                Real = z1.Real - z2.Real,
                Imaginary = z1.Imaginary - z2.Imaginary
            };
        }

        public static Complex operator-(Complex z, int number)
        {
            return new Complex
            {
                Real = z.Real - number,
                Imaginary = z.Imaginary
            };
        }

        public static Complex operator*(Complex z1, Complex z2)
        {
            return new Complex
            {
                Real = z1.Real * z2.Real - z1.Imaginary * z2.Imaginary,
                Imaginary = z1.Imaginary * z2.Real + z1.Real * z2.Imaginary
            };
        }
         public static Complex operator*(int number, Complex z)
        {
            return new Complex
            {
                Real = number * z.Real,
                Imaginary = number * z.Imaginary
            };
        }
        public static Complex operator/(Complex z1, Complex z2)
        {
            double real = 
                (z1.Real*z2.Real + z1.Imaginary*z2.Imaginary) / 
                (z2.Real*z2.Real + z2.Imaginary*z2.Imaginary);

            double imaginary =
                (z1.Imaginary * z2.Real - z1.Real * z2.Imaginary) /
                (z2.Real * z2.Real + z2.Imaginary * z2.Imaginary);

            return new Complex
            {
                Real = real,
                Imaginary = imaginary
            };
        }

        public override string ToString()
        {
            return $"{Real} + ({Imaginary})i";
        }
    }
}
