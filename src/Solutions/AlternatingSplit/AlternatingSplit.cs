using Solutions.Infrastructure;
using System.Text;
using System.Text.RegularExpressions;

namespace Solutions.AlternatingSplit
{
    public class AlternatingSplit : ISolution
    {
        public string DisplayName => "Alternating Split";

        public void Execute(IHost host)
        {
            var input = host.Read<string>("Enter a command ([/D or /E] <string> /N <number>)");
            var inputMatch = Regex.Match(input, @"(?<cmd>/D|/E) (?<input>[^/]+) /N (?<number>\d+)", RegexOptions.IgnoreCase);
            if (!inputMatch.Success)
            {
                host.Show("Input is not in a correct format.");
                return;
            }

            var cmd = inputMatch.Groups["cmd"].Value;
            var str = inputMatch.Groups["input"].Value;
            var number = int.Parse(inputMatch.Groups["number"].Value);
            var result = string.Empty;

            if (cmd.ToLower() == "/e")
            {
                result = Encrypt(str, number);
            }
            else
            {
                result = Decrypt(str, number);
            }

            host.Show($"Result: {result}");
        }

        public string Encrypt(string input, int n)
        {
            if (string.IsNullOrEmpty(input) || n <= 0)
            {
                return input;
            }

            for (int i = 1; i <= n; i++)
            {
                var sb = new StringBuilder(input.Length);
                EncryptInternal(sb, input, 0);
                input = sb.ToString();
            }

            return input;
        }

        public string Decrypt(string input, int n)
        {
            if (string.IsNullOrEmpty(input) || n <= 0)
            {
                return input;
            }

            for (int i = 1; i <= n; i++)
            {
                var sb = new StringBuilder(input.Length);
                DecryptInternal(sb, input, 0);
                input = sb.ToString();
            }

            return input;
        }

        private void EncryptInternal(StringBuilder sb, string s, int index)
        {
            if (index == s.Length)
            {
                sb.Append(s[0]);
                return;
            }
            else if (index == s.Length)
            {
                sb.Append(s[0]);
                return;
            }
            else if (index % 2 != 0)
            {
                sb.Append(s[index]);
            }

            EncryptInternal(sb, s, index - 1);

            if (index % 2 == 0)
            {
                sb.Append(s[index]);
            }

            //if (index + 1 <= s.Length)
            //{
            //    EncryptInternal(sb, s, index + 1);

            //    if (index % 2 == 0)
            //    {
            //        sb.Append(s[s.Length - (index - 1)]);
            //    }
            //}
            //else
            //{
            //    sb.Append(s[0]);
            //}
        }

        private void DecryptInternal(StringBuilder sb, string s, int index)
        {
            var half = (s.Length / 2);
            if (half + index < s.Length)
            {
                sb.Append(s[(s.Length / 2) + index]);
                if (index != half)
                {
                    sb.Append(s[index]);
                }
                DecryptInternal(sb, s, index + 1);
            }
        }
    }
}
