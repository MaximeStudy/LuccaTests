using LuccaDevises.Domain.Input;
using LuccaDevises.Services.Factory;
using System;
using System.Collections.Generic;
using Xunit;

namespace LuccaDevises.Services.Tests.Factory
{
    public class UndirectedGraphFactoryTest
    {
        private readonly UndirectedGraphFactory undirectedGraphFactory;

        public UndirectedGraphFactoryTest()
        {
            undirectedGraphFactory = new UndirectedGraphFactory();
        }

        [Fact]
        public void GivenAExchangeRate_WhenCreateVertex_ThenVertexContainsName()
        {
            //Given
            var vertexName = "A";

            //When
            var vertex = undirectedGraphFactory.CreateVertex(vertexName);

            //Then
            Assert.Equal(vertexName, vertex.Name);
        }

        [Fact]
        public void GivenAnExchangeRate_WhenCreateEdgeFromExchangeRate_ThenVertexOneIsStartCurrency()
        {
            //Given
            var startCurrency = "A";
            var endCurrency = "B";

            ExchangeRate exchangeRate = new ExchangeRate
            {
                StartCurrency = startCurrency,
                EndCurrency = endCurrency,
                Rate = 1
            };

            //When
            var edge = undirectedGraphFactory.CreateEdge(exchangeRate);

            //Then
            Assert.Equal(startCurrency, edge.VertexOne.Name);
        }

        [Fact]
        public void GivenAnExchangeRate_WhenCreateEdgeFromExchangeRate_ThenVertexTwoIsEndCurrency()
        {
            //Given
            var startCurrency = "A";
            var endCurrency = "B";

            ExchangeRate exchangeRate = new ExchangeRate
            {
                StartCurrency = startCurrency,
                EndCurrency = endCurrency,
                Rate = 1
            };

            //When
            var edge = undirectedGraphFactory.CreateEdge(exchangeRate);

            //Then
            Assert.Equal(endCurrency, edge.VertexTwo.Name);
        }

        [Fact]
        public void GivenAnExchangeRate_WhenCreateEdgeFromExchangeRate_ThenVertexWeightIsByDefaultOne()
        {
            //Given
            var startCurrency = "A";
            var endCurrency = "B";

            ExchangeRate exchangeRate = new ExchangeRate
            {
                StartCurrency = startCurrency,
                EndCurrency = endCurrency,
                Rate = 5
            };
            int defaultWeight = 1;

            //When
            var edge = undirectedGraphFactory.CreateEdge(exchangeRate);

            //Then
            Assert.Equal(defaultWeight, edge.Weight);
        }

        [Fact]
        public void GivenAnExchangeRate_WhenCreateEdgeWithSameCurrency_ThenEdgeIsNotValid()
        {
            //Given
            var startCurrency = "A";

            ExchangeRate exchangeRate = new ExchangeRate
            {
                StartCurrency = startCurrency,
                EndCurrency = startCurrency,
                Rate = 5
            };

            //When

            //Then
            Assert.Throws<ArgumentException>(() => undirectedGraphFactory.CreateEdge(exchangeRate));
        }

        [Fact]
        public void GivenAnExchangeRateList_WhenCreateUndirectedGraph_ThenVertexAreTheSameNumberAsNumberOfCurrency()
        {
            //Given
            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

            AddExchangeRate(exchangeRates, "A", "B", 1);
            AddExchangeRate(exchangeRates, "A", "C", 1);
            AddExchangeRate(exchangeRates, "C", "D", 1);
            AddExchangeRate(exchangeRates, "D", "E", 1);
            AddExchangeRate(exchangeRates, "D", "F", 1);
            AddExchangeRate(exchangeRates, "A", "E", 1);
            AddExchangeRate(exchangeRates, "D", "A", 1);

            int nbDifferentCurrency = 6;

            //When
            var undirectedGraph = undirectedGraphFactory.CreateUndirectedGraph(exchangeRates);

            //Then
            Assert.Equal(nbDifferentCurrency, undirectedGraph.Vertices.Count);
        }

        [Fact]
        public void GivenAnExchangeRateList_WhenCreateUndirectedGraph_ThenEdgesAreTheSameNumberAsNumberOfExchangeRate()
        {
            //Given
            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

            AddExchangeRate(exchangeRates, "A", "B", 1);
            AddExchangeRate(exchangeRates, "A", "C", 1);
            AddExchangeRate(exchangeRates, "C", "D", 1);
            AddExchangeRate(exchangeRates, "D", "E", 1);
            AddExchangeRate(exchangeRates, "D", "F", 1);
            AddExchangeRate(exchangeRates, "A", "E", 1);
            AddExchangeRate(exchangeRates, "D", "A", 1);

            //When
            var undirectedGraph = undirectedGraphFactory.CreateUndirectedGraph(exchangeRates);

            //Then
            Assert.Equal(exchangeRates.Count, undirectedGraph.Edges.Count);
        }

        //TODO check uniformity of exchange rate list (doublon)
        //TODO check exchange list is a closed graph

        private void AddExchangeRate(List<ExchangeRate> exchangeRates, string startCurrency, string endCurrency, decimal rate)
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