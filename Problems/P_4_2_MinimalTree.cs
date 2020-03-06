using System;
using System.Collections.Generic;
using System.Linq;
using CrackingCodingInterview.Algorithms;
using CrackingCodingInterview.Debug;
using CrackingCodingInterview.Structures;
using CrackingCodingInterview.Helpers;

namespace CrackingCodingInterview.Problems
{
    internal static class P_4_2_MinimalTree
    {
        public static BinaryTreeNode<int> Solve()
        {
            var array = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            var rootIndex = array.Length / 2;
            var root = new BinaryTreeNode<int>(array[rootIndex]);

            var left = rootIndex - 1;
            var right = rootIndex + 1;
            root.Left = new BinaryTreeNode<int>(array[left]);
            root.Right = new BinaryTreeNode<int>(array[right]);

            BuildLeft(root.Left, 0, array, left);
            BuildRight(root.Right, 0, array, right);

            root.Print();

            return root;
        }

        private static void BuildLeft(BinaryTreeNode<int> node, int nodeIndex, int[] array, int startPos)
        {
            var left = nodeIndex * 2 + 2;
            var right = nodeIndex * 2 + 1;

            if (startPos - left >= 0)
            {
                node.Left = new BinaryTreeNode<int>(array[startPos - left]);

                BuildLeft(node.Left, left, array, startPos);
            }

            if (startPos - right >= 0)
            {
                node.Right = new BinaryTreeNode<int>(array[startPos - right]);

                BuildLeft(node.Right, right, array, startPos);
            }
        }

        private static void BuildRight(BinaryTreeNode<int> node, int nodeIndex, int[] array, int startPos)
        {
            var left = nodeIndex * 2 + 1;
            var right = nodeIndex * 2 + 2;

            if (startPos + left < array.Length)
            {
                node.Left = new BinaryTreeNode<int>(array[startPos + left]);

                BuildRight(node.Left, left, array, startPos);
            }

            if (startPos + right < array.Length)
            {
                node.Right = new BinaryTreeNode<int>(array[startPos + right]);

                BuildRight(node.Right, right, array, startPos);
            }
        }
    }
}