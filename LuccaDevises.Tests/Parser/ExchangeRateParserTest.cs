using LuccaDevises.Parser;
using Xunit;

namespace LuccaDevises.Tests.Parser
{
    public class ExchangeRateParserTest : ParserTest
    {
        [Fact]
        public void GivenExchangeRate_ThenSeparatorIsPoint()
        {
            //Given
            var anExchangeRate = "86.0202";

            //When
            var contentIsValid = exchangeRateParser.IsValid(anExchangeRate);

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRate_ThenCurrencySymbolAreNotAccepted()
        {
            //Given
            var anExchangeRateWithCurrency = "86.0202$";

            //When
            var contentIsValid = exchangeRateParser.IsValid(anExchangeRateWithCurrency);

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRatePrecisionIsFourDecimals_ThenIsValid()
        {
            //Given
            var anExchangeWithFourDecimal = "86.0202";

            //When
            var contentIsValid = exchangeRateParser.IsValid(anExchangeWithFourDecimal);

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRatePrecisionWithoutFourDecimals_ThenIsNotValid()
        {
            //Given
            var anExchangeWithoutFourDecimal = "86.022";

            //When
            var contentIsValid = exchangeRateParser.IsValid(anExchangeWithoutFourDecimal);

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRateWithoutPrecision_ThenIsNotValid()
        {
            //Given
            var anExchangeWithoutPrecision = "86";

            //When
            var contentIsValid = exchangeRateParser.IsValid(anExchangeWithoutPrecision);

            //Then
            Assert.False(contentIsValid);
        }
    }
}