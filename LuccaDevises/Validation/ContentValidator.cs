using LuccaDevises.Validation;
using System.Collections.Generic;

namespace LuccaDevises.Validation
{
    public class ContentValidator : IValidator
    {
        private readonly List<string> fileContent;

        public ContentValidator(List<string> fileContent)
        {
            this.fileContent = fileContent;
        }

        public bool IsValid()
        {
            if (fileContent.Count <= 2)
            {
                return false;
            }
            var firstLineValidator = new FirstLineValidator(fileContent[0]);
            var secondLineValidator = new SecondLineValidator(fileContent[1]);

            return firstLineValidator.IsValid() && secondLineValidator.IsValid();
        }
    }
}