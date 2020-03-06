using System;
using System.Collections.Generic;
using CrackingCodingInterview.Structures;

namespace CrackingCodingInterview.Algorithms
{
    public static class BreadthFirstSearch
    {
        public static IEnumerable<T> SearchStartingFrom<T>(T startNode) where T : IBreadthFirstSearchable<T>
        {
            return Search<T>(new[] { startNode });
        }

        public static IEnumerable<T> Search<T>(IList<T> nodes) where T : IBreadthFirstSearchable<T>
        {
            var visited = new HashSet<T>();
            var queue = new Queue<T>();

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
                    
                    yield return node;

                    foreach (var adjacentNode in node.AdjacentNodes)
                    {
                        queue.Enqueue(adjacentNode);
                    }
                }
            }
        }
    }
}