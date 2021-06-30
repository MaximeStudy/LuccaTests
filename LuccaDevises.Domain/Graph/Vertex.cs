using System;
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

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Vertex vertex = (Vertex)obj;
                return Name == vertex.Name;
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}