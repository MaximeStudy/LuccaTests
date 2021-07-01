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

        [Fact]
        public void GivenAUndirectedGraphWithWeight_WhenCalculateShortestPath_ThenVerifyDistance()
        {
            //Given
            var dijstraAlgorithm = new DijstraAlgorithm();
            List<Vertex> vertices = new List<Vertex>();
            List<Edge> edges = new List<Edge>();

            var undirectedGraph = CreateComplexUndirectedGraphWithWeight(vertices, edges);

            var expectedDistance = 6;

            var startingVertex = undirectedGraphFactory.CreateVertex("A");
            var endingVertex = undirectedGraphFactory.CreateVertex("G");

            //When
            var result = dijstraAlgorithm.CalculateShortestPath(undirectedGraph, startingVertex, endingVertex);

            //Then
            Assert.Equal(expectedDistance, result.Distance);
        }

        [Fact]
        public void GivenAUndirectedGraphWithWeight_WhenCalculateShortestPath_ThenVerifyVerticesOrder()
        {
            //Given
            var dijstraAlgorithm = new DijstraAlgorithm();
            List<Vertex> vertices = new List<Vertex>();
            List<Edge> edges = new List<Edge>();

            var undirectedGraph = CreateComplexUndirectedGraphWithWeight(vertices, edges);

            var startingVertex = undirectedGraphFactory.CreateVertex("A");
            var endingVertex = undirectedGraphFactory.CreateVertex("G");

            var expectedResult = new Stack<Vertex>();
            expectedResult.Push(undirectedGraphFactory.CreateVertex("G"));
            expectedResult.Push(undirectedGraphFactory.CreateVertex("D"));
            expectedResult.Push(undirectedGraphFactory.CreateVertex("B"));
            expectedResult.Push(undirectedGraphFactory.CreateVertex("A"));

            //When
            var result = dijstraAlgorithm.CalculateShortestPath(undirectedGraph, startingVertex, endingVertex);

            //Then
            Assert.Equal(expectedResult, result.VerticesOrder);
        }

        private UndirectedGraph CreateComplexUndirectedGraphWithWeight(List<Vertex> vertices, List<Edge> edges)
        {
            var A = "A";
            var B = "B";
            var C = "C";
            var D = "D";
            var E = "E";
            var F = "F";
            var G = "G";
            vertices.Add(undirectedGraphFactory.CreateVertex(A));
            vertices.Add(undirectedGraphFactory.CreateVertex(B));
            vertices.Add(undirectedGraphFactory.CreateVertex(C));
            vertices.Add(undirectedGraphFactory.CreateVertex(D));
            vertices.Add(undirectedGraphFactory.CreateVertex(E));
            vertices.Add(undirectedGraphFactory.CreateVertex(F));
            vertices.Add(undirectedGraphFactory.CreateVertex(G));

            edges.Add(undirectedGraphFactory.CreateEdge(A, B, 1));
            edges.Add(undirectedGraphFactory.CreateEdge(A, C, 2));
            edges.Add(undirectedGraphFactory.CreateEdge(B, D, 2));
            edges.Add(undirectedGraphFactory.CreateEdge(C, D, 3));
            edges.Add(undirectedGraphFactory.CreateEdge(B, F, 3));
            edges.Add(undirectedGraphFactory.CreateEdge(C, E, 4));
            edges.Add(undirectedGraphFactory.CreateEdge(D, F, 3));
            edges.Add(undirectedGraphFactory.CreateEdge(D, E, 2));
            edges.Add(undirectedGraphFactory.CreateEdge(D, G, 3));
            edges.Add(undirectedGraphFactory.CreateEdge(E, G, 5));
            edges.Add(undirectedGraphFactory.CreateEdge(F, G, 4));

            return undirectedGraphFactory.CreateUndirectedGraph(vertices, edges);
        }
    }
}