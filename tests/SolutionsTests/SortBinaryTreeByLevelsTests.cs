using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Solutions.SortBinaryTreeByLevels;

namespace SolutionsTests
{
    [TestFixture]
    public class SortBinaryTreeByLevelsTests
    {
        [Test, TestCaseSource(nameof(TestData))]
        public void ShouldReturnCorrectList(Node tree, List<int> expectedArray)
        {
            var result = new SortBinaryTreeByLevels().Sort(tree);
            result.Should().BeEquivalentTo(expectedArray, o => o.WithStrictOrdering());
        }

        static object[] TestData =
        {
            new object[]{null, new List<int>()},
            new object[]{new Node(
                new Node(
                    new Node(1), new Node(3), 8),
                new Node(
                    new Node(4), new Node(5),9), 2), new List<int>{2,8,9,1,3,4,5}},
            new object[]{new Node(
                new Node(null, new Node(3), 8),
                new Node(null, new Node(null, new Node(7), 5), 4), 1), new List<int> { 1, 8, 4, 3, 5, 7 } }
        };
    }
}