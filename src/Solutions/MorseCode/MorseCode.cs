using System.Text;

namespace Solutions.MorseCode
{
    public static class MorseCode
    {
        public static string Decode(string morseCode)
        {
            var result = new StringBuilder();
            var temp = new StringBuilder(9);
            morseCode = morseCode.Trim();

            for (int i = 0; i < morseCode.Length; i++)
            {
                if (morseCode[i] == ' ' && morseCode[i + 1] == ' ' && morseCode[i + 2] == ' ')
                {
                    AddSymbol(temp, result);
                    result.Append(" ");
                }
                else if (morseCode[i] == ' ')
                {
                    AddSymbol(temp, result);
                }
                else
                {
                    temp.Append(morseCode[i]);
                }
            }

            AddSymbol(temp, result);

            return result.ToString();
        }

        private static void AddSymbol(StringBuilder morse, StringBuilder result)
        {
            if (morse.Length > 0)
            {
                result.Append(MorseCodeAlphabet.GetSymbol(morse.ToString()));
                morse.Clear();
            }
        }
    }
}
