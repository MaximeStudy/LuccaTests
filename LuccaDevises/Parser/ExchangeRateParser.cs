using System;
using System.Globalization;

namespace LuccaDevises.Parser
{
    public class ExchangeRateParser
    {
        public decimal Parse(string exchangeRate)
        {
            NumberStyles style = NumberStyles.Number;

            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");

            var exchangeRateSplit = exchangeRate.Split('.');
            if (exchangeRateSplit.Length != 2)
            {
                throw new ArgumentException($"{exchangeRate} does not contains delimitor '.' !");
            }
            if (exchangeRateSplit[1].Length != 4)
            {
                throw new ArgumentException($"{exchangeRate} does not contains 4 decimals !");
            }
            if (decimal.TryParse(exchangeRate, style, culture, out decimal result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException($"{exchangeRate} cannot be parsed in decimal !");
            }
        }
    }
}