using LuccaDevises.Parser;
using Xunit;

namespace LuccaDevises.Tests.Parser
{
    public class ExchangeRateParserTest
    {
        [Fact]
        public void GivenExchangeRate_ThenSeparatorIsPoint()
        {
            //Given
            var exchangeRateParser = new ExchangeRateParser();

            //When
            var contentIsValid = exchangeRateParser.IsValid("86.0202");

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRate_ThenCurrencySymbolAreNotAccepted()
        {
            //Given
            var exchangeRateParser = new ExchangeRateParser();

            //When
            var contentIsValid = exchangeRateParser.IsValid("86.0202$");

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRatePrecisionIsFourDecimals_ThenIsValid()
        {
            //Given
            var exchangeRateParser = new ExchangeRateParser();

            //When
            var contentIsValid = exchangeRateParser.IsValid("86.0202");

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRatePrecisionWithoutFourDecimals_ThenIsNotValid()
        {
            //Given
            var exchangeRateParser = new ExchangeRateParser();

            //When
            var contentIsValid = exchangeRateParser.IsValid("86.022");

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRateWithoutPrecision_ThenIsNotValid()
        {
            //Given
            var exchangeRateParser = new ExchangeRateParser();

            //When
            var contentIsValid = exchangeRateParser.IsValid("86");

            //Then
            Assert.False(contentIsValid);
        }
    }
}