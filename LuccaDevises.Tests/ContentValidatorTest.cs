using System.Collections.Generic;
using Xunit;

namespace LuccaDevises.Tests
{
    public class ContentValidatorTest
    {
        [Fact]
        public void GivenAFileWithZeroLine_ThenContentIsNotValid()
        {
            //Given
            List<string> fileContent = new List<string>();
            ContentValidator contentValidator = new ContentValidator(fileContent);

            //When
            var contentIsValid = contentValidator.IsValid();

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAFileContentWithMoreThanTwoLines_ThenFileContentIsValid()
        {
            //Given
            List<string> fileContent = new List<string>();
            fileContent.Add("EUR;550;JPY");
            fileContent.Add("6");
            fileContent.Add("AUD;CHF;0.9661");

            ContentValidator contentValidator = new ContentValidator(fileContent);

            //When
            var contentIsValid = contentValidator.IsValid();

            //Then
            Assert.True(contentIsValid);
        }
    }
}