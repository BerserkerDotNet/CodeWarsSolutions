using System.Text;

namespace Solutions.ReversedWords
{
    public static class ReversedWords
    {
        public static string ReverseWords(string str)
        {
            var result = new StringBuilder(str.Length);
            var idx = 0;
            foreach (var c in str)
            {
                if (c == ' ')
                {
                    result.Insert(0, c);
                    idx = 0;
                }
                else
                {
                    result.Insert(idx++, c);
                }
            }

            return result.ToString();
        }
    }
}
