namespace LuccaDevises.Validation
{
    public class FirstLineValidator : IValidator
    {
        private readonly string line;

        public FirstLineValidator(string line)
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
            var amount = new PositiveIntegerValidator(splitLine[1]);
            var currencyTwo = new CurrencyValidator(splitLine[2]);

            return currencyOne.IsValid() && amount.IsValid() && currencyTwo.IsValid();
        }
    }
}