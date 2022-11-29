namespace WebRepeatedNumbersSieve.Models.ArrayParsers
{
    public class IntegerArrayParser : IArrayParser<int>
    {
        public int[] Parse(string arrayLiteral)
        {
            if (arrayLiteral == null)
            {
                throw new ArgumentNullException("No array literal specified!");
            }

            arrayLiteral = arrayLiteral.Trim();

            if (!arrayLiteral.StartsWith('['))
            {
                throw new ArgumentException("Array literal should start with '[' character!");
            }

            if (!arrayLiteral.EndsWith(']'))
            {
                throw new ArgumentException("Array literal should end with ']' character!");
            }

            var elementLiterals = arrayLiteral.Substring(1, arrayLiteral.Length - 2).Split(',');

            if (elementLiterals.Length == 1 && String.IsNullOrWhiteSpace(elementLiterals[0]))
            {
                return Array.Empty<int>();
            }

            var intArray = new int[elementLiterals.Length];            
            int element;

            for (int i = 0; i < elementLiterals.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(elementLiterals[i]))
                {
                    throw new ArgumentException($"Element at index: {i} of the array should be specified!");
                }

                if (!int.TryParse(elementLiterals[i].Trim(), out element))
                {
                    throw new ArgumentException($"Can not parse to integer an element '{elementLiterals[i].Trim()}' at index: {i} of the array!");
                }

                intArray[i] = element;
            }

            return intArray;
        }
    }
}
