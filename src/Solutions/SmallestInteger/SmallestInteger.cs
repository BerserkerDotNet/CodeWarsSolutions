namespace Solutions.SmallestInteger
{
    public class SmallestInteger
    {
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
