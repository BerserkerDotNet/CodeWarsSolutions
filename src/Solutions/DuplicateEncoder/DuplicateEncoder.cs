using Solutions.Infrastructure;
using System.Collections.Generic;
using System.Text;

namespace Solutions.DuplicateEncoder
{
    public class DuplicateEncoder : ISolution
    {
        public string DisplayName => "Duplicate encoder";

        public void Execute(IHost host)
        {
            var text = host.Read<string>("Enter text:");
            host.Show($"Result {DuplicateEncode(text)}");
        }

        public string DuplicateEncode(string word)
        {
            var countTable = new Dictionary<char, int>(word.Length);
            var sb = new StringBuilder();
            ProcessSymbol(word.ToLower(), countTable, sb);
            return sb.ToString();
        }

        private void ProcessSymbol(string s, Dictionary<char, int> countTable, StringBuilder sb)
        {
            if (s.Length == 0)
            {
                return;
            }

            var symbol = s[0];
            if (countTable.ContainsKey(symbol))
            {
                countTable[symbol]++;
            }
            else
            {
                countTable.Add(symbol, 1);
            }

            ProcessSymbol(s.Substring(1), countTable, sb);
            var value = countTable[symbol] == 1 ? '(' : ')';
            sb.Insert(0, value);
        }
    }
}