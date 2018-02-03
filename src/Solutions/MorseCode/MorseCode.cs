using Solutions.Infrastructure;
using System.Text;

namespace Solutions.MorseCode
{
    public class MorseCode : ISolution
    {
        public string DisplayName => "Morse code";

        public void Execute(IHost host)
        {
            var code = host.Read<string>("Enter the in morse code:");
            var message = Decode(code);
            host.Show($"Result: {message}");
        }

        public string Decode(string morseCode)
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

        private void AddSymbol(StringBuilder morse, StringBuilder result)
        {
            if (morse.Length > 0)
            {
                result.Append(MorseCodeAlphabet.GetSymbol(morse.ToString()));
                morse.Clear();
            }
        }
    }
}
