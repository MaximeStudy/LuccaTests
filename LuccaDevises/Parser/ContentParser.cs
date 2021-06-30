using System.Collections.Generic;

namespace LuccaDevises.Parser
{
    public class ContentParser
    {
        private readonly FirstLineParser firstLineParser;
        private readonly SecondLineParser secondLineParser;
        private readonly NthLineParser nthLineParser;

        public ContentParser(FirstLineParser firstLineParser, SecondLineParser secondLineParser, NthLineParser nthLineParser)
        {
            this.firstLineParser = firstLineParser;
            this.secondLineParser = secondLineParser;
            this.nthLineParser = nthLineParser;
        }

        public bool IsValid(List<string> fileContent)
        {
            if (fileContent.Count <= 2)
            {
                return false;
            }

            var numberOfExchangeRate = secondLineParser.Parse(fileContent[1]);
            if (firstLineParser.IsValid(fileContent[0]))
            {
                if (fileContent.Count != numberOfExchangeRate + 2)
                {
                    return false;
                }
                for (int i = 2; i < fileContent.Count; i++)
                {
                    if (!nthLineParser.IsValid(fileContent[i]))
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