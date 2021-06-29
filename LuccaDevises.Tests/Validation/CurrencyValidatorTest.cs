using LuccaDevises.Validation;
using Xunit;

namespace LuccaDevises.Tests.Validation
{
    public class CurrencyValidatorTest
    {
        [Fact]
        public void GivenACurrencyWith3Letter_ThenIsValid()
        {
            //Given
            IValidator firstLineValidator = new CurrencyValidator("EUR");

            //When
            var contentIsValid = firstLineValidator.IsValid();

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenACurrencyWithout3Letter_ThenIsNotValid()
        {
            //Given
            IValidator firstLineValidator = new CurrencyValidator("EU3aR");

            //When
            var contentIsValid = firstLineValidator.IsValid();

            //Then
            Assert.False(contentIsValid);
        }
    }
}