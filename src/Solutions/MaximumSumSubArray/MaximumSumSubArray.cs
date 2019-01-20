using Solutions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.MaximumSumSubArray
{
    public class MaximumSumSubArray : ISolution
    {
        public string DisplayName => "Maximum subarray sum";

        public void Execute(IHost host)
        {
            throw new NotImplementedException();
        }

        public static int MaxSequence(int[] array)
        {
            var maxSum = 0;
            var currentSum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                var value = array[i];
                var newSum = currentSum + value;
                if (newSum < 0)
                {
                    currentSum = 0;
                }
                else
                {
                    currentSum = currentSum + value;
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }

            return maxSum;
        }
    }
}
