using NUnit.Framework;
using Solutions.ReversedWords;

namespace SolutionsTests
{
    [TestFixture]
    public class ReversedWordsTest
    {
        [Test]
        public void ReversedWords_Basic()
        {
            Assert.AreEqual("world! hello", ReversedWords.ReverseWords("hello world!"));
            Assert.AreEqual("this like speak doesn't yoda", ReversedWords.ReverseWords("yoda doesn't speak like this"));
            Assert.AreEqual("foobar", ReversedWords.ReverseWords("foobar"));
            Assert.AreEqual("kata editor", ReversedWords.ReverseWords("editor kata"));
            Assert.AreEqual("boat your row row row", ReversedWords.ReverseWords("row row row your boat"));
            Assert.AreEqual("world! Hello,", ReversedWords.ReverseWords("Hello, world!"));
        }
    }
}
