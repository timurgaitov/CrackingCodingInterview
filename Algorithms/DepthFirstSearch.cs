using System;
using System.Collections.Generic;
using CrackingCodingInterview.Structures;

namespace CrackingCodingInterview.Algorithms
{
    public static class DepthFirstSearch
    {
        public static void Search<T>(IList<GraphNode<T>> graphNodes)
        {
            var visited = new HashSet<GraphNode<T>>();
            var stack = new Stack<GraphNode<T>>();

            foreach (var startNode in graphNodes)
            {
                stack.Push(startNode);

                while (stack.Count > 0)
                {
                    var node = stack.Pop();

                    if (visited.Contains(node))
                    {
                        continue;
                    }

                    visited.Add(node);
                    
                    Console.WriteLine(node.Value);

                    foreach (var adjacentNode in node.AdjacentNodes)
                    {
                        stack.Push(adjacentNode);
                    }
                }
            }
        }
    }
}