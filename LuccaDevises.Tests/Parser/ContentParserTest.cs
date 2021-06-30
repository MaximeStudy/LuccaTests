using System;
using System.Collections.Generic;
using Xunit;

namespace LuccaDevises.Tests.Parser
{
    public class ContentParserTest : ParserTest
    {
        [Fact]
        public void GivenAFileWithZeroLine_ThenContentIsNotValid()
        {
            //Given
            List<string> fileContent = new List<string>();

            //When

            //Then
            Assert.Throws<ArgumentException>(() => contentParser.Parse(fileContent));
        }

        [Fact]
        public void GivenAFileContentWithMoreThanTwoLines_ThenFileContentIsValid()
        {
            //Given
            List<string> fileContent = new List<string>();
            fileContent.Add("EUR;550;JPY");
            fileContent.Add("1");
            fileContent.Add("AUD;CHF;0.9661");

            //When
            var parsedValue = contentParser.Parse(fileContent);

            //Then
            Assert.NotNull(parsedValue?.TransformationGoal);
            Assert.NotNull(parsedValue?.ExchangeRates);
        }

        [Fact]
        public void GivenAFileContent_ThenTheNumberOfExchangeRateAreTheSameAsTheSecondLine()
        {
            //Given
            List<string> fileContent = new List<string>();
            fileContent.Add("EUR;550;JPY");
            fileContent.Add("2");
            fileContent.Add("AUD;CHF;0.9661");
            fileContent.Add("JPY;CHF;0.9661");
            var expectedNumberExchangeRate = 2;

            //When
            var parsedValue = contentParser.Parse(fileContent);

            //Then
            Assert.Equal(expectedNumberExchangeRate, parsedValue.ExchangeRates.Count);
        }

        [Fact]
        public void GivenAFileContentWithoutFittingExchangeRateWithNumber_ThenContentIsNotValid()
        {
            //Given
            List<string> fileContent = new List<string>();
            fileContent.Add("EUR;550;JPY");
            fileContent.Add("4");
            fileContent.Add("AUD;CHF;0.9661");
            fileContent.Add("AUD;CFG;0.9661");

            //When

            //Then
            Assert.Throws<ArgumentException>(() => contentParser.Parse(fileContent));
        }

        [Fact]
        public void GivenAFileContentWithErrorInANthElement_ThenContentIsNotValid()
        {
            //Given
            List<string> fileContent = new List<string>();
            fileContent.Add("EUR;550;JPY");
            fileContent.Add("4");
            fileContent.Add("AUD;CHF;0.9661");
            fileContent.Add("AUD;CFG;0.9661");
            fileContent.Add("AUD;CHF;0.9661");
            fileContent.Add("AUD;CHF;0.9");

            //When

            //Then
            Assert.Throws<ArgumentException>(() => contentParser.Parse(fileContent));
        }
    }
}