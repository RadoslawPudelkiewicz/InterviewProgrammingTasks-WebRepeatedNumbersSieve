using WebRepeatedNumbersSieve.Models.ArrayTransformations;

namespace WebRepeatedNumbersSieve.Tests.Models.ArrayTransformations
{
    public class DescendingArraySorterUnitTests
    {
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 1, 3, 4, 3, 5, }, new int[] { 5, 4, 3, 3, 2, 1, 1 })]
        public void ShouldSortInDescendingOrder(int[] inputArray, int[] expectedOutputArray)
        {
            var sorter = new DescendingArraySorter<int>();

            Assert.IsTrue(Enumerable.SequenceEqual(expectedOutputArray, sorter.Transform(inputArray)));
        }
    }
}
