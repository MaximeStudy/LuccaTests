using System;
using Xunit;

namespace LuccaDevises.Services.Tests.Parser
{
    public class ExchangeRateParserTest : ParserTest
    {
        [Fact]
        public void GivenExchangeRate_ThenSeparatorIsPoint()
        {
            //Given
            var anExchangeRate = "86.0202";
            decimal expectedExchangeRate = 86.0202M;

            //When
            var exchangeRate = exchangeRateParser.Parse(anExchangeRate);

            //Then
            Assert.Equal(expectedExchangeRate, exchangeRate);
        }

        [Fact]
        public void GivenExchangeRate_ThenCurrencySymbolAreNotAccepted()
        {
            //Given
            var anExchangeRateWithCurrency = "86.0202$";

            //When

            //Then
            Assert.Throws<ArgumentException>(() => exchangeRateParser.Parse(anExchangeRateWithCurrency));
        }

        [Fact]
        public void GivenExchangeRatePrecisionIsFourDecimals_ThenIsValid()
        {
            //Given
            var anExchangeWithFourDecimal = "86.0202";
            decimal expectedExchangeRate = 86.0202M;

            //When
            var exchangeRate = exchangeRateParser.Parse(anExchangeWithFourDecimal);

            //Then
            Assert.Equal(expectedExchangeRate, exchangeRate);
        }

        [Fact]
        public void GivenExchangeRatePrecisionWithoutFourDecimals_ThenIsNotValid()
        {
            //Given
            var anExchangeWithoutFourDecimal = "86.022";

            //When

            //Then
            Assert.Throws<ArgumentException>(() => exchangeRateParser.Parse(anExchangeWithoutFourDecimal));
        }

        [Fact]
        public void GivenExchangeRateWithoutPrecision_ThenIsNotValid()
        {
            //Given
            var anExchangeWithoutPrecision = "86";

            //When

            //Then
            Assert.Throws<ArgumentException>(() => exchangeRateParser.Parse(anExchangeWithoutPrecision));
        }
    }
}