using LuccaDevises.Parser;
using Xunit;

namespace LuccaDevises.Tests.Parser
{
    public class SecondLineParserTest
    {
        [Fact]
        public void GivenASecondLineWithPositiveInteger_ThenLineIsValid()
        {
            //Given
            var secondLineParser = new SecondLineParser();

            //When
            var contentIsValid = secondLineParser.IsValid("54");

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenASecondLineWithoutInteger_ThenLineIsNotValid()
        {
            //Given
            var secondLineParser = new SecondLineParser();

            //When
            var contentIsValid = secondLineParser.IsValid("54;PCD");

            //Then
            Assert.False(contentIsValid);
        }
    }
}