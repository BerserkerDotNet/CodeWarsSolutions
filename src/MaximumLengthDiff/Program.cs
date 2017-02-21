using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumLengthDiff
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new[] {  "bbllkw", "oox", "ejjuyyy", "plmiis", "xxxzgpsssa", "xxwwkktt", "znnnnfqknaz", "qqquuhii", "dvvvwz" };
            var s2 = new[] { "cccooommaaqqoxii", "gggqaffhhh", "tttoowwwmmww"};

            Console.WriteLine($"Max diff: {MaxLengthDiff(s1, s2)}");
            Console.WriteLine($"Max diff N: {MaxLengthDiffNaive(s1, s2)}");
            Console.ReadLine();
        }


        public static int MaxLengthDiff(string[] a1, string[] a2)
        {
            if (a1.Length == 0 || a2.Length == 0)
            {
                return -1;
            }

            var extremes1 = GetExtremes(a1);
            var extremes2 = GetExtremes(a2);

            var total1 = extremes1.Item1 + extremes1.Item2;
            var total2 = extremes2.Item1 + extremes2.Item2;

            var absoluteMax = (total1 > total2) ? extremes1.Item2 : extremes2.Item2;
            var absoluteMin = (total1 > total2) ? extremes2.Item1 : extremes1.Item1;

            return absoluteMax - absoluteMin;
        }

        public static Tuple<int, int> GetExtremes(string[] array)
        {
            var min = int.MaxValue;
            var max = int.MinValue;

            foreach (var element in array)
            {
                var length = element.Length;
                if (length < min)
                {
                    min = element.Length;
                }

                if (length > max)
                {
                    max = element.Length;
                }
            }

            return new Tuple<int, int>(min, max);
        }


        public static int MaxLengthDiffNaive(string[] a1, string[] a2)
        {
            if (a1.Length == 0 || a2.Length == 0)
            {
                return -1;
            }

            var maxLengthDiff = 0;

            foreach (var e1 in a1)
            {
                foreach (var e2 in a2)
                {
                    var currentDiff = Math.Abs(e1.Length - e2.Length);
                    if (currentDiff > maxLengthDiff)
                    {
                        maxLengthDiff = currentDiff;
                    }
                }
            }

            return maxLengthDiff;
        }
    }
}
