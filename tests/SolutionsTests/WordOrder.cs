using FluentAssertions;
using NUnit.Framework;
using Solutions.WordOrder;

namespace SolutionsTests
{
    [TestFixture]
    public class WordOrderTests
    {
        [Test]
        public void ShouldReturnEmptyString([Values(null, "")] string input)
        {
            var result = WordOrder.Order(input);
            result.Should().BeEmpty();
        }

        [TestCase("is2 Thi1s T4est 3a", "Thi1s is2 3a T4est")]
        [TestCase("4of Fo1r pe6ople g3ood th5e the2", "Fo1r the2 g3ood 4of th5e pe6ople")]
        [TestCase("3 6 4 2 8 7 5 1 9", "1 2 3 4 5 6 7 8 9")]
        public void ShouldOrderWords(string input, string expected)
        {
            var result = WordOrder.Order(input);
            result.Should().Be(expected);
        }
    }
}
