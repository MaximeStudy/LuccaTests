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

            //When
            var contentIsValid = exchangeRateParser.IsValid("86.0202");

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRate_ThenCurrencySymbolAreNotAccepted()
        {
            //Given

            //When
            var contentIsValid = exchangeRateParser.IsValid("86.0202$");

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRatePrecisionIsFourDecimals_ThenIsValid()
        {
            //Given

            //When
            var contentIsValid = exchangeRateParser.IsValid("86.0202");

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRatePrecisionWithoutFourDecimals_ThenIsNotValid()
        {
            //Given

            //When
            var contentIsValid = exchangeRateParser.IsValid("86.022");

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRateWithoutPrecision_ThenIsNotValid()
        {
            //Given

            //When
            var contentIsValid = exchangeRateParser.IsValid("86");

            //Then
            Assert.False(contentIsValid);
        }
    }
}