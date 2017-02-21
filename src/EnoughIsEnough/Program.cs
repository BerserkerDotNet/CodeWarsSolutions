using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnoughIsEnough
{
    class Program
    {
        static void Main(string[] args)
        {

            var i1 = new int[] { 20, 37, 20, 21 };
            var i2 = new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 };
            Console.WriteLine($"Result 1: {string.Join(",", DeleteNth(i1, 1))}");
            Console.WriteLine($"Result 2: {string.Join(",", DeleteNth(i2, 3))}");
            Console.ReadLine();
        }

        public static int[] DeleteNth(int[] initialArray, int maxEncounter)
        {
            var countStorage = new Dictionary<int, int>();
            var result = new List<int>(initialArray.Length);

            foreach (var element in initialArray)
            {
                var currentCount = countStorage.ContainsKey(element) ? countStorage[element] : 0;
                if (currentCount >= maxEncounter)
                {
                    continue;
                }

                result.Add(element);
                countStorage[element] = currentCount + 1;
            }

            return result.ToArray();
        }
    }
}
