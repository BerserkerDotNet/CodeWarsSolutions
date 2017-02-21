using System;

namespace SmallestInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Min: {0}", Min(new int[] { 4, 6, -78, 345, 16, 4, 66, 89 }));
            Console.ReadLine();
        }

        public static int Min(int[] input)
        {
            var min = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                if (min > input[i])
                {
                    min = input[i];
                }
            }

            return min;
        }
    }
}
