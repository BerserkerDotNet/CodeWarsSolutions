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

        [TestCaseSource(nameof(Data2))]
        public void ShouldEncrypt2Correctly(string input, string[] expected)
        {
            var cipher = new CaesarCipher();
            var result = cipher.Encrypt2(input, 1);

            result.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
        }

        [TestCaseSource(nameof(Data))]
        public void ShouldDecryptCorrectly(string expected, string[] parts)
        {
            var cipher = new CaesarCipher();
            var result = cipher.Decrypt(parts, 1);

            result.Should().Be(expected);
        }

        [TestCaseSource(nameof(Data2))]
        public void ShouldDecrypt2Correctly(string expected, string[] parts)
        {
            var cipher = new CaesarCipher();
            var result = cipher.Decrypt2(parts);

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

        private static object[] Data2 =
{
            new object[]
            {
                "Z should have known that you would have a perfect answer for me!!!",
                new[] { "zaA tipvme ibw", "f lopxo uibu z", "pv xpvme ibwf ", "b qfsgfdu botx", "fs gps nf!!!" }
            },
            new object[]
            {
                "I have spread my dreams under your feet; Tread softly because you tread on my dreams. William B Yeats (1865-1939)",
                new []{"ijJ ibwf tqsfbe nz esfb","nt voefs zpvs gffu; Usf","be tpgumz cfdbvtf zpv u","sfbe po nz esfbnt. Xjmm","jbn C Zfbut (1865-1939)" }
            }
        };

    }
}
