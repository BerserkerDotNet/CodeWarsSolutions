using Solutions.Infrastructure;
using System.Linq;

namespace Solutions.HIghestAndLowest
{
    public class HighestAndLowest : ISolution
    {
        public string DisplayName => "Highest And Lowest";

        public string HighAndLow(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var chunks = input.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            if (chunks.Count == 0)
                return input;

            int? min = null;
            int? max = null;
            foreach (var chunk in chunks)
            {
                var number = int.Parse(chunk);

                if (min == null)
                    min = number;

                if (max == null)
                    max = number;

                if (number > max)
                    max = number;

                if (number < min)
                    min = number;
            }

            return $"{max} {min}";
        }

        public void Execute(IHost host)
        {
            var numbers = host.Read<string>("Enter the space separated numbers sequence:");
            var result = HighAndLow(numbers);
            host.Show(result);
        }
    }
}
