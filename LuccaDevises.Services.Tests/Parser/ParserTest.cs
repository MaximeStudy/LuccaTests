using LuccaDevises.Services.Parser;

namespace LuccaDevises.Services.Tests.Parser
{
    public class ParserTest
    {
        protected readonly CurrencyParser currencyParser;
        protected readonly PositiveIntegerParser positiveIntegerParser;
        protected readonly ExchangeRateParser exchangeRateParser;
        protected readonly FirstLineParser firstLineParser;
        protected readonly SecondLineParser secondLineParser;
        protected readonly NthLineParser nthLineParser;
        protected readonly ContentParser contentParser;

        public ParserTest()
        {
            currencyParser = new CurrencyParser();
            positiveIntegerParser = new PositiveIntegerParser();
            exchangeRateParser = new ExchangeRateParser();
            firstLineParser = new FirstLineParser(currencyParser, positiveIntegerParser);
            secondLineParser = new SecondLineParser(positiveIntegerParser);
            nthLineParser = new NthLineParser(currencyParser, exchangeRateParser);
            contentParser = new ContentParser(firstLineParser, secondLineParser, nthLineParser);
        }
    }
}