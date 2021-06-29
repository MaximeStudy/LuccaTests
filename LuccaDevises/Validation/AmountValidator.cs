using System.Numerics;

namespace LuccaDevises.Validation
{
    public class AmountValidator : IValidator
    {
        private readonly string amount;

        public AmountValidator(string amount)
        {
            this.amount = amount;
        }

        public bool IsValid()
        {
            if (BigInteger.TryParse(amount, out BigInteger result))
            {
                if (result > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}