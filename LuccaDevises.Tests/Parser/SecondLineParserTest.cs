using LuccaDevises.Parser;
using Xunit;

namespace LuccaDevises.Tests.Parser
{
    public class SecondLineParserTest : ParserTest
    {
        [Fact]
        public void GivenASecondLineWithPositiveInteger_ThenLineIsValid()
        {
            //Given

            //When
            var contentIsValid = secondLineParser.IsValid("54");

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenASecondLineWithoutInteger_ThenLineIsNotValid()
        {
            //Given

            //When
            var contentIsValid = secondLineParser.IsValid("54;PCD");

            //Then
            Assert.False(contentIsValid);
        }
    }
}