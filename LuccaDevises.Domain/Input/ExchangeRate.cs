using System;

namespace LuccaDevises.Domain.Input
{
    public class ExchangeRate
    {
        public string StartCurrency { get; init; }

        public string EndCurrency { get; init; }

        public decimal Rate { get; init; }

        public decimal InversedRate { get { return Math.Round(1 / Rate, 4); } }

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