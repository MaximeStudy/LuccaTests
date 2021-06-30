namespace LuccaDevises.Parser
{
    public class PositiveIntegerParser
    {
        public bool IsValid(string amount)
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