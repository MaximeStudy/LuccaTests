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

        public bool IsValid(string line)
        {
            var splitLine = line.Split(';');
            if (splitLine.Length != 3)
            {
                return false;
            }

            var currencyOne = currencyParser.Parse(splitLine[0]);
            var currencyTwo = currencyParser.Parse(splitLine[2]);

            return positiveIntegerParser.IsValid(splitLine[1]);
        }
    }
}