using WebRepeatedNumbersSieve.Models.ArrayParsers;

namespace WebRepeatedNumbersSieve.Tests.Models.ArrayParsers
{
    public class IntegerArrayParserUnitTests
    {
        private readonly IntegerArrayParser _parser = new IntegerArrayParser();

        [Test]
        public void ShouldThrowArgumentExceptionForIncorrectArrayLiteral()
        {
            Assert.Throws<ArgumentNullException>(() => _parser.Parse(null));
        }


        [TestCase("")]
        [TestCase("   ")]
        [TestCase("1,2,3,4,5,1,1")]
        [TestCase("[1,2,3,4,5,1,1")]
        [TestCase("1,2,3,4,5,1,1]")]
        [TestCase("[112, ,2,1,9,9,8]")]
        [TestCase("[112, he3,2,1,9,9,8]")]
        public void ShouldThrowArgumentExceptionForIncorrectArrayLiteral(string inputArrayLiteral)
        {
            Assert.Throws<ArgumentException>(() => _parser.Parse(inputArrayLiteral));
        }

        [TestCase("[]", new int[] { })]
        [TestCase("[4]", new int[] { 4 })]
        [TestCase("[1,2,3,4,5,1,1]", new int[] { 1, 2, 3, 4, 5, 1, 1 })]
        public void ShouldParseArrayLiteral(string inputArrayLiteral, int[] expectedOutputArray)
        {
            Assert.IsTrue(Enumerable.SequenceEqual(expectedOutputArray, _parser.Parse(inputArrayLiteral)));
        }
    }
}
