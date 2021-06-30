namespace LuccaDevises.Parser
{
    public class SecondLineParser
    {
        private readonly PositiveIntegerParser positiveIntegerParser;

        public SecondLineParser(PositiveIntegerParser positiveIntegerParser)
        {
            this.positiveIntegerParser = positiveIntegerParser;
        }

        public int Parse(string line)
        {
            return positiveIntegerParser.Parse(line);
        }
    }
}