using System;
using System.Collections.Generic;
using CrackingCodingInterview.Structures;

namespace CrackingCodingInterview.Algorithms
{
    public static class BreadthFirstSearch
    {
        public static void Search<T>(IList<GraphNode<T>> nodes)
        {
            var visited = new HashSet<GraphNode<T>>();
            var queue = new Queue<GraphNode<T>>();

            foreach (var startNode in nodes)
            {
                queue.Enqueue(startNode);

                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();

                    if (visited.Contains(node))
                    {
                        continue;
                    }

                    visited.Add(node);
                    
                    Console.WriteLine(node.Value);

                    foreach (var adjacentNode in node.AdjacentNodes)
                    {
                        queue.Enqueue(adjacentNode);
                    }
                }
            }
        }
    }
}