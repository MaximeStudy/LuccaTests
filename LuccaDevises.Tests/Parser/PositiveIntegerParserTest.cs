using LuccaDevises.Parser;
using Xunit;

namespace LuccaDevises.Tests.Parser
{
    public class PositiveIntegerParserTest : ParserTest
    {
        [Fact]
        public void GivenAnAmountGreaterThanZero_ThenAmountIsValid()
        {
            //Given
            var amountGreaterThanZero = "154";

            //When
            var contentIsValid = positiveIntegerParser.IsValid(amountGreaterThanZero);

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenAnAmountLowerThanZero_ThenAmountIsNotValid()
        {
            //Given
            var amountLowerThanZero = "-5";

            //When
            var contentIsValid = positiveIntegerParser.IsValid(amountLowerThanZero);

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAnAmountEqualToZero_ThenAmountIsNotValid()
        {
            //Given
            var amountEqualZero = "0";

            //When
            var contentIsValid = positiveIntegerParser.IsValid(amountEqualZero);

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAnAmountThatIsNotAnInteger_ThenAmountIsNotValid()
        {
            //Given
            var amountNotInteger = "5.5";

            //When
            var contentIsValid = positiveIntegerParser.IsValid(amountNotInteger);

            //Then
            Assert.False(contentIsValid);
        }
    }
}