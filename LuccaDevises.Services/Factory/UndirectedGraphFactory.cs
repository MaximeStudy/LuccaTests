using LuccaDevises.Domain.Graph;
using LuccaDevises.Domain.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LuccaDevises.Services.Factory
{
    public class UndirectedGraphFactory
    {
        public UndirectedGraph Create(List<ExchangeRate> exchangeRates)
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
            if (exchangeRate.StartCurrency == exchangeRate.EndCurrency)
            {
                throw new ArgumentException($"Start currency {exchangeRate.StartCurrency} cannot be the same as end currency {exchangeRate.EndCurrency}!");
            }

            var vertexOne = new Vertex(exchangeRate.StartCurrency);
            var vertexTwo = new Vertex(exchangeRate.EndCurrency);

            var edge = new Edge(vertexOne, vertexTwo);

            return edge;
        }
    }
}