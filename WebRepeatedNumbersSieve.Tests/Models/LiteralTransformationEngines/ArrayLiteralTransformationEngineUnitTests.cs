using WebRepeatedNumbersSieve.Models;
using WebRepeatedNumbersSieve.Models.LiteralTransformationEngines;

namespace WebRepeatedNumbersSieve.Tests.Models.LiteralTransformationEngines
{
    public class ArrayLiteralTransformationEngineUnitTests
    {
        [Test]
        public void ShouldTransformArrayLiteral()
        {
            var arrayLiteral = "[1,2]";

            var parserMock = new Mock<IArrayParser<int>>();
            parserMock.Setup(p => p.Parse(arrayLiteral))
                .Returns(new int[] { 1, 2 });

            var serializerMock = new Mock<IArraySerializer<int>>();
            serializerMock.Setup(s => s.Serialize(new int[] { 1, 2, 3, 4 }))
                .Returns("[1,2,3,4]");

            var firstTransformation = new Mock<IArrayTransformation<int>>();
            firstTransformation.Setup(t => t.Transform(new int[] { 1, 2 }))
                .Returns(new int[] { 1, 2, 3 });

            var secoundTransformation = new Mock<IArrayTransformation<int>>();
            secoundTransformation.Setup(t => t.Transform(new int[] { 1, 2, 3 }))
                .Returns(new int[] { 1, 2, 3, 4 });

            var engine = new ArrayLiteralTransformationEngine<int>(parserMock.Object, serializerMock.Object,
                new IArrayTransformation<int>[] { firstTransformation.Object, secoundTransformation.Object });

            Assert.That(engine.DoLiteralTransformation(arrayLiteral), Is.EqualTo("[1,2,3,4]"));
        }
    }
}
