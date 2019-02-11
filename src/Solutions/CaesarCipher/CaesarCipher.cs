using Solutions.Infrastructure;
using System;
using System.Linq;
using System.Text;

namespace Solutions.CaesarCipher
{
    public class CaesarCipher : ISolution
    {
        const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string DisplayName => "Ceasar Cipher";

        public void Execute(IHost host)
        {
            throw new NotImplementedException();
        }

        public string[] Encrypt(string plainText, int shift)
        {
            var resultString = TransformText(plainText, shift, decrypting: false);
            var chunkLength = (int)Math.Ceiling(resultString.Length / (double)5);
            var result = new string[5];
            result[0] = GetSubString(resultString, 0, chunkLength);
            result[1] = GetSubString(resultString, 1, chunkLength);
            result[2] = GetSubString(resultString, 2, chunkLength);
            result[3] = GetSubString(resultString, 3, chunkLength);
            result[4] = GetSubString(resultString, 4, chunkLength);

            return result.ToArray();
        }

        public string Decrypt(string[] parts, int shift)
        {
            var cipherText = string.Concat(parts);
            return TransformText(cipherText, shift, decrypting: true);
        }

        public string[] Encrypt2(string plainText, int shift)
        {
            var resultString = TransformText(plainText, shift, decrypting: false, isFixedShift: true);
            resultString = $"{GetPrefix(plainText)}{resultString}";
            var chunkLength = (int)Math.Ceiling(resultString.Length / (double)5);
            var result = new string[5];
            result[0] = GetSubString(resultString, 0, chunkLength);
            result[1] = GetSubString(resultString, 1, chunkLength);
            result[2] = GetSubString(resultString, 2, chunkLength);
            result[3] = GetSubString(resultString, 3, chunkLength);
            result[4] = GetSubString(resultString, 4, chunkLength);

            return result;
        }

        public string Decrypt2(string[] parts)
        {
            var prefix = parts[0].Substring(0, 3);
            var shift = Alphabet.IndexOf(char.ToUpper(prefix[2])) - Alphabet.IndexOf(char.ToUpper(prefix[0]));
            if (shift < 0)
            {
                shift = shift + Alphabet.Length;
            }

            var cipherText = string.Concat(parts);
            var transformedText = TransformText(cipherText, shift, decrypting: true, isFixedShift: true);
            return transformedText.Substring(2);
        }

        private string GetPrefix(string plainText)
        {
            var firstLetterIdx = Alphabet.IndexOf(char.ToUpper(plainText[0]));
            var prefixIndex = firstLetterIdx + 1 == Alphabet.Length ? 0 : firstLetterIdx + 1;
            var prefix = $"{char.ToLower(plainText[0])}{char.ToLower(Alphabet[prefixIndex])}";
            return prefix;
        }

        private string TransformText(string text, int shift, bool decrypting, bool isFixedShift = false)
        {
            var sb = new StringBuilder(text.Length);
            for (int i = 0; i < text.Length; i++)
            {
                var character = text[i];
                if (!char.IsLetter(character))
                {
                    sb.Append(character);
                }
                else
                {
                    var isLower = char.IsLower(character);
                    var currentPosition = Alphabet.IndexOf(char.ToUpper(character));
                    var shiftedPosition = decrypting ? CalculateOpositePosition(currentPosition, shift) : CalculatePosition(currentPosition, shift);
                    var shiftedChar = isLower ? char.ToLower(Alphabet[shiftedPosition]) : Alphabet[shiftedPosition];
                    sb.Append(shiftedChar);
                }

                if (!isFixedShift)
                {
                    shift++;
                }
            }
            return sb.ToString();
        }

        private string GetSubString(string s, int partNumber, int length)
        {
            var startIndex = length * partNumber;
            if (startIndex + length >= s.Length)
            {
                length = s.Length - startIndex;
            }

            if (length <= 0)
            {
                return string.Empty;
            }

            return s.Substring(startIndex, length);
        }

        private int CalculatePosition(int currentPosition, int shiftValue)
        {
            return (currentPosition + shiftValue) % Alphabet.Length;
        }

        private int CalculateOpositePosition(int currentPosition, int shiftValue)
        {
            int modulo = (currentPosition - shiftValue) % Alphabet.Length;
            return (modulo < 0) ? modulo + Alphabet.Length : modulo;
        }
    }
}
