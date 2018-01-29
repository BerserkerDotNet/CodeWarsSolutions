using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.EnoughIsEnough
{
    public class EnoughIsEnough
    {
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
