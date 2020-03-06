using System.Collections.Generic;

namespace CrackingCodingInterview.Structures
{
    public class GraphNode<T> : IBreadthFirstSearchable<GraphNode<T>>
    {
        public GraphNode(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public IEnumerable<GraphNode<T>> AdjacentNodes { get; } = new List<GraphNode<T>>();

        public void AddAdjacentNodes(params GraphNode<T>[] adjacentNodes)
        {
            (AdjacentNodes as List<GraphNode<T>>).AddRange(adjacentNodes);
        }
    }
}