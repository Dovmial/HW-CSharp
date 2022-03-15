using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciiApp
{
    public class Fibonacci
    {
        private ulong _maxValue = ulong.MaxValue;
        public List<ulong> FibonacciList { get; set; } = new List<ulong>();
        private void Generate()
        {
            ulong first = 1;
            ulong second = 1;
            ulong sum = 2;

            while ((double)first + (double)second <= (double)_maxValue)
            {
                sum = first + second;
                first = second;
                second = sum;
                FibonacciList.Add(sum);
            }
        }
        public Fibonacci()
        {
            Generate();
        }
    }
}
