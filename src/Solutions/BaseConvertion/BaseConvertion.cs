using Solutions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions.BaseConvertion
{
    /*
     * In this kata you have to implement a base converter, which converts positive integers between arbitrary bases / alphabets.
     * The function convert() should take an input (string), the source alphabet (string) and the target alphabet (string). You can assume that the input value always consists of characters from the source alphabet. You don't need to validate it.
     */
    public class BaseConvertion : ISolution
    {
        public string DisplayName => "Base convertion";

        public void Execute(IHost host)
        {
            var input = host.Read<string>("Enter a number to convert:");

            var alphabetsChoise = new StringBuilder();
            var idx = 0;
            foreach (var alphabet in Alphabet.All)
            {
                alphabetsChoise.AppendLine($"{idx}. {alphabet.Key}");
                idx++;
            }

            var alphabets = Alphabet.All.ToArray();
            host.Show("From alphabet:");
            var alphabetFromIdx = host.Read<int>(alphabetsChoise.ToString());
            var alphabetFrom = alphabets[alphabetFromIdx].Value;

            host.Show("To alphabet:");
            var alphabetToIdx = host.Read<int>(alphabetsChoise.ToString());
            var alphabetTo = alphabets[alphabetToIdx].Value;

            var result = Convert(input, alphabetFrom, alphabetTo);

            host.Show($"Result: {result}");
        }

        public string Convert(string input, string sourceAlphabet, string targetAlphabet)
        {
            CheckIfNotNull(input, nameof(input));
            CheckIfNotNull(sourceAlphabet, nameof(sourceAlphabet));
            CheckIfNotNull(targetAlphabet, nameof(targetAlphabet));

            if (sourceAlphabet == targetAlphabet)
                return input;

            if (sourceAlphabet.Length == targetAlphabet.Length)
                return AlphabetConvert(input, sourceAlphabet, targetAlphabet);

            var inputBase = sourceAlphabet.Length;

            var decimalValue = 0L;
            var idx = input.Length - 1;
            foreach (var symbol in input)
            {
                var value = sourceAlphabet.IndexOf(symbol);
                decimalValue += value * (long)Math.Pow(inputBase, idx);
                idx--;
            }

            return ChangeBase(decimalValue, targetAlphabet);
        }

        private string AlphabetConvert(string input, string sourceAlphabet, string targetAlphabet)
        {
            var convertedArray = input.ToCharArray()
                .Select(c => targetAlphabet[sourceAlphabet.IndexOf(c)])
                .ToArray();
            return new string(convertedArray);
        }

        private string ChangeBase(long decimalValue, string alphabet)
        {
            if (decimalValue <= alphabet.Length - 1)
                return alphabet[(int)decimalValue].ToString();

            var targetBase = alphabet.Length;
            var currentValue = decimalValue;
            var builder = new StringBuilder();
            while (currentValue >= targetBase)
            {
                var rem = currentValue % targetBase;
                builder.Append(alphabet[(int)rem]);
                currentValue = (long)Math.Floor(currentValue / (decimal)targetBase);
            }

            builder.Append(alphabet[(int)currentValue]);

            return Reverse(builder.ToString());
        }

        private void CheckIfNotNull(string value, string parameterName = "")
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(parameterName);
        }

        private string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    public class Alphabet
    {
        public const string BINARY = "01";
        public const string OCTAL = "01234567";
        public const string DECIMAL = "0123456789";
        public const string HEXA_DECIMAL = "0123456789ABCDEF";
        public const string ALPHA_LOWER = "abcdefghijklmnopqrstuvwxyz";
        public const string ALPHA_UPPER = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string ALPHA = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string ALPHA_NUMERIC = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static Dictionary<string, string> All = new Dictionary<string, string>
        {
            { nameof(BINARY), BINARY },
            { nameof(OCTAL), OCTAL },
            { nameof(DECIMAL), DECIMAL },
            { nameof(HEXA_DECIMAL), HEXA_DECIMAL },
            { nameof(ALPHA_LOWER), ALPHA_LOWER },
            { nameof(ALPHA_UPPER), ALPHA_UPPER },
            { nameof(ALPHA), ALPHA },
            { nameof(ALPHA_NUMERIC), ALPHA_NUMERIC },
        };
    }
}
