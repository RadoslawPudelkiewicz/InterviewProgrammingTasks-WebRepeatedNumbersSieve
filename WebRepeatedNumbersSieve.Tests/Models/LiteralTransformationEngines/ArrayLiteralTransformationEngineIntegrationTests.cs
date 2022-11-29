using WebRepeatedNumbersSieve.Models;
using WebRepeatedNumbersSieve.Models.ArrayParsers;
using WebRepeatedNumbersSieve.Models.ArraySerializers;
using WebRepeatedNumbersSieve.Models.ArrayTransformations;
using WebRepeatedNumbersSieve.Models.LiteralTransformationEngines;

namespace WebRepeatedNumbersSieve.Tests.Models.LiteralTransformationEngines
{
    public class ArrayLiteralTransformationEngineIntegrationTests
    {
        [TestCase("[1,2,3,4,5,1,1]", "[1]")]
        [TestCase("[9,3,3,2,1,1,1,2,9,9,9]", "[9,1]")]
        [TestCase("[1,1,1,1,3,3,3,3,2,1,2,9,9,9]", "[9,3,1]")]
        [TestCase("[1,2,3,2,1,9,9,8]", "[]")]
        public void ShoudSiftRepeatedNumbersInArrayLiteral(string inputArrayLiteral, string expectedOutputArrayLiteral)
        {
            var engine = new ArrayLiteralTransformationEngine<int>(
                new IntegerArrayParser(), 
                new IntegerArraySerializer(),
                new IArrayTransformation<int>[] { 
                    new RepeatedElementsSieve<int>(3),
                    new DescendingArraySorter<int>() });

            Assert.That(engine.DoLiteralTransformation(inputArrayLiteral), Is.EqualTo(expectedOutputArrayLiteral));
        }
    }
}
