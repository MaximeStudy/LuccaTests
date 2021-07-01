using LuccaDevises.Domain.Graph;
using LuccaDevises.Domain.Input;
using LuccaDevises.Services.Factory;
using LuccaDevises.Services.RouteFinder;
using System;
using System.Collections.Generic;
using Xunit;

namespace LuccaDevises.Services.Tests.RouteFinder
{
    public class DijstraAlgorithmTest : TestBase
    {
        private readonly UndirectedGraphFactory undirectedGraphFactory;

        public DijstraAlgorithmTest()
        {
            undirectedGraphFactory = new UndirectedGraphFactory();
        }

        [Fact]
        public void GivenTheExempleInput_ThenShortestPathLengthIsThree()
        {
            //Given
            var dijstraAlgorithm = new DijstraAlgorithm();
            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

            AddExchangeRate(exchangeRates, "AUD", "CHF", 1);
            AddExchangeRate(exchangeRates, "JPY", "KWU", 1);
            AddExchangeRate(exchangeRates, "EUR", "CHF", 1);
            AddExchangeRate(exchangeRates, "AUD", "JPY", 1);
            AddExchangeRate(exchangeRates, "EUR", "USD", 1);
            AddExchangeRate(exchangeRates, "JPY", "INR", 1);

            var undirectedGraph = undirectedGraphFactory.CreateUndirectedGraph(exchangeRates);
            var startVertex = undirectedGraphFactory.CreateVertex("EUR");
            var endVertex = undirectedGraphFactory.CreateVertex("JPY");

            var expectedDistance = 3;

            //When
            var shortestPath = dijstraAlgorithm.CalculateShortestPath(undirectedGraph, startVertex, endVertex);

            //Then
            Assert.Equal(expectedDistance, shortestPath.Distance);
        }

        [Fact]
        public void GivenTheExempleInput_ThenVerifyShortestPathOrder()
        {
            //Given
            var dijstraAlgorithm = new DijstraAlgorithm();
            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

            AddExchangeRate(exchangeRates, "AUD", "CHF", 1);
            AddExchangeRate(exchangeRates, "JPY", "KWU", 1);
            AddExchangeRate(exchangeRates, "EUR", "CHF", 1);
            AddExchangeRate(exchangeRates, "AUD", "JPY", 1);
            AddExchangeRate(exchangeRates, "EUR", "USD", 1);
            AddExchangeRate(exchangeRates, "JPY", "INR", 1);

            var undirectedGraph = undirectedGraphFactory.CreateUndirectedGraph(exchangeRates);
            var startVertex = undirectedGraphFactory.CreateVertex("EUR");
            var endVertex = undirectedGraphFactory.CreateVertex("JPY");

            var expectedResult = new Stack<Vertex>();
            expectedResult.Push(endVertex);
            expectedResult.Push(undirectedGraphFactory.CreateVertex("AUD"));
            expectedResult.Push(undirectedGraphFactory.CreateVertex("CHF"));
            expectedResult.Push(startVertex);

            //When
            var shortestPath = dijstraAlgorithm.CalculateShortestPath(undirectedGraph, startVertex, endVertex);

            //Then
            Assert.Equal(expectedResult, shortestPath.VerticesOrder);
        }

        [Fact]
        public void GivenAGraph_WhenStartAndEndVertexAreTheSame_ThenThrowError()
        {
            //Given
            var dijstraAlgorithm = new DijstraAlgorithm();
            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

            AddExchangeRate(exchangeRates, "AUD", "CHF", 1);
            AddExchangeRate(exchangeRates, "JPY", "KWU", 1);
            AddExchangeRate(exchangeRates, "EUR", "CHF", 1);
            AddExchangeRate(exchangeRates, "AUD", "JPY", 1);
            AddExchangeRate(exchangeRates, "EUR", "USD", 1);
            AddExchangeRate(exchangeRates, "JPY", "INR", 1);

            var undirectedGraph = undirectedGraphFactory.CreateUndirectedGraph(exchangeRates);
            var startVertex = undirectedGraphFactory.CreateVertex("EUR");
            var endVertex = startVertex;

            var expectedResult = new Stack<Vertex>();
            expectedResult.Push(endVertex);
            expectedResult.Push(startVertex);

            //When

            //Then
            Assert.Throws<ArgumentException>(() => dijstraAlgorithm.CalculateShortestPath(undirectedGraph, startVertex, endVertex));
        }

