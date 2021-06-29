namespace LuccaDevises.Validation
{
    public class NthLineValidator : IValidator
    {
        private readonly string line;

        public NthLineValidator(string line)
        {
            this.line = line;
        }

        public bool IsValid()
        {
            var splitLine = line.Split(';');
            if (splitLine.Length != 3)
            {
                return false;
            }

            var currencyOne = new CurrencyValidator(splitLine[0]);
            var currencyTwo = new CurrencyValidator(splitLine[1]);
            var exchangeRate = new ExchangeRateValidator(splitLine[2]);

            return currencyOne.IsValid() && currencyTwo.IsValid() && exchangeRate.IsValid();
        }
    }
}