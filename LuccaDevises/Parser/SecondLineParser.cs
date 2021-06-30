namespace LuccaDevises.Parser
{
    public class SecondLineParser
    {
        private readonly PositiveIntegerParser positiveIntegerParser;

        public SecondLineParser(PositiveIntegerParser positiveIntegerParser)
        {
            this.positiveIntegerParser = positiveIntegerParser;
        }

        public bool IsValid(string line)
        {
            var numberOfElement = positiveIntegerParser.Parse(line);
            return true;
        }
    }
}