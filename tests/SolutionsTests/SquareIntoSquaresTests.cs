using FluentAssertions;
using NUnit.Framework;
using Solutions.SquareIntoSquares;

namespace SolutionsTests
{
    [TestFixture]
    public class SquareIntoSquaresTests
    {
        [TestCase(11, "1 2 4 10")]
        [TestCase(50, "1 3 5 8 49")]
        [TestCase(70, "1 2 3 5 10 69")]
        [TestCase(12, "1 2 3 7 9")]
        [TestCase(625, "2 5 8 34 624")]
        [TestCase(7100, "2 3 5 119 7099")]
        [TestCase(1234567, "2 8 32 1571 1234566")]
        [TestCase(6, null)]
        public void ShouldBreakDownSequance(long number, string expected)
        {
            var solution = new SquareIntoSquares();
            var result = solution.Decompose(number);

            result.Should().Be(expected);
        }
    }
}
