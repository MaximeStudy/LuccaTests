using LuccaDevises.Parser;
using Xunit;

namespace LuccaDevises.Tests.Parser
{
    public class FirstLineParserTest
    {
        [Fact]
        public void GivenAnEmptyFirstLine_ThenLineIsNotValid()
        {
            //Given
            var firstLineParser = new FirstLineParser();

            //When
            var contentIsValid = firstLineParser.IsValid("");

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAFirstLineWithThreeElement_ThenTheLineShouldHaveThreeArgumentSeparatedBySemicolon()
        {
            //Given
            var firstLineParser = new FirstLineParser();

            //When
            var contentIsValid = firstLineParser.IsValid("EUR;550;JPY");

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenAFirstLineWithoutThreeElement_ThenLineIsNotValid()
        {
            //Given
            var firstLineParser = new FirstLineParser();

            //When
            var contentIsValid = firstLineParser.IsValid("EUR;550;JPY;4");

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAFirstLineWithThreeElementUnordered_ThenLineIsNotValid()
        {
            //Given
            var firstLineParser = new FirstLineParser();

            //When
            var contentIsValid = firstLineParser.IsValid("550;EUR;JPY");

            //Then
            Assert.False(contentIsValid);
        }
    }
}