using FluentAssertions;
using NUnit.Framework;
using Solutions.PathFinder;

namespace SolutionsTests
{
    [TestFixture]
    public class PathFinderTests
    {
        [TestCase(".W.\n" +
                   ".W.\n" +
                   "...", true)]
        [TestCase(".W.\n" +
                   ".W.\n" +
                   "W..", false)]
        [TestCase("......\n" +
                   "......\n" +
                   "......\n" +
                   "......\n" +
                   "......\n" +
                   "......", true)]
        [TestCase("......\n" +
                  "......\n" +
                  "......\n" +
                  "......\n" +
                  ".....W\n" +
                  "....W.", false)]
        [TestCase(".......W\n" +
                  "WWWWWW.W\n" +
                  "...WWW.W\n" +
                  ".W.....W\n" +
                  ".WWWWWWW\n" +
                  ".WWWWWWW\n" +
                  "........", true)]
        [TestCase(".......W\n" +
                  "WWWWWW.W\n" +
                  "...WWW.W\n" +
                  ".W.....W\n" +
                  ".WWW.WWW\n" +
                  ".WWWWWWW\n" +
                  "........", true)]
        [TestCase(".W...\n" +
                  ".W...\n" +
                  ".W.W.\n" +
                  "...W.\n" +
                  "...W.", true)]
        public void CanYouExitTest(string maze, bool expected)
        {
            var pathFinder = new PathFinder();
            var result = pathFinder.CanYouExit(maze);

            result.Should().Be(expected);
        }
    }
}
