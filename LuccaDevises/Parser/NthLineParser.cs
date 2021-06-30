namespace LuccaDevises.Parser
{
    public class NthLineParser
    {
        public bool IsValid(string line)
        {
            var splitLine = line.Split(';');
            if (splitLine.Length != 3)
            {
                return false;
            }

            var currencyOne = new CurrencyParser();
            var currencyTwo = new CurrencyParser();
            var exchangeRate = new ExchangeRateParser();

            return currencyOne.IsValid(splitLine[0]) && currencyTwo.IsValid(splitLine[1]) && exchangeRate.IsValid(splitLine[2]);
        }
    }
}