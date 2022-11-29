using WebRepeatedNumbersSieve.Models.ArraySerializers;

namespace WebRepeatedNumbersSieve.Tests.Models.ArraySerializers
{
    public class IntegerArraySerializerUnitTests
    {
        [TestCase(new int[] { }, "[]")]
        [TestCase(new int[] { 4 }, "[4]")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 1, 1 }, "[1,2,3,4,5,1,1]")]
        public void ShouldSerializeArrayToArrayLiteral(int[] inputArray, string expectedOutputArrayLiteral)
        {
            var serializer = new IntegerArraySerializer();

            Assert.That(serializer.Serialize(inputArray), Is.EqualTo(expectedOutputArrayLiteral));
        }
    }
}
