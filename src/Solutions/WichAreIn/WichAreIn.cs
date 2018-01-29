using System.Collections.Generic;
using System.Linq;

namespace Solutions.WichAreIn
{
    public class WichAreIn
    {
        public static string[] WichAreInSmart(string[] a1, string[] a2)
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
