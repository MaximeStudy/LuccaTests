using LuccaDevises.Parser;
using Xunit;

namespace LuccaDevises.Tests.Parser
{
    public class PositiveIntegerParserTest
    {
        [Fact]
        public void GivenAnAmountGreaterThanZero_ThenAmountIsValid()
        {
            //Given
            var positiveIntegerParser = new PositiveIntegerParser();

            //When
            var contentIsValid = positiveIntegerParser.IsValid("154");

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenAnAmountLowerThanZero_ThenAmountIsNotValid()
        {
            //Given
            var positiveIntegerParser = new PositiveIntegerParser();

            //When
            var contentIsValid = positiveIntegerParser.IsValid("-5");

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAnAmounEqualToZero_ThenAmountIsNotValid()
        {
            //Given
            var positiveIntegerParser = new PositiveIntegerParser();

            //When
            var contentIsValid = positiveIntegerParser.IsValid("0");

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAnAmountThatIsNotAnInteger_ThenAmountIsNotValid()
        {
            //Given
            var positiveIntegerParser = new PositiveIntegerParser();

            //When
            var contentIsValid = positiveIntegerParser.IsValid("5.5");

            //Then
            Assert.False(contentIsValid);
        }
    }
}