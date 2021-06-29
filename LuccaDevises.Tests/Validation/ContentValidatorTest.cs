using LuccaDevises.Validation;
using System.Collections.Generic;
using Xunit;

namespace LuccaDevises.Tests.Validation
{
    public class ContentValidatorTest
    {
        [Fact]
        public void GivenAFileWithZeroLine_ThenContentIsNotValid()
        {
            //Given
            List<string> fileContent = new List<string>();

            //When
            var contentIsValid = ContentValidator.IsValid(fileContent);

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAFileContentWithMoreThanTwoLines_ThenFileContentIsValid()
        {
            //Given
            List<string> fileContent = new List<string>();
            fileContent.Add("EUR;550;JPY");
            fileContent.Add("1");
            fileContent.Add("AUD;CHF;0.9661");

            //When
            var contentIsValid = ContentValidator.IsValid(fileContent);

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenAFileContent_ThenTheNumberOfExchangeRateAreTheSameAsTheSecondLine()
        {
            //Given
            List<string> fileContent = new List<string>();
            fileContent.Add("EUR;550;JPY");
            fileContent.Add("2");
            fileContent.Add("AUD;CHF;0.9661");
            fileContent.Add("JPY;CHF;0.9661");

            //When
            var contentIsValid = ContentValidator.IsValid(fileContent);

            //Then
            Assert.True(contentIsValid);
        }

        [Fact]
        public void GivenAFileContentWithoutFittingExchangeRateWithNumber_ThenContentIsNotValid()
        {
            //Given
            List<string> fileContent = new List<string>();
            fileContent.Add("EUR;550;JPY");
            fileContent.Add("4");
            fileContent.Add("AUD;CHF;0.9661");
            fileContent.Add("AUD;CFG;0.9661");

            //When
            var contentIsValid = ContentValidator.IsValid(fileContent);

            //Then
            Assert.False(contentIsValid);
        }

        [Fact]
        public void GivenAFileContentWithErrorInANthElement_ThenContentIsNotValid()
        {
            //Given
            List<string> fileContent = new List<string>();
            fileContent.Add("EUR;550;JPY");
            fileContent.Add("4");
            fileContent.Add("AUD;CHF;0.9661");
            fileContent.Add("AUD;CFG;0.9661");
            fileContent.Add("AUD;CHF;0.9661");
            fileContent.Add("AUD;CHF;0.9");

            //When
            var contentIsValid = ContentValidator.IsValid(fileContent);

            //Then
            Assert.False(contentIsValid);
        }
    }
}