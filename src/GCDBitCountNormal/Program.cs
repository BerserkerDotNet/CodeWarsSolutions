using System;

namespace GCDBitCountNormal
{
    class Program
    {
        const int mask1 = 0x55555555; // 0101...
        const int mask2 = 0x33333333; // 00110011..
        const int mask4 = 0x0f0f0f0f; // 4 zeros,  4 ones ...
        const int mask8 = 0x00ff00ff; // 8 zeros,  8 ones ...
        const int mask16 = 0x0000ffff; // 16 zeros, 16 ones ...
        const int maskAll = 0xfffffff; // all ones
        const int h01 = 0x01010101; //the sum of 256 to the power of 0,1,2,3...

        static void Main(string[] args)
        {
            Console.WriteLine($"GCD: {GCD(-124, -16)}");
            Console.WriteLine($"GCD: {Convert.ToString(GCD(-124, -16),2)}");
            Console.WriteLine($"GCD bits: {BitCount(-124, -16)}");
            Console.ReadLine();

        }

        public static int BitCount(int a, int b)
        {
            var x = GCD(a, b);

            // Calculate Hamming weight
            x = (x & mask1) + ((x >> 1) & mask1);
            x = (x & mask2) + ((x >> 2) & mask2);
            x = (x & mask4) + ((x >> 4) & mask4);
            x = (x & mask8) + ((x >> 8) & mask8); 
            x = (x & mask16) + ((x >> 16) & mask16); 
            return x;
        }

        public static int GCD(int a, int b)
        {
            if (b == 0)
            {
                return Math.Abs(a);
            }

            return GCD(b, a % b);
        }
    }
}
