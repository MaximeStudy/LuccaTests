namespace LuccaDevises.Parser
{
    public class CurrencyParser
    {
        public bool IsValid(string currency)
        {
            if (currency.Length == 3)
            {
                return true;
            }
            return false;
        }
    }
}