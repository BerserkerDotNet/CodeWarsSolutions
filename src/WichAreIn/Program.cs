using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WichAreIn
{
    class Program
    {
        static void Main(string[] args)
        {
            var a1 = new[] { "arp", "live", "strong" };
            var a2 = new[] { "lively", "alive", "harp", "sharp", "armstrong" };
            var b1 = new[] { "tarp", "mice", "bull" };
            var b2 = new[] { "lively", "alive", "harp", "sharp", "armstrong" };

            Console.WriteLine($"Result A: [{string.Join(", ", WichAreIn(a1, a2))}]");
            Console.WriteLine($"Result B: [{string.Join(", ", WichAreIn(b1, b2))}]");
            Console.ReadLine();

        }

        public static string[] WichAreIn(string[] a1, string[] a2)
        {
            var result = new HashSet<string>();
            var dataString = string.Join("|", a2);
            foreach (var a1Element in a1)
            {
                if (dataString.Contains(a1Element))
                {
                    result.Add(a1Element);
                }
            }

            return result.OrderBy(x => x).ToArray();
        }

        public static string[] WichAreInNaive(string[] a1, string[] a2)
        {
            HashSet<string> result = new HashSet<string>();
            foreach (var a1Element in a1)
            {
                foreach (var a2Element in a2)
                {
                    if (a2Element.Contains(a1Element))
                    {
                        result.Add(a1Element);
                    }
                }
            }

            return result.OrderBy(x => x).ToArray();
        }
    }
}
