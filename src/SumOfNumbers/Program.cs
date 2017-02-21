using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"Sum {SumOfNumbers(-2, 1)}");
            Console.ReadLine();
        }

        public static int SumOfNumbers(int a, int b)
        {
            if (a == b)
            {
                return a;
            }

            var min = a < b ? a : b;
            var max = a > b ? a : b;
            var sum = 0;
            for(int i=min; i <= max; i++)
            {
                sum += i;
            }

            return sum;
        }
    }
}
