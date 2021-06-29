using System.Numerics;

namespace LuccaDevises.Validation
{
    public class PositiveIntegerValidator : IValidator
    {
        private readonly string amount;

        public PositiveIntegerValidator(string amount)
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