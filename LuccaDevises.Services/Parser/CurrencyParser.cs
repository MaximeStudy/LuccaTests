using System;

namespace LuccaDevises.Services.Parser
{
    public class CurrencyParser
    {
        public string Parse(string currency)
        {
            if (currency.Length == 3)
            {
                return currency;
            }
            throw new ArgumentException($"Currency {currency} is not 3 chars!"); ;
        }
    }
}