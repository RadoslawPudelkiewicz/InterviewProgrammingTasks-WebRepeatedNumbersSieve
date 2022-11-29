namespace WebRepeatedNumbersSieve.Models.LiteralTransformationEngines
{
    public class ArrayLiteralTransformationEngine<T> : ILiteralTransformationEngine
    {
        private readonly IArrayParser<T> _parser;
        private readonly IArraySerializer<T> _serializer;
        private readonly IEnumerable<IArrayTransformation<T>> _arrayTransformations;
        

        public ArrayLiteralTransformationEngine(
            IArrayParser<T> parser,
            IArraySerializer<T> serializer,
            IEnumerable<IArrayTransformation<T>> arrayTransformations)
        {
            _parser = parser;
            _serializer = serializer;
            _arrayTransformations = arrayTransformations;
        }

        public string DoLiteralTransformation(string literal)
        {
            try
            {
                //var arr = IntegerArray.Parse(literal);
                var arr = _parser.Parse(literal);

                foreach (var transformations in _arrayTransformations)
                {
                    arr = transformations.Transform(arr);
                }

                return _serializer.Serialize(arr);
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException)
            {
                return ex.Message;
            }
        }
    }
}
