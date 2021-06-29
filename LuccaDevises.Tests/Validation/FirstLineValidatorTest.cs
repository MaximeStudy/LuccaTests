using LuccaDevises.Validation;
using Xunit;

namespace LuccaDevises.Tests.Validation
{
    public class FirstLineValidatorTest
    {
        [Fact]
        public void GivenAnEmptyFirstLine_ThenLineIsNotValid()
        {
            //Given
            IValidator firstLineValidator = new FirstLineValidator("");

            //When
            var contentIsValid = firstLineValidator.IsValid();

            //Then
            Assert.False(contentIsValid);
        }
    }
}