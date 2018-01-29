using NUnit.Framework;
using Solutions.MorseCode;

namespace SolutionsTests
{
    [TestFixture]
    public class MorseTests
    {
        [TestCase(".... . -.--   .--- ..- -.. .", "HEY JUDE")]
        [TestCase("...---...", "SOS")]
        [TestCase(".... . .-.. .-.. ---   .-- --- .-. .-.. -..", "HELLO WORLD")]
        [TestCase("  .. .    ", "IE")]
        public void Morse_Basic(string morse, string expected)
        {
            var result = MorseCode.Decode(morse);
            Assert.AreEqual(expected, result);
        }
    }
}
