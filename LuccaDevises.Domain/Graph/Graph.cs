using System.Collections.Generic;

namespace LuccaDevises.Domain.Graph
{
    public class Graph
    {
        private readonly List<Vertex> vertices;
        private readonly List<Edge> edges;

        public Graph(List<Vertex> vertices, List<Edge> edges)
        {
            this.vertices = vertices;
            this.edges = edges;
        }
    }
}