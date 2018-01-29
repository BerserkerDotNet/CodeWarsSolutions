namespace Solutions.MergedStringCheker
{
    public class MergedStringCheker
    {
        public static bool CanBeMergeOf(string s, string part1, string part2)
        {
            if (part1.Length == part2.Length && part1 + part2 == s)
            {
                return true;
            }

            if (part1.Length + part2.Length != s.Length || ((part1.Length > 0 && part1[0] != s[0]) && (part2.Length > 0 && part2[0] != s[0])))
            {
                return false;
            }

            int p1Idx = 0;
            int p2Idx = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var p1Symbol = GetSymbol(part1, p1Idx);
                var p2Symbol = GetSymbol(part2, p2Idx);
                var currentSymbol = GetSymbol(s, i);
                if (p1Symbol == p2Symbol && p1Symbol == currentSymbol)
                {
                    if (ShouldTakePart1(part1, part2, s, p1Idx, p2Idx, i))
                    {
                        p1Idx++;
                    }
                    else
                    {
                        p2Idx++;
                    }
                }
                else if (p1Symbol == currentSymbol)
                {
                    p1Idx++;
                }
                else if (p2Symbol == currentSymbol)
                {
                    p2Idx++;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private static bool ShouldTakePart1(string part1, string part2, string s, int p1Idx, int p2Idx, int idx)
        {
            var p1Symbol = GetSymbol(part1, p1Idx + 1);
            var p2Symbol = GetSymbol(part2, p2Idx + 1);
            var currentSymbol = GetSymbol(s, idx + 1);
            return (p1Symbol == currentSymbol && p2Symbol != currentSymbol);
        }

        private static char GetSymbol(string part, int idx)
        {
            return part.Length > idx ? part[idx] : '\0';
        }
    }
}
