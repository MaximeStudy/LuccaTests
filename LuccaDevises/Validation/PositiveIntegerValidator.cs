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
            if (int.TryParse(amount, out int result))
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