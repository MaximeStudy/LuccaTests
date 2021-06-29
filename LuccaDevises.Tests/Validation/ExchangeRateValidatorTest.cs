using LuccaDevises.Validation;
using Xunit;

namespace LuccaDevises.Tests.Validation
{
    public class ExchangeRateValidatorTest
    {
        [Fact]
        public void GivenExchangeRate_ThenSeparatorIsPoint()
        {
            //Given
            IValidator exchangeRateValidator = new ExchangeRateValidator("86.0202");

            //When
            var contentIsValid = exchangeRateValidator.IsValid();

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRate_ThenCurrencySymbolAreNotAccepted()
        {
            //Given
            IValidator exchangeRateValidator = new ExchangeRateValidator("86.0202$");

            //When
            var contentIsValid = exchangeRateValidator.IsValid();

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRatePrecisionIsFourDecimals_ThenIsValid()
        {
            //Given
            IValidator exchangeRateValidator = new ExchangeRateValidator("86.0202");

            //When
            var contentIsValid = exchangeRateValidator.IsValid();

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRatePrecisionWithoutFourDecimals_ThenIsNotValid()
        {
            //Given
            IValidator exchangeRateValidator = new ExchangeRateValidator("86.022");

            //When
            var contentIsValid = exchangeRateValidator.IsValid();

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenExchangeRateWithoutPrecision_ThenIsNotValid()
        {
            //Given
            IValidator exchangeRateValidator = new ExchangeRateValidator("86");

            //When
            var contentIsValid = exchangeRateValidator.IsValid();

            //Then
            Assert.False(contentIsValid);
        }
    }
}