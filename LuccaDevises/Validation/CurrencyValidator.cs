namespace LuccaDevises.Validation
{
    public class CurrencyValidator : IValidator
    {
        private readonly string currency;

        public CurrencyValidator(string currency)
        {
            this.currency = currency;
        }

        public bool IsValid()
        {
            if (currency.Length == 3)
            {
                return true;
            }
            return false;
        }
    }
}