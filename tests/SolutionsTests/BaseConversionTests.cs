using FluentAssertions;
using NUnit.Framework;
using Solutions.BaseConvertion;
using System;

namespace SolutionsTests
{
    [TestFixture]
    public class BaseConversionTests
    {
        BaseConvertion _converter;

        [SetUp]
        public void SetUp()
        {
            _converter = new BaseConvertion();
        }

        [TestCase(null, null, null)]
        [TestCase("", "", "")]
        [TestCase("", "012", "01")]
        [TestCase("12", "", "01")]
        [TestCase("12", "01", "")]
        public void ShouldThrowIfInvalidInput(string input, string sAlphabet, string tAlphabet)
        {
            _converter.Invoking(c => c.Convert(input, sAlphabet, tAlphabet))
                .Should().Throw<ArgumentNullException>();
        }


        [TestCase("15", Alphabet.DECIMAL, Alphabet.BINARY, "1111")]
        [TestCase("1111", Alphabet.BINARY, Alphabet.DECIMAL, "15")]
        [TestCase("15", Alphabet.DECIMAL, Alphabet.HEXA_DECIMAL, "F")]
        [TestCase("F", Alphabet.HEXA_DECIMAL, Alphabet.DECIMAL, "15")]
        [TestCase("30A8", Alphabet.HEXA_DECIMAL, Alphabet.DECIMAL, "12456")]
        [TestCase("30A8", Alphabet.HEXA_DECIMAL, Alphabet.OCTAL, "30250")]
        [TestCase("hello", Alphabet.ALPHA_LOWER, Alphabet.HEXA_DECIMAL, "320048")]
        [TestCase("SAME", Alphabet.ALPHA_UPPER, Alphabet.ALPHA_UPPER, "SAME")]
        [TestCase("LOWER", Alphabet.ALPHA_UPPER, Alphabet.ALPHA_LOWER, "lower")]
        [TestCase("CodeWars", Alphabet.ALPHA, Alphabet.BINARY, "110100110111011111011110001100111111110000110")]
        public void ShouldConvertBetweenAlphabets(string input, string sAlphabet, string tAlphabet, string expected)
        {
            var result = _converter.Convert(input, sAlphabet, tAlphabet);
            result.Should().Be(expected);
        }
    }
}
