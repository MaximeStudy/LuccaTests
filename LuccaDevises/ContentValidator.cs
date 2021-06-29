using System.Collections.Generic;

namespace LuccaDevises
{
    public class ContentValidator
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
            var initialDevise = fileContent[0];
            return true;
        }
    }
}