using System.Diagnostics;

namespace LuccaDevises.Domain.Graph
{
    [DebuggerDisplay("{VertexOne}-{Weight}-{VertexTwo}")]
    public class Edge
    {
        public Edge(Vertex vertexOne, Vertex vertexTwo, int weight = 1)
        {
            VertexOne = vertexOne;
            VertexTwo = vertexTwo;
            Weight = weight;
        }

        public Vertex VertexOne { get; set; }

        public Vertex VertexTwo { get; set; }

        public int Weight { get; set; }
    }
}