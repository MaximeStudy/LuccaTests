using System;

namespace LuccaDevises.Domain
{
    public class ExchangeRate
    {
        public string StartCurrency { get; init; }

        public string EndCurrency { get; init; }

        public decimal Rate { get; init; }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                ExchangeRate exchangeRate = (ExchangeRate)obj;
                return (StartCurrency == exchangeRate.StartCurrency) && (EndCurrency == exchangeRate.EndCurrency) && (Rate == exchangeRate.Rate);
            }
        }

        public override int GetHashCode()
        {
            return Tuple.Create(StartCurrency, EndCurrency).GetHashCode();
        }
    }
}