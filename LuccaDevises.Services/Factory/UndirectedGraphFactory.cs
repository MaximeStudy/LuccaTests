using LuccaDevises.Domain.Graph;
using LuccaDevises.Domain.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LuccaDevises.Services.Factory
{
    public class UndirectedGraphFactory
    {
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

        public Edge CreateEdge(string startCurrency, string endCurrency, int weight = 1)
        {
            if (startCurrency == endCurrency)
            {
                throw new ArgumentException($"Start currency {startCurrency} cannot be the same as end currency {endCurrency}!");
            }

            var vertexOne = new Vertex(startCurrency);
            var vertexTwo = new Vertex(endCurrency);

            var edge = new Edge(vertexOne, vertexTwo, weight);

            return edge;
        }
    }
}