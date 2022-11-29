namespace WebRepeatedNumbersSieve.Models
{
    public interface IArraySerializer<T>
    {
        string Serialize(T[] arrayToSerialize);
    }
}
