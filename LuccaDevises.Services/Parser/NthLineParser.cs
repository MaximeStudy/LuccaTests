using LuccaDevises.Domain;
using System;

namespace LuccaDevises.Services.Parser
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

        public ExchangeRate Parse(string line)
        {
            var splitLine = line.Split(';');
            if (splitLine.Length != 3)
            {
                throw new ArgumentException($"{line} does not have three part separated by semi-column ';' !");
            }

            var currencyOne = currencyParser.Parse(splitLine[0]);
            var currencyTwo = currencyParser.Parse(splitLine[1]);
            var rate = exchangeRateParser.Parse(splitLine[2]);

            var exchangeRate = new ExchangeRate
            {
                StartCurrency = currencyOne,
                EndCurrency = currencyTwo,
                Rate = rate
            };

            return exchangeRate;
        }
    }
}