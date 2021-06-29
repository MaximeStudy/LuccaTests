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

        [Fact]
        public void GivenAFirstLineWithThreeElement_ThenTheLineShouldHaveThreeArgumentSeparatedBySemicolon()
        {
            //Given
            IValidator firstLineValidator = new FirstLineValidator("EUR;550;JPY");

            //When
            var contentIsValid = firstLineValidator.IsValid();

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenAFirstLineWithoutThreeElement_ThenLineIsNotValid()
        {
            //Given
            IValidator firstLineValidator = new FirstLineValidator("EUR;550;JPY;4");

            //When
            var contentIsValid = firstLineValidator.IsValid();

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAFirstLineWithThreeElementUnordered_ThenLineIsNotValid()
        {
            //Given
            IValidator firstLineValidator = new FirstLineValidator("550;EUR;JPY");

            //When
            var contentIsValid = firstLineValidator.IsValid();

            //Then
            Assert.False(contentIsValid);
        }
    }
}