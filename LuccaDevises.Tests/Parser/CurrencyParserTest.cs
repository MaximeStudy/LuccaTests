using LuccaDevises.Parser;
using System;
using Xunit;

namespace LuccaDevises.Tests.Parser
{
    public class CurrencyParserTest : ParserTest
    {
        [Fact]
        public void GivenACurrencyWith3Letter_ThenIsValid()
        {
            //Given
            string expectedResult = "EUR";
            //When

            var parsedValue = currencyParser.Parse("EUR");

            //Then
            Assert.Equal(expectedResult, parsedValue);
        }

        [Fact]
        public void GivenACurrencyWithout3Letter_ThenIsNotValid()
        {
            //Given

            //When

            //Then
            Assert.Throws<ArgumentException>(() => currencyParser.Parse("EU3aR"));
        }
    }
}