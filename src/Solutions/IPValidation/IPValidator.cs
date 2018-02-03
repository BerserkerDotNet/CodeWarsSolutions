using Solutions.Infrastructure;
using System.Globalization;
using System.Linq;

namespace Solutions.IPValidation
{
    public class IPValidator : ISolution
    {
        public string DisplayName => "IP validator";

        public void Execute(IHost host)
        {
            var address = host.Read<string>("Enter IP address to validate:");
            var result = IsValid(address) ? "valid" : "not valid";
            host.Show($"'{address}' is {result} IP address");
        }

        public bool IsValid(string address)
        {
            return SimpleValidation(address);
        }

        private bool SimpleValidation(string address)
        {
            if (string.IsNullOrEmpty(address))
                return false;

            var chunks = address.Split('.');
            if (chunks.Length < 4)
                return false;

            return chunks.All(c => IsValidIPChunk(c));
        }

        private bool IsValidIPChunk(string chunk)
        {
            if (chunk.StartsWith("0") && chunk.Length > 1)
                return false;

            int number;
            var isValidNumber = int.TryParse(chunk, NumberStyles.None, CultureInfo.CurrentCulture, out number);

            if (!isValidNumber)
                return false;

            return number >= 0 && number < 256;
        }
    }
}
