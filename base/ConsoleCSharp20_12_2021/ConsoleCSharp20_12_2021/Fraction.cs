using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCSharp20_12_2021
{
    public struct Fraction
    {
        public Int64 Numerator { get; set; }
        public Int64 Denominator { get; set; }
        //public bool Positive { get; set; }
        static Int64 NOD(Int64 a, Int64 b)
        {
            if (a > b)
            {
                Int64 temp = b;
                b = a;
                a = temp;
            }
            
            while (b != 0)
            {
                Int64 temp = b;
                b %= a;
                a = temp;
            }
            return a;
        }
        static Int64 NOK(Int64 a, Int64 b)
        {
            return (a / NOD(a, b)) * b;
        }
        public Fraction(Int64 numerator, Int64 denominator)
        {
            if(denominator == 0)
            {
                throw new ArgumentException("Ошибка! Делитель не может быть равен нулю.");
            }
            if(denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }
            Numerator = numerator;
            Denominator = denominator;
        }

        public static Fraction operator-(Fraction f)
        {
            return new Fraction(-f.Numerator, f.Denominator);
        }
        public static Fraction operator+(Fraction f1, Fraction f2)
        {
            Int64 nok = NOK(f1.Denominator, f2.Denominator);
            return new Fraction()
            {
                Numerator = f1.Numerator * (nok / f1.Denominator) + f2.Numerator * (nok / f2.Denominator),
                Denominator = nok
            };
        }
        public static Fraction operator+ (Fraction f, double dNumber)
        {
            return f + (Fraction)dNumber;
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            Int64 nok = NOK(f1.Denominator, f2.Denominator);
            return new Fraction()
            {
                Numerator = f1.Numerator * (nok / f2.Denominator) - f2.Numerator * (nok / f1.Denominator),
                Denominator = nok
            };
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return new Fraction()
            {
                Numerator = f1.Numerator * f2.Numerator,
                Denominator = f1.Denominator * f2.Denominator
            };
        }
        public static Fraction operator*(Fraction f, Int64 number)
        {
            return new Fraction(f.Numerator * number, f.Denominator);
        }
        public static Fraction operator*(Int64 number, Fraction f)
        {
            return f*number;
        }

        public static Fraction operator/(Fraction f1, Fraction f2)
        {
            if (f2.Numerator == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction()
            {
                Numerator = f1.Numerator * f2.Denominator,
                Denominator = f1.Denominator * f2.Numerator
            };
        }
        public static bool operator >(Fraction f1, Fraction f2)
        {
            if(f1.Denominator == f2.Denominator)
            {
                return f1.Numerator > f2.Denominator;
            }
            Int64 nok = NOK(f1.Denominator, f2.Denominator);

            return f1.Numerator * (nok / f2.Denominator) > f2.Numerator * (nok / f1.Denominator);
        }
        public static bool operator<(Fraction f1, Fraction f2)
        {
            if (f1 > f2 || f1 == f2)
                return false;
            return true;
        }
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return f1.Equals(f2);
        }
        public static bool operator!=(Fraction f1, Fraction f2)
        {
            return !f1.Equals(f2);
        }
        public override bool Equals(object obj)
        {
            if(!(obj is Fraction))
            {
                return false;
            }
            return Equals((Fraction)obj);
        }

        public bool Equals(Fraction f)
        {
            if(Numerator != f.Numerator)
                return false;
            return Denominator == f.Denominator;
        }
        public override int GetHashCode()
        {
            return Numerator.GetHashCode() ^ Denominator.GetHashCode();
        }
        public static bool operator true(Fraction f)
        {
            return f.Numerator < f.Denominator;
        }
        public static bool operator false(Fraction f)
        {
            return f.Numerator >= f.Denominator;
        }
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
        
        public static explicit operator Fraction(double dNumber)
        {
            Int64 floorInt64 = (Int64)dNumber;
            double fractional = dNumber - floorInt64;
            var power = fractional.ToString().Length - 2;
            Int64 numerator = (Int64)(Math.Pow(10, power) * dNumber);
            Int64 denominator = (Int64)Math.Pow(10, power);
            return new Fraction(numerator, denominator);
        }

        public Fraction Reduction()
        {
            Int64 nod = NOD(Numerator, Denominator);
            Numerator /= nod;
            Denominator /= nod;
            return this;
        }
    }
}
