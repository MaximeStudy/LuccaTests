using LuccaDevises.Domain.Input;
using System.Collections.Generic;

namespace LuccaDevises.Services.Tests
{
    public class TestBase
    {
        protected void AddExchangeRate(List<ExchangeRate> exchangeRates, string startCurrency, string endCurrency, decimal rate)
        {
            ExchangeRate exchangeRate = new ExchangeRate
            {
                StartCurrency = startCurrency,
                EndCurrency = endCurrency,
                Rate = rate
            };
            exchangeRates.Add(exchangeRate);
        }
    }
}