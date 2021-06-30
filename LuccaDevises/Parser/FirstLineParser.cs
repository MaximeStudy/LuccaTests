using System;

namespace LuccaDevises.Parser
{
    public class FirstLineParser
    {
        private readonly CurrencyParser currencyParser;
        private readonly PositiveIntegerParser positiveIntegerParser;

        public FirstLineParser(CurrencyParser currencyParser, PositiveIntegerParser positiveIntegerParser)
        {
            this.currencyParser = currencyParser;
            this.positiveIntegerParser = positiveIntegerParser;
        }

        public bool Parse(string line)
        {
            var splitLine = line.Split(';');
            if (splitLine.Length != 3)
            {
                throw new ArgumentException($"{line} does not have three part separated by semi-column ';' !");
            }

            var currencyOne = currencyParser.Parse(splitLine[0]);
            var initialAmount = positiveIntegerParser.Parse(splitLine[1]);
            var currencyTwo = currencyParser.Parse(splitLine[2]);

            return true;
        }
    }
}