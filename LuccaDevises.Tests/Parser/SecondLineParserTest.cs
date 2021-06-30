using System;
using Xunit;

namespace LuccaDevises.Tests.Parser
{
    public class SecondLineParserTest : ParserTest
    {
        [Fact]
        public void GivenASecondLineWithPositiveInteger_ThenLineIsValid()
        {
            //Given
            var positiveInteger = "54";
            int expectedIntValue = 54;

            //When
            var parsedValue = secondLineParser.Parse(positiveInteger);

            //Then
            Assert.Equal(expectedIntValue, parsedValue);
        }

        [Fact]
        public void GivenASecondLineWithoutInteger_ThenLineIsNotValid()
        {
            //Given
            var lineWithoutInteger = "54;PCD";

            //When

            //Then
            Assert.Throws<ArgumentException>(() => secondLineParser.Parse(lineWithoutInteger));
        }
    }
}