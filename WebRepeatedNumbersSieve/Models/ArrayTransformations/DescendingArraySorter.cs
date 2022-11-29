namespace WebRepeatedNumbersSieve.Models.ArrayTransformations
{
    public class DescendingArraySorter<T> : IArrayTransformation<T> where T : IComparable<T>
    {
        public T[] Transform(T[] arrayToTransform)
        {
            return arrayToTransform.OrderByDescending(x => x).ToArray();
        }
    }
}
