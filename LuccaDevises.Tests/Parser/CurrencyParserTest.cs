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
            string currencyWithThreeLetter = "EUR";

            //When
            var parsedValue = currencyParser.Parse(currencyWithThreeLetter);

            //Then
            Assert.Equal(currencyWithThreeLetter, parsedValue);
        }

        [Fact]
        public void GivenACurrencyWithout3Letter_ThenIsNotValid()
        {
            //Given
            string currencyWithoutThreeLetter = "EU3aR";

            //When

            //Then
            Assert.Throws<ArgumentException>(() => currencyParser.Parse(currencyWithoutThreeLetter));
        }
    }
}