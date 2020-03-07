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

            var root = BuildMinimalTree(0, array.Length - 1, array);

            root.Print();

            return root;
        }

        private static BinaryTreeNode<int> BuildMinimalTree(int fromIndex, int toIndex, int[] array)
        {
            if (toIndex < fromIndex)
            {
                return null;
            }

            var centerIndex = fromIndex + (toIndex - fromIndex + 1) / 2;

            return new BinaryTreeNode<int>(array[centerIndex])
            {
                Left = BuildMinimalTree(fromIndex, centerIndex - 1, array),
                Right = BuildMinimalTree(centerIndex + 1, toIndex, array),
            };
        }
    }
}