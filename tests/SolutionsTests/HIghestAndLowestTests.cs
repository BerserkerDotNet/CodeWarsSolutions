using FluentAssertions;
using NUnit.Framework;
using Solutions.HIghestAndLowest;

namespace SolutionsTests
{
    [TestFixture]
    public class HIghestAndLowestTests
    {
        [TestCase("")]
        [TestCase(null)]
        public void ShouldHandleEmptyString(string input)
        {
            var solution = new HighestAndLowest();
            var result = solution.HighAndLow(input);
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Test]
        public void ShouldHandleSingleNumberString()
        {
            const string input = "3";
            var solution = new HighestAndLowest();
            var result = solution.HighAndLow(input);
            result.Should().NotBeNull();
            result.Should().Be($"{input} {input}");
        }

        [TestCase("1 3", "3 1")]
        [TestCase("1   3", "3 1")]
        [TestCase("1   3   6   -3", "6 -3")]
        [TestCase("234123434 234 342345 54656 1234 1234 5467 1234", "234123434 234")]
        [TestCase("8 3 -5 42 -1 0 0 -9 4 7 4 -4", "42 -9")]
        public void ShouldReturnMinMaxNumbers(string input, string expected)
        {
            var solution = new HighestAndLowest();
            var result = solution.HighAndLow(input);
            result.Should().NotBeNull();
            result.Should().Be(expected);
        }
    }
}
