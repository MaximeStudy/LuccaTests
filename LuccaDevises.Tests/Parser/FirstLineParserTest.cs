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

            //When
            var contentIsValid = firstLineParser.IsValid("");

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAFirstLineWithThreeElement_ThenTheLineShouldHaveThreeArgumentSeparatedBySemicolon()
        {
            //Given

            //When
            var contentIsValid = firstLineParser.IsValid("EUR;550;JPY");

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenAFirstLineWithoutThreeElement_ThenLineIsNotValid()
        {
            //Given

            //When
            var contentIsValid = firstLineParser.IsValid("EUR;550;JPY;4");

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAFirstLineWithThreeElementUnordered_ThenLineIsNotValid()
        {
            //Given

            //When
            var contentIsValid = firstLineParser.IsValid("550;EUR;JPY");

            //Then
            Assert.False(contentIsValid);
        }
    }
}