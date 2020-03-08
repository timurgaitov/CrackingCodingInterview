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
    internal static class P_4_10_CheckSubtree
    {
        public static void Solve()
        {
            var root = new BTN(3)
            {
                Left = new BTN(1)
                {
                    Right = new BTN(2),
                },
                Right = new BTN(5)
                {
                    Left = new BTN(4),
                    Right = new BTN(100)
                    {
                        Left = new BTN(23),
                        Right = new BTN(17),
                    },
                },
            };

            root.Print();

            var subtreeRoot = new BTN(5)
            {
                Right = new BTN(100)
                {
                    Left = new BTN(23),
                },
            };

            subtreeRoot.Print();

            DFS_HasReachedSubtreeLeafs(root, null, subtreeRoot);
        }

        private static bool DFS_HasReachedSubtreeLeafs(BTN node, BTN subtreeNode, BTN subtreeRoot)
        {
            if (node == null)
            {
                return false;
            }

            if (subtreeNode != null && node.Value != subtreeNode.Value)
            {
                subtreeNode = null;
            }

            if (subtreeNode == null && node.Value == subtreeRoot.Value)
            {
                subtreeNode = subtreeRoot;
            }

            var leftReachedLeafs = subtreeNode != null && subtreeNode.Left == null || DFS_HasReachedSubtreeLeafs(node.Left, subtreeNode?.Left, subtreeRoot);

            var rightReachedLeafs = subtreeNode != null && subtreeNode.Right == null || DFS_HasReachedSubtreeLeafs(node.Right, subtreeNode?.Right, subtreeRoot);

            if (node.Value == subtreeRoot.Value && leftReachedLeafs && rightReachedLeafs)
            {
                Console.WriteLine("Is a subtree!");
            }

            return leftReachedLeafs 
                && rightReachedLeafs;
        }
    }
}