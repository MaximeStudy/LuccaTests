using LuccaDevises.Parser;
using Xunit;

namespace LuccaDevises.Tests.Parser
{
    public class FirstLineParserTest : ParserTest
    {
        [Fact]
        public void GivenAnEmptyFirstLine_ThenLineIsNotValid()
        {
            //Given
            var emptyLine = "";

            //When
            var contentIsValid = firstLineParser.IsValid(emptyLine);

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAFirstLineWithThreeElement_ThenTheLineShouldHaveThreeArgumentSeparatedBySemicolon()
        {
            //Given
            var lineWithThreeElement = "EUR;550;JPY";

            //When
            var contentIsValid = firstLineParser.IsValid(lineWithThreeElement);

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenAFirstLineWithoutThreeElement_ThenLineIsNotValid()
        {
            //Given
            var lineWithoutThreeElement = "EUR;550;JPY;4";

            //When
            var contentIsValid = firstLineParser.IsValid(lineWithoutThreeElement);

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAFirstLineWithThreeElementUnordered_ThenLineIsNotValid()
        {
            //Given
            var lineWithThreeElementUnordered = "550;EUR;JPY";

            //When
            var contentIsValid = firstLineParser.IsValid(lineWithThreeElementUnordered);

            //Then
            Assert.False(contentIsValid);
        }
    }
}