using System.Text;

namespace WebRepeatedNumbersSieve.Models.ArraySerializers
{
    public class IntegerArraySerializer : IArraySerializer<int>
    {
        public string Serialize(int[] arrayToSerialize)
        {
            StringBuilder arrayLiteralBuilder = new StringBuilder();

            arrayLiteralBuilder.Append('[');

            if (arrayToSerialize.Length > 0)
            {
                arrayLiteralBuilder.Append(arrayToSerialize[0]);
            }

            for (int i = 1; i < arrayToSerialize.Length; i++)
            {
                arrayLiteralBuilder.Append(',');
                arrayLiteralBuilder.Append(arrayToSerialize[i]);
            }

            arrayLiteralBuilder.Append(']');

            return arrayLiteralBuilder.ToString();
        }
    }
}
