using WebRepeatedNumbersSieve.Models.ArrayTransformations;

namespace WebRepeatedNumbersSieve.Tests.Models.ArrayTransformations
{
    public class RepeatedElementsSieveUnitTests
    {
        [Test]
        public void ShouldReturnEmptyArrayForEmptyInputArray()
        {
            var sive = new RepeatedElementsSieve<int>(3);

            Assert.That(sive.Transform(Array.Empty<int>()).Length, Is.EqualTo(0));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 1, 1 }, new int[] { 1 })]
        [TestCase(new int[] { 9, 3, 3, 2, 1, 1, 1, 2, 9, 9, 9 }, new int[] { 9, 1 })]
        [TestCase(new int[] { 1, 1, 1, 1, 3, 3, 3, 3, 2, 1, 2, 9, 9, 9 }, new int[] { 9, 3, 1 })]
        [TestCase(new int[] { 1, 2, 3, 2, 1, 9, 9, 8 }, new int[] { })]
        public void ShouldReturnArrayWithNumbersRepeatedAtLeastThreeTimes(int[] inputArray, int[] expectedOutputArray)
        {
            var sive = new RepeatedElementsSieve<int>(3);
            var outputArray = sive.Transform(inputArray);

            Assert.That(outputArray.Length, Is.EqualTo(expectedOutputArray.Length));

            for (int i = 0; i < expectedOutputArray.Length; i++)
            {
                Assert.That(outputArray.Contains(expectedOutputArray[i]), Is.True);
            }
        }
    }
}
