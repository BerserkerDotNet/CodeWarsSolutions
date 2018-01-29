namespace Solutions.SumOfNumbers
{
    public class SumOfNumbers
    {
        public static int Sum(int a, int b)
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
