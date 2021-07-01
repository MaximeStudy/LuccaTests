using LuccaDevises.Domain.Graph;
using LuccaDevises.Domain.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LuccaDevises.Services.Factory
{
    public class UndirectedGraphFactory
    {
        public UndirectedGraph CreateUndirectedGraph(List<Vertex> vertices, List<Edge> edges)
        {
            return new UndirectedGraph(vertices, edges);
        }

        public UndirectedGraph CreateUndirectedGraph(List<ExchangeRate> exchangeRates)
        {
            var vertices = exchangeRates
                                     .SelectMany(ip => new[] { ip.StartCurrency, ip.EndCurrency })
                                     .Distinct()
                                     .Select(vertex => CreateVertex(vertex))
                                     .ToList();

            var edges = exchangeRates
                                  .Select(exchangeRate => CreateEdge(exchangeRate))
                                  .ToList();

            return new UndirectedGraph(vertices, edges);
        }

        public Vertex CreateVertex(string vertex)
        {
            return new Vertex(vertex);
        }

        public Edge CreateEdge(ExchangeRate exchangeRate)
        {
            return CreateEdge(exchangeRate.StartCurrency, exchangeRate.EndCurrency);
        }

        public Edge CreateEdge(string startVertexName, string endVertexName, int weight = 1)
        {
            var vertexOne = new Vertex(startVertexName);
            var vertexTwo = new Vertex(endVertexName);

            var edge = CreateEdge(vertexOne, vertexTwo, weight);

            return edge;
        }

        public Edge CreateEdge(Vertex vertexOne, Vertex vertexTwo, int weight = 1)
        {
            if (vertexOne.Equals(vertexTwo))
            {
                throw new ArgumentException($"Vertex one {vertexOne.Name} cannot be the same as end vertex two {vertexOne.Name}!");
            }

            var edge = new Edge(vertexOne, vertexTwo, weight);

            return edge;
        }
    }
}