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

        public bool IsValid(string line)
        {
            var splitLine = line.Split(';');
            if (splitLine.Length != 3)
            {
                return false;
            }

            var currencyOne = currencyParser.Parse(splitLine[0]);
            var currencyTwo = currencyParser.Parse(splitLine[1]);
            return exchangeRateParser.IsValid(splitLine[2]);
        }
    }
}