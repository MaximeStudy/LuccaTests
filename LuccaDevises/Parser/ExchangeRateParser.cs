using System.Globalization;

namespace LuccaDevises.Parser
{
    public class ExchangeRateParser
    {
        public bool IsValid(string exchangeRate)
        {
            NumberStyles style = NumberStyles.Number;

            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");

            var exchangeRateSplit = exchangeRate.Split('.');
            if (exchangeRateSplit.Length != 2 || exchangeRateSplit[1].Length != 4)
            {
                return false;
            }
            if (decimal.TryParse(exchangeRate, style, culture, out decimal result))
            {
                return true;
            }
            return false;
        }
    }
}