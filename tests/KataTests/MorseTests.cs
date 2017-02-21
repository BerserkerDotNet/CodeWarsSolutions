using NUnit.Framework;

namespace KataTests
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
            var result = MorseCode.MorseCode.Decode(morse);
            Assert.AreEqual(expected, result);
        }
    }
}
