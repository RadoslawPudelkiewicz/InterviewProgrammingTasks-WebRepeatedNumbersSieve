namespace WebRepeatedNumbersSieve.Models.ArrayTransformations
{
    public class RepeatedElementsSieve<T> : IArrayTransformation<T> where T : IComparable<T>
    {
        private readonly int _minimumRepetitions;

        public RepeatedElementsSieve(int minimumRepetitions)
        {
            _minimumRepetitions = minimumRepetitions;
        }

        public T[] Transform(T[] arrayToTransform)
        {   
            return arrayToTransform.Distinct().Where(x => arrayToTransform.Count(y => y.Equals(x)) >= _minimumRepetitions).ToArray();
        }
    }
}
