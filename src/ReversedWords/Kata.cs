using System.Text;

namespace ReversedWords
{
    public static class Kata
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
