using LuccaDevises.Validation;
using Xunit;

namespace LuccaDevises.Tests.Validation
{
    public class SecondLineValidatorTest
    {
        [Fact]
        public void GivenASecondLineWithPositiveInteger_ThenLineIsValid()
        {
            //Given
            IValidator secondLineValidator = new SecondLineValidator("54");

            //When
            var contentIsValid = secondLineValidator.IsValid();

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenASecondLineWithoutInteger_ThenLineIsNotValid()
        {
            //Given
            IValidator secondLineValidator = new SecondLineValidator("54;PCD");

            //When
            var contentIsValid = secondLineValidator.IsValid();

            //Then
            Assert.False(contentIsValid);
        }
    }
}