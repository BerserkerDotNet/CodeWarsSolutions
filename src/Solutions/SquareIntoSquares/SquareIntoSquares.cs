using Solutions.Infrastructure;
using System;
using System.Text;
using System.Threading;

namespace Solutions.SquareIntoSquares
{
    public class SquareIntoSquares : ISolution
    {
        public string DisplayName => "Square into Squares";

        public void Execute(IHost host)
        {
            var n = host.Read<long>("Enter number:");
            var result = Decompose(n);

            host.Show($"Result: {result}");
        }

        public string Decompose(long n)
        {
            var sb = new StringBuilder();

            if (!FindRoot(n, n, Sqr(n), sb))
            {
                return null;
            }

            return sb.ToString().Trim();
        }

        public bool FindRoot(long n, long prevX, double sum, StringBuilder sb)
        {
            if (sum == 0)
            {
                return true;
            }

            var x = long.MaxValue;
            var isValid = false;
            x = GetRoot(sum);
            while (x > 0)
            {
                if (x == n)
                {
                    x--;
                }

                if (x >= prevX)
                {
                    return false;
                }

                var nSum = sum - Sqr(x);
                isValid = FindRoot(n, x, nSum, sb);
                if (isValid)
                    break;

                x--;
            }

            if (isValid)
            {
                sb.Append($"{x} ");
            }

            return isValid;
        }

        private long GetRoot(double val) => (long)Math.Floor(Math.Sqrt(val));

        private double Sqr(double number) => Math.Pow(number, 2);
    }
}
