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

            var list = new List<LinkedList<BinaryTreeNode<int>>>();

            DFS(root, 0, list);

            Console.WriteLine(list.Count);

            for (var i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i}: {list[i].Count()}");
            }
        }

        private static void DFS(BinaryTreeNode<int> node, int depth, List<LinkedList<BinaryTreeNode<int>>> list)
        {
            if (depth >= list.Count)
            {
                list.Add(new LinkedList<BinaryTreeNode<int>>());
            }
            
            list[depth].AddLast(node);

            if (node.Left != null)
            {
                DFS(node.Left, depth + 1, list);
            }

            if (node.Right != null)
            {
                DFS(node.Right, depth + 1, list);
            }
        }
    }
}