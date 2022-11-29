namespace WebRepeatedNumbersSieve.Models
{
    public interface IArrayParser<T>
    {
        T[] Parse(string arrayLiteral);
    }
}
