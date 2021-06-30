using LuccaDevises.Parser;
using Xunit;

namespace LuccaDevises.Tests.Parser
{
    public class CurrencyParserTest
    {
        [Fact]
        public void GivenACurrencyWith3Letter_ThenIsValid()
        {
            //Given
            var currencyParser = new CurrencyParser();

            //When
            var contentIsValid = currencyParser.IsValid("EUR");

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenACurrencyWithout3Letter_ThenIsNotValid()
        {
            //Given
            var currencyParser = new CurrencyParser();

            //When
            var contentIsValid = currencyParser.IsValid("EU3aR");

            //Then
            Assert.False(contentIsValid);
        }
    }
}