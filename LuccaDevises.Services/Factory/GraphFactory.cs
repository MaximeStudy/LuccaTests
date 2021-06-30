﻿using LuccaDevises.Domain.Graph;
using LuccaDevises.Domain.Input;
using System.Collections.Generic;
using System.Linq;

namespace LuccaDevises.Services.Factory
{
    public class GraphFactory
    {
        public Graph Create(List<ExchangeRate> exchangeRates)
        {
            var vertices = exchangeRates
                                     .SelectMany(ip => new[] { ip.StartCurrency, ip.EndCurrency })
                                     .Distinct()
                                     .Select(vertex => CreateVertex(vertex))
                                     .ToList();

            var edges = exchangeRates
                                  .Select(exchangeRate => CreateEdge(exchangeRate))
                                  .ToList();

            return new Graph(vertices, edges);
        }

        public Vertex CreateVertex(string vertex)
        {
            return new Vertex(vertex);
        }

        public Edge CreateEdge(ExchangeRate exchangeRate)
        {
            var vertexOne = new Vertex(exchangeRate.StartCurrency);
            var vertexTwo = new Vertex(exchangeRate.EndCurrency);

            var edge = new Edge(vertexOne, vertexTwo);

            return edge;
        }
    }
}