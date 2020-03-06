using System;
using System.Collections.Generic;
using System.Linq;
using CrackingCodingInterview.Algorithms;
using CrackingCodingInterview.Debug;
using CrackingCodingInterview.Structures;
using CrackingCodingInterview.Helpers;

namespace CrackingCodingInterview.Problems
{
    internal static class P_4_3_ListOfDepths
    {
        public static void Solve()
        {
            var root = P_4_2_MinimalTree.Solve();

            var bfs = BreadthFirstSearch.SearchStartingFrom(root);

            var count = 0;

            var list = new List<LinkedList<BinaryTreeNode<int>>>();
            var buf = new LinkedList<BinaryTreeNode<int>>();

            foreach (var node in bfs)
            {
                buf.AddLast(node);
                count++;

                if ((count + 1).IsPowerOfTwo())
                {
                    list.Add(buf);
                    buf = new LinkedList<BinaryTreeNode<int>>();
                }
            }

            Console.WriteLine(list.Count);

            for (var i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i}: {list[i].Count()}");
            }
        }
    }
}