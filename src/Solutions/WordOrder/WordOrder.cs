using System.Linq;

namespace Solutions.WordOrder
{
    public class WordOrder
    {
        public static string Order(string input)
        {
            var arrayOfNumbers = new[] {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var words = input.Split(' ').OrderBy(r => r[r.IndexOfAny(arrayOfNumbers)]);
            return string.Join(' ', words);
        }
    }
}
