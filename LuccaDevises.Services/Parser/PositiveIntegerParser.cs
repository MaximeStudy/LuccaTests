using System;

namespace LuccaDevises.Services.Parser
{
    public class PositiveIntegerParser
    {
        public int Parse(string amount)
        {
            if (int.TryParse(amount, out int result))
            {
                if (result > 0)
                {
                    return result;
                }
            }

            throw new ArgumentException($"{amount} is not a positive integer!");
        }
    }
}