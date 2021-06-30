using LuccaDevises.Domain;
using System;
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

            //Then
            Assert.Throws<ArgumentException>(() => firstLineParser.Parse(emptyLine));
        }

        [Fact]
        public void GivenAFirstLineWithThreeElement_ThenTheLineShouldHaveThreeArgumentSeparatedBySemicolon()
        {
            //Given
            var lineWithThreeElement = "EUR;550;JPY";
            var expectedResult = new TransformationGoal()
            {
                InitialAmount = 550,
                InitialCurrency = "EUR",
                TargetCurrency = "JPY"
            };

            //When
            var parsedValue = firstLineParser.Parse(lineWithThreeElement);

            //Then
            Assert.Equal(expectedResult, parsedValue);
        }

        [Fact]
        public void GivenAFirstLineWithoutThreeElement_ThenLineIsNotValid()
        {
            //Given
            var lineWithoutThreeElement = "EUR;550;JPY;4";

            //When

            //Then
            Assert.Throws<ArgumentException>(() => firstLineParser.Parse(lineWithoutThreeElement));
        }

        [Fact]
        public void GivenAFirstLineWithThreeElementUnordered_ThenLineIsNotValid()
        {
            //Given
            var lineWithThreeElementUnordered = "550;EUR;JPY";

            //When

            //Then
            Assert.Throws<ArgumentException>(() => firstLineParser.Parse(lineWithThreeElementUnordered));
        }
    }
}