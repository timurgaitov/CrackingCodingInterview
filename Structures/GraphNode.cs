using System.Collections.Generic;

namespace CrackingCodingInterview.Structures
{
    public class GraphNode<T>
    {
        public GraphNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public List<GraphNode<T>> AdjacentNodes { get; } = new List<GraphNode<T>>();
    }
}