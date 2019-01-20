using FluentAssertions;
using NUnit.Framework;
using Solutions.MaximumSumSubArray;
using System.Collections;

namespace SolutionsTests
{
    [TestFixture]
    public class MaximumSumSubArrayTests
    {
        [Test]
        [TestCaseSource(nameof(TestData))]
        public void ShouldReturnCorrectSum(int[] array, int expectedSum)
        {
            var result = MaximumSumSubArray.MaxSequence(array);
            result.Should().Be(expectedSum);
        }

        public static IEnumerable TestData()
        {
            yield return new TestCaseData(new int[0], 0).SetName("EmptyArray");
            yield return new TestCaseData(new[] { -1, -2, -3 }, 0).SetName("AllNegativeNumbers");
            yield return new TestCaseData(new[] { 5 }, 5).SetName("SingleElementInTheArray");
            yield return new TestCaseData(new[] { 1, 2, 3, 4 }, 10).SetName("AllPositiveNumbers");
            yield return new TestCaseData(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6);
            yield return new TestCaseData(new[] { -19, 7, 4, -16, -10, -23, -26, -15, -1, -13, 7, -25, 17, 24, 19, -25, -30, -10, -1, 13, -15, 6, -18, 2, -26, 26, 3, -8, -22, -16, -11, 11, 9, 2, 25, 14, -18, 26, -12, -8, -28, -29, 21, 10, -14, -4, -30, 20, -20, 3 }, 69);
        }
    }
}
