using System;
using System.Collections.Generic;
using System.Linq;
using CrackingCodingInterview.Algorithms;
using CrackingCodingInterview.Debug;
using CrackingCodingInterview.Structures;
using CrackingCodingInterview.Helpers;
using BTN = BinaryTreeNode<int>;

namespace CrackingCodingInterview.Problems
{
    internal static class P_4_8_FirstCommonAncestor
    {
        public static void Solve()
        {
            var root = P_4_2_MinimalTree.Solve();

            bool stop = false;
            DFS(root, 0, 15, ref stop);
            stop = false;
            DFS(root, 1, 3, ref stop);
            stop = false;
            DFS(root, 3, 5, ref stop);
            stop = false;
            DFS(root, 10, 13, ref stop);
        }

        private static int DFS(BTN node, int node1, int node2, ref bool stop)
        {
            if (stop)
            {
                return 0;
            }

            if (node == null)
            {
                return 0;
            }

            var foundOnLeft = DFS(node.Left, node1, node2, ref stop);

            if (stop)
            {
                return 0;
            }

            var foundOnRight = DFS(node.Right, node1, node2, ref stop);

            if (stop)
            {
                return 0;
            }

            if (foundOnLeft + foundOnRight > 1)
            {
                Console.WriteLine($"First common ancestor of {node1} and {node2}: {node.Value}");
                stop = true;
                return foundOnLeft + foundOnRight;
            }

            var found = node.Value == node1 || node.Value == node2 ? 1 : 0;

            return found + foundOnLeft + foundOnRight;
        }

    }
}