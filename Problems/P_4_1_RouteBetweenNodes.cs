using System;
using System.Collections.Generic;
using System.Linq;
using CrackingCodingInterview.Algorithms;
using CrackingCodingInterview.Debug;
using CrackingCodingInterview.Structures;

namespace CrackingCodingInterview.Problems
{
    internal static class P_4_1_RouteBetweenNodes
    {
        public static void Solve()
        {
            var nodes = Enumerable
                .Range(0, 10)
                .Select(i => new GraphNode<int>(i))
                .ToArray();

            nodes[0].AddAdjacentNodes(nodes[2]);
            nodes[1].AddAdjacentNodes(nodes[3]);
            nodes[2].AddAdjacentNodes(nodes[0], nodes[1], nodes[4]);
            nodes[3].AddAdjacentNodes(nodes[1], nodes[5]);
            nodes[4].AddAdjacentNodes(nodes[2], nodes[6], nodes[7]);
            nodes[5].AddAdjacentNodes(nodes[3], nodes[6], nodes[7]);
            nodes[6].AddAdjacentNodes(nodes[2], nodes[4]);
            nodes[7].AddAdjacentNodes(nodes[6]);
            nodes[8].AddAdjacentNodes(nodes[9]);
            nodes[9].AddAdjacentNodes(nodes[8]);

            var bfs1 = BreadthFirstSearch.SearchStartingFrom(nodes[0]).GetEnumerator();
            var bfs2 = BreadthFirstSearch.SearchStartingFrom(nodes[5]).GetEnumerator();

            var visited1 = new HashSet<GraphNode<int>>();
            var visited2 = new HashSet<GraphNode<int>>();

            var searchesFinished = 0;

            while (searchesFinished < 2)
            {
                if (bfs1.MoveNext())
                {
                    var node1 = bfs1.Current;

                    Console.WriteLine($"1: {node1.Value}");

                    if (visited2.Contains(node1))
                    {
                        Console.WriteLine("Found a route");
                        break;
                    }

                    visited1.Add(node1);
                }
                else
                {
                    searchesFinished++;
                }
                
                if (bfs2.MoveNext())
                {
                    var node2 = bfs2.Current;
                    Console.WriteLine($"\t2: {node2.Value}");

                    if (visited1.Contains(node2))
                    {
                        Console.WriteLine("Found a route");
                        break;
                    }

                    visited2.Add(node2);
                }
                else
                {
                    searchesFinished++;
                }
            }
        }
    }
}