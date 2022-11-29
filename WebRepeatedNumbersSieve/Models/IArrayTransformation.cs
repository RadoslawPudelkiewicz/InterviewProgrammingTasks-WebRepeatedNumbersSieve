namespace WebRepeatedNumbersSieve.Models
{
    public interface IArrayTransformation<T>
    {
        T[] Transform(T[] arrayToTransform);
    }
}
