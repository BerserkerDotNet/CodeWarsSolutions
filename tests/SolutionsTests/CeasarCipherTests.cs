using FluentAssertions;
using NUnit.Framework;
using Solutions.CaesarCipher;

namespace SolutionsTests
{
    [TestFixture]
    public class CeasarCipherTests
    {
        [TestCaseSource(nameof(Data))]
        public void ShouldEncryptCorrectly(string input, string[] expected)
        {
            var cipher = new CaesarCipher();
            var result = cipher.Encrypt(input, 1);

            result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
        }

        [TestCaseSource(nameof(Data))]
        public void ShouldDecryptCorrectly(string expected, string[] parts)
        {
            var cipher = new CaesarCipher();
            var result = cipher.Decrypt(parts, 1);

            result.Should().Be(expected);
        }

        private static object[] Data =
        {
            new object[]
            {
                "I should have known that you would have a perfect answer for me!!!",
                new[] { "J vltasl rlhr ", "zdfog odxr ypw", " atasl rlhr p ", "gwkzzyq zntyhv", " lvz wp!!!" }
            },
            new object[]
            {
                "I s",
                new[] { "J", " ", "v", "", "" }
            },
            new object[]
            {
                "I",
                new[] { "J", "", "", "", "" }
            }
        };

    }
}
