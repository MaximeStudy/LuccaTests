using LuccaDevises.Domain.Input;
using System;
using System.Collections.Generic;

namespace LuccaDevises.Services.Parser
{
    public class ContentParser : IContentParser
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

        public InputState Parse(List<string> fileContent)
        {
            if (fileContent.Count <= 2)
            {
                throw new ArgumentException($"File does not have more than 3 parts!");
            }

            var transformationGoal = firstLineParser.Parse(fileContent[0]);
            var numberOfExchangeRate = secondLineParser.Parse(fileContent[1]);

            var inputState = new InputState
            {
                TransformationGoal = transformationGoal,
                ExchangeRates = new List<ExchangeRate>()
            };

            if (fileContent.Count != numberOfExchangeRate + 2)
            {
                throw new ArgumentException($"Number of exchange rate {numberOfExchangeRate} does not match with real total of exchange number {fileContent.Count - 2}!");
            }

            for (int i = 2; i < fileContent.Count; i++)
            {
                var exchangeRate = nthLineParser.Parse(fileContent[i]);
                inputState.ExchangeRates.Add(exchangeRate);
            }

            return inputState;
        }
    }
}