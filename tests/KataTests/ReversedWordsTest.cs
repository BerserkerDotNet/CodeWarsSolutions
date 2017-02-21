using NUnit.Framework;
using ReversedWords;

namespace KataTests
{
    [TestFixture]
    public class ReversedWordsTest
    {
        [Test]
        public void ReversedWords_Basic()
        {
            Assert.AreEqual("world! hello", Kata.ReverseWords("hello world!"));
            Assert.AreEqual("this like speak doesn't yoda", Kata.ReverseWords("yoda doesn't speak like this"));
            Assert.AreEqual("foobar", Kata.ReverseWords("foobar"));
            Assert.AreEqual("kata editor", Kata.ReverseWords("editor kata"));
            Assert.AreEqual("boat your row row row", Kata.ReverseWords("row row row your boat"));
            Assert.AreEqual("world! Hello,", Kata.ReverseWords("Hello, world!"));
        }
    }
}
