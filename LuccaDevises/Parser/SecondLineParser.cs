namespace LuccaDevises.Parser
{
    public class SecondLineParser
    {
        public bool IsValid(string line)
        {
            var exchangeRateValidator = new PositiveIntegerParser();
            return exchangeRateValidator.IsValid(line);
        }
    }
}