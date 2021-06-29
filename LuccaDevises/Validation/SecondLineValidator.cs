namespace LuccaDevises.Validation
{
    public class SecondLineValidator : IValidator
    {
        private readonly string line;

        public SecondLineValidator(string line)
        {
            this.line = line;
        }

        public bool IsValid()
        {
            var exchangeRateValidator = new PositiveIntegerValidator(line);
            return exchangeRateValidator.IsValid();
        }
    }
}