using IPValidation;
using NUnit.Framework;

namespace KataTests
{
    [TestFixture]
    public class IPValidatorTest
    {
        [TestCase("1.1.1.1", true)]
        [TestCase("255.255.255.255", true)]
        [TestCase("0.0.0.0", true)]
        [TestCase("134.167.145.23", true)]
        [TestCase("12.255.56.1", true)]
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase("256.1.1.1", false)]
        [TestCase("1.256.1.1", false)]
        [TestCase("1.1.256.1", false)]
        [TestCase("1.1.1.256", false)]
        [TestCase("-12.23.1.1", false)]
        [TestCase("34.23.-1.1", false)]
        [TestCase("12.34.56 .1", false)]
        [TestCase("123.045.067.089", false)]
        public void Test(string potentialAddress, bool expectedResult)
        {
            var validator = new IPValidator();
            var result = validator.IsValid(potentialAddress);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
