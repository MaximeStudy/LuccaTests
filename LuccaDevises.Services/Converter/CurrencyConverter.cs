using LuccaDevises.Domain.Graph;
using LuccaDevises.Domain.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LuccaDevises.Services.Converter
{
    public class CurrencyConverter
    {
        public int ConvertCurrency(InputState inputState, Stack<Vertex> orderStack)
        {
            decimal currentAmount = inputState.TransformationGoal.InitialAmount;
            var currentCurrency = orderStack.Pop();
            while (orderStack.Count > 0)
            {
                var nextCurrency = orderStack.Pop();
                Console.Write($"{currentCurrency} {nextCurrency}");

                var exchangeRate = inputState.ExchangeRates.FirstOrDefault(er => (er.StartCurrency == currentCurrency.Name && er.EndCurrency == nextCurrency.Name) || (er.StartCurrency == nextCurrency.Name && er.EndCurrency == currentCurrency.Name));

                decimal rate;
                if (exchangeRate.StartCurrency == currentCurrency.Name)
                {
                    rate = exchangeRate.Rate;
                }
                else
                {
                    rate = exchangeRate.InversedRate;
                }
                currentAmount = Math.Round(currentAmount * rate, 4);

                currentCurrency = nextCurrency;
            }
            var intResult = (int)Math.Round(currentAmount, 0);
            return intResult;
        }
    }
}