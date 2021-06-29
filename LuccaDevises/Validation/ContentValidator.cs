using System;
using System.Collections.Generic;

namespace LuccaDevises.Validation
{
    public class ContentValidator
    {
        public FirstLineValidator FirstLineValidator { get; private set; }

        public SecondLineValidator SecondLineValidator { get; private set; }

        public List<NthLineValidator> NthLineValidators { get; private set; }

        public ContentValidator()
        {
        }

        public static ContentValidator Parse(List<string> fileContent)
        {
            if (IsValid(fileContent))
            {
                var content = new ContentValidator();
                content.FirstLineValidator = new FirstLineValidator(fileContent[0]);
                content.SecondLineValidator = new SecondLineValidator(fileContent[1]);
                content.NthLineValidators = new List<NthLineValidator>();
                for (int i = 2; i < fileContent.Count; i++)
                {
                    content.NthLineValidators.Add(new NthLineValidator(fileContent[i]));
                }
                return content;
            }
            throw new Exception("File content not valid!");
        }

        public static bool IsValid(List<string> fileContent)
        {
            if (fileContent.Count <= 2)
            {
                return false;
            }
            var firstLineValidator = new FirstLineValidator(fileContent[0]);
            var secondLineValidator = new SecondLineValidator(fileContent[1]);
            if (firstLineValidator.IsValid() && secondLineValidator.IsValid())
            {
                var numberOfExchangeRate = int.Parse(fileContent[1]);
                if (fileContent.Count != numberOfExchangeRate + 2)
                {
                    return false;
                }
                for (int i = 2; i < fileContent.Count; i++)
                {
                    var nthLineValidator = new NthLineValidator(fileContent[i]);
                    if (!nthLineValidator.IsValid())
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}