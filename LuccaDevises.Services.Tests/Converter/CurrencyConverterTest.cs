using LuccaDevises.Domain.Graph;
using LuccaDevises.Domain.Input;
using LuccaDevises.Services.Converter;
using LuccaDevises.Services.Factory;
using System;
using System.Collections.Generic;
using Xunit;

namespace LuccaDevises.Services.Tests.Converter
{
    public class CurrencyConverterTest : TestBase
    {
        private readonly UndirectedGraphFactory undirectedGraphFactory;

        public CurrencyConverterTest()
        {
            undirectedGraphFactory = new UndirectedGraphFactory();
        }

        [Fact]
        public void GivenExchangeRateAndOrder_WhenConvertCurrency_ThenMultiplyInitialAmountWithRate()
        {
            //Given
            CurrencyConverter currencyConverter = new CurrencyConverter();

            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

            AddExchangeRate(exchangeRates, "AUD", "CHF", 0.9661M);
            AddExchangeRate(exchangeRates, "JPY", "KWU", 13.1151M);
            AddExchangeRate(exchangeRates, "EUR", "CHF", 1.2053M);
            AddExchangeRate(exchangeRates, "AUD", "JPY", 86.0305M);
            AddExchangeRate(exchangeRates, "EUR", "USD", 1.2989M);
            AddExchangeRate(exchangeRates, "JPY", "INR", 0.6571M);

            int initialAmount = 550;

            var order = new Stack<Vertex>();
            order.Push(undirectedGraphFactory.CreateVertex("CHF"));
            order.Push(undirectedGraphFactory.CreateVertex("AUD"));

            var expectedResult = Math.Round(initialAmount * exchangeRates[0].Rate, 0);

            //When
            var result = currencyConverter.ConvertCurrency(initialAmount, exchangeRates, order);

            //Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenExchangeRateAndOrder_WhenExchangeRateAreInversed_ThenMultiplyInitialAmountWithInversedRate()
        {
            //Given
            CurrencyConverter currencyConverter = new CurrencyConverter();

            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

            AddExchangeRate(exchangeRates, "AUD", "CHF", 0.9661M);
            AddExchangeRate(exchangeRates, "JPY", "KWU", 13.1151M);
            AddExchangeRate(exchangeRates, "EUR", "CHF", 1.2053M);
            AddExchangeRate(exchangeRates, "AUD", "JPY", 86.0305M);
            AddExchangeRate(exchangeRates, "EUR", "USD", 1.2989M);
            AddExchangeRate(exchangeRates, "JPY", "INR", 0.6571M);

            int initialAmount = 550;

            var order = new Stack<Vertex>();
            order.Push(undirectedGraphFactory.CreateVertex("AUD"));
            order.Push(undirectedGraphFactory.CreateVertex("CHF"));

            var expectedResult = Math.Round(initialAmount * Math.Round((1 / exchangeRates[0].Rate), 4), 0);

            //When
            var result = currencyConverter.ConvertCurrency(initialAmount, exchangeRates, order);

            //Then
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GivenExerciseInput_WhenConvertCurrency_ThenCheckResult()
        {
            //Given
            CurrencyConverter currencyConverter = new CurrencyConverter();

            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

            AddExchangeRate(exchangeRates, "AUD", "CHF", 0.9661M);
            AddExchangeRate(exchangeRates, "JPY", "KWU", 13.1151M);
            AddExchangeRate(exchangeRates, "EUR", "CHF", 1.2053M);
            AddExchangeRate(exchangeRates, "AUD", "JPY", 86.0305M);
            AddExchangeRate(exchangeRates, "EUR", "USD", 1.2989M);
            AddExchangeRate(exchangeRates, "JPY", "INR", 0.6571M);

            int initialAmount = 550;

            var order = new Stack<Vertex>();
            order.Push(undirectedGraphFactory.CreateVertex("JPY"));
            order.Push(undirectedGraphFactory.CreateVertex("AUD"));
            order.Push(undirectedGraphFactory.CreateVertex("CHF"));
            order.Push(undirectedGraphFactory.CreateVertex("EUR"));

            var expectedResult = 59033;

            //When
            var result = currencyConverter.ConvertCurrency(initialAmount, exchangeRates, order);

            //Then
            Assert.Equal(expectedResult, result);
        }
    }
}