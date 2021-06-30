using System;
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

        public bool Parse(List<string> fileContent)
        {
            if (fileContent.Count <= 2)
            {
                throw new ArgumentException($"File does not have more than 3 parts!");
            }

            var firstLine = firstLineParser.Parse(fileContent[0]);
            var numberOfExchangeRate = secondLineParser.Parse(fileContent[1]);

            if (fileContent.Count != numberOfExchangeRate + 2)
            {
                throw new ArgumentException($"Number of exchange rate does not match with real total of exchange number!");
            }

            for (int i = 2; i < fileContent.Count; i++)
            {
                var nthLine = nthLineParser.Parse(fileContent[i]);
            }

            return true;
        }
    }
}