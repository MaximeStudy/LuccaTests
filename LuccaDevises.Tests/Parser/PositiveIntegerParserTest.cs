using LuccaDevises.Parser;
using System;
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
            int expectedResult = 154;

            //When
            var parsedValue = positiveIntegerParser.Parse(amountGreaterThanZero);

            //Then
            Assert.Equal(expectedResult, parsedValue);
        }

        [Fact]
        public void GivenAnAmountLowerThanZero_ThenAmountIsNotValid()
        {
            //Given
            var amountLowerThanZero = "-5";

            //When

            //Then
            Assert.Throws<ArgumentException>(() => positiveIntegerParser.Parse(amountLowerThanZero));
        }

        [Fact]
        public void GivenAnAmountEqualToZero_ThenAmountIsNotValid()
        {
            //Given
            var amountEqualZero = "0";

            //When

            //Then
            Assert.Throws<ArgumentException>(() => positiveIntegerParser.Parse(amountEqualZero));
        }

        [Fact]
        public void GivenAnAmountThatIsNotAnInteger_ThenAmountIsNotValid()
        {
            //Given
            var amountNotInteger = "5.5";

            //When

            //Then
            Assert.Throws<ArgumentException>(() => positiveIntegerParser.Parse(amountNotInteger));
        }
    }
}