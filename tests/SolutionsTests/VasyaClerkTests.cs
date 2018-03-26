using FluentAssertions;
using NUnit.Framework;
using Solutions.VasyaClerk;

namespace SolutionsTests
{
    [TestFixture]
    public class VasyaClerkTests
    {
        [Test]
        public void ShouldHandleEmptyLine()
        {
            var clerk = new VasyaClerk();
            var result = clerk.CanSellToAll(new int[0]);

            result.Should().NotBeNullOrEmpty();
            result.Should().Be(VasyaClerk.No);
        }

        [TestCase(new int[] { 25, 25, 25, 25, 25, 100, 100 }, VasyaClerk.No)]
        [TestCase(new int[] { 25, 25, 50, 50 }, VasyaClerk.Yes)]
        [TestCase(new int[] { 25, 100 }, VasyaClerk.No)]
        public void ShouldSayIfCanSell(int[] input, string expectedResult)
        {
            var clerk = new VasyaClerk();
            var result = clerk.CanSellToAll(input);

            result.Should().NotBeNullOrEmpty();
            result.Should().Be(expectedResult);
        }
    }
}
