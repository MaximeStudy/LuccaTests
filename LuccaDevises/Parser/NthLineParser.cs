using System;

namespace LuccaDevises.Parser
{
    public class NthLineParser
    {
        private readonly CurrencyParser currencyParser;
        private readonly ExchangeRateParser exchangeRateParser;

        public NthLineParser(CurrencyParser currencyParser, ExchangeRateParser exchangeRateParser)
        {
            this.currencyParser = currencyParser;
            this.exchangeRateParser = exchangeRateParser;
        }

        public bool Parse(string line)
        {
            var splitLine = line.Split(';');
            if (splitLine.Length != 3)
            {
                throw new ArgumentException($"{line} does not have three part separated by semi-column ';' !");
            }

            var currencyOne = currencyParser.Parse(splitLine[0]);
            var currencyTwo = currencyParser.Parse(splitLine[1]);
            var exchangeRate = exchangeRateParser.Parse(splitLine[2]);
            return true;
        }
    }
}