        [Fact]
        public void GivenAGraph_WhenStartAreNotInTheGraph_ThenThrowError()
        {
            //Given
            var dijstraAlgorithm = new DijstraAlgorithm();
            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

            AddExchangeRate(exchangeRates, "AUD", "CHF", 1);
            AddExchangeRate(exchangeRates, "JPY", "KWU", 1);
            AddExchangeRate(exchangeRates, "EUR", "CHF", 1);
            AddExchangeRate(exchangeRates, "AUD", "JPY", 1);
            AddExchangeRate(exchangeRates, "EUR", "USD", 1);
            AddExchangeRate(exchangeRates, "JPY", "INR", 1);

            var undirectedGraph = undirectedGraphFactory.CreateUndirectedGraph(exchangeRates);
            var startVertex = undirectedGraphFactory.CreateVertex("ZZZ");
            var endVertex = undirectedGraphFactory.CreateVertex("AUD");

            var expectedResult = new Stack<Vertex>();
            expectedResult.Push(endVertex);
            expectedResult.Push(startVertex);

            //When

            //Then
            Assert.Throws<ArgumentException>(() => dijstraAlgorithm.CalculateShortestPath(undirectedGraph, startVertex, endVertex));
        }

        [Fact]
        public void GivenAGraph_WhenEndAreNotInTheGraph_ThenThrowError()
        {
            //Given
            var dijstraAlgorithm = new DijstraAlgorithm();
            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

            AddExchangeRate(exchangeRates, "AUD", "CHF", 1);
            AddExchangeRate(exchangeRates, "JPY", "KWU", 1);
            AddExchangeRate(exchangeRates, "EUR", "CHF", 1);
            AddExchangeRate(exchangeRates, "AUD", "JPY", 1);
            AddExchangeRate(exchangeRates, "EUR", "USD", 1);
            AddExchangeRate(exchangeRates, "JPY", "INR", 1);

            var undirectedGraph = undirectedGraphFactory.CreateUndirectedGraph(exchangeRates);
            var startVertex = undirectedGraphFactory.CreateVertex("AUD");
            var endVertex = undirectedGraphFactory.CreateVertex("ZZZ");

            var expectedResult = new Stack<Vertex>();
            expectedResult.Push(endVertex);
            expectedResult.Push(startVertex);

            //When

            //Then
            Assert.Throws<ArgumentException>(() => dijstraAlgorithm.CalculateShortestPath(undirectedGraph, startVertex, endVertex));
        }

        [Fact]
        public void GivenAGraphWithWeight_ThenVerifyShortestPathOrder()
        {
            //Given
            var dijstraAlgorithm = new DijstraAlgorithm();
            List<ExchangeRate> exchangeRates = new List<ExchangeRate>();

            AddExchangeRate(exchangeRates, "AUD", "CHF", 1);
            AddExchangeRate(exchangeRates, "JPY", "KWU", 1);
            AddExchangeRate(exchangeRates, "EUR", "CHF", 1);
            AddExchangeRate(exchangeRates, "AUD", "JPY", 1);
            AddExchangeRate(exchangeRates, "EUR", "USD", 1);
            AddExchangeRate(exchangeRates, "JPY", "INR", 1);

            var undirectedGraph = undirectedGraphFactory.CreateUndirectedGraph(exchangeRates);
            var startVertex = undirectedGraphFactory.CreateVertex("AUD");
            var endVertex = undirectedGraphFactory.CreateVertex("ZZZ");

            var expectedResult = new Stack<Vertex>();
            expectedResult.Push(endVertex);
            expectedResult.Push(startVertex);

            //When

            //Then
            Assert.Throws<ArgumentException>(() => dijstraAlgorithm.CalculateShortestPath(undirectedGraph, startVertex, endVertex));
        }
    }
}