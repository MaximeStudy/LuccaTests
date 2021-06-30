using System.Diagnostics;

namespace LuccaDevises.Domain.Graph
{
    [DebuggerDisplay("{Name}")]
    public class Vertex
    {
        public Vertex(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}