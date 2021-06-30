using LuccaDevises.Domain.Graph;
using System.Collections.Generic;

namespace LuccaDevises.Domain.RouteFinder
{
    public class ShortestPathResult
    {
        public int Distance { get; set; }

        public Stack<Vertex> VerticesOrder { get; set; }
    }
}