using System;
using System.Collections.Generic;
using System.Linq;
using CrackingCodingInterview.Algorithms;
using CrackingCodingInterview.Debug;
using CrackingCodingInterview.Structures;
using CrackingCodingInterview.Helpers;

namespace CrackingCodingInterview.Problems
{
    internal static class P_4_4_CheckBalanced
    {
        public static void Solve()
        {
            var root = P_4_2_MinimalTree.Solve();

            var theMostLeft = root.Left.Left.Left;

            theMostLeft.Left = new BinaryTreeNode<int>(100);
            theMostLeft = theMostLeft.Left;
            theMostLeft.Left = new BinaryTreeNode<int>(100);

            var maxDepth = 0;
            var cancel = false;

            DFS(root, 0, ref maxDepth, ref cancel);
            if (!cancel)
            {
                Console.WriteLine("Balanced");
            }
        }

        private static void DFS(BinaryTreeNode<int> node, int depth, ref int maxDepth, ref bool cancel)
        {
            if (cancel)
            {
                return;
            }

            if (node.Left != null)
            {
                DFS(node.Left, depth + 1, ref maxDepth, ref cancel);
            }
            else if (maxDepth != 0 && maxDepth - depth > 1)
            {
                Console.WriteLine("Not balanced");
                cancel = true;
                return;
            }
            else if (maxDepth == 0)
            {
                maxDepth = depth;
            }

            if (node.Right != null)
            {
                DFS(node.Right, depth + 1, ref maxDepth, ref cancel);
            }
            else if (maxDepth != 0 && maxDepth - depth > 1)
            {
                Console.WriteLine("Not balanced");
                cancel = true;
                return;
            }
            else if (maxDepth == 0)
            {
                maxDepth = depth;
            }
        }
    }
}