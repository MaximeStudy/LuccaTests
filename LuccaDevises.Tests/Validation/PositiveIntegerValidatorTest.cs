using LuccaDevises.Validation;
using Xunit;

namespace LuccaDevises.Tests.Validation
{
    public class PositiveIntegerValidatorTest
    {
        [Fact]
        public void GivenAnAmountGreaterThanZero_ThenAmountIsValid()
        {
            //Given
            IValidator amountValidator = new PositiveIntegerValidator("154");

            //When
            var contentIsValid = amountValidator.IsValid();

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenAnAmountLowerThanZero_ThenAmountIsNotValid()
        {
            //Given
            IValidator amountValidator = new PositiveIntegerValidator("-5");

            //When
            var contentIsValid = amountValidator.IsValid();

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAnAmounEqualToZero_ThenAmountIsNotValid()
        {
            //Given
            IValidator amountValidator = new PositiveIntegerValidator("0");

            //When
            var contentIsValid = amountValidator.IsValid();

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAnAmountThatIsNotAnInteger_ThenAmountIsNotValid()
        {
            //Given
            IValidator amountValidator = new PositiveIntegerValidator("5.5");

            //When
            var contentIsValid = amountValidator.IsValid();

            //Then
            Assert.False(contentIsValid);
        }
    }
}