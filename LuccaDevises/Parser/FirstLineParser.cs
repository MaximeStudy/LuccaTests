namespace LuccaDevises.Parser
{
    public class FirstLineParser
    {
        public bool IsValid(string line)
        {
            var splitLine = line.Split(';');
            if (splitLine.Length != 3)
            {
                return false;
            }

            var currencyOne = new CurrencyParser();
            var amount = new PositiveIntegerParser();
            var currencyTwo = new CurrencyParser();

            return currencyOne.IsValid(splitLine[0]) && amount.IsValid(splitLine[1]) && currencyTwo.IsValid(splitLine[2]);
        }
    }
}