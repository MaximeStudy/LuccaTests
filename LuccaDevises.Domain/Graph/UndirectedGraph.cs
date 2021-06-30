using System.Collections.Generic;

namespace LuccaDevises.Domain.Graph
{
    public class UndirectedGraph
    {
        public List<Vertex> Vertices { get; set; }
        public List<Edge> Edges { get; set; }

        public UndirectedGraph(List<Vertex> vertices, List<Edge> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }
    }
}