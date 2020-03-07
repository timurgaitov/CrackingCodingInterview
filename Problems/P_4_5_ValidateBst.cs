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
    internal static class P_4_5_ValidateBst
    {
        public static void Solve()
        {
            var root = new BTN(8)
            {
                Left = new BTN(4)
                {
                    Left = new BTN(2),
                    Right = new BTN(6), // bst
                    // Right = new BTN(106), // not bst
                },
                Right = new BTN(10)
                {
                    Right = new BTN(20),
                },
            };

            root = P_4_2_MinimalTree.Solve();

            var isBst = IsBst(root, null, null);

            Console.WriteLine(isBst);
        }

        private static bool IsBst(BinaryTreeNode<int> node, int? mustBeLessOrEqualThan, int? mustBeGreaterThan)
        {
            if (node == null)
            {
                return true;
            }

            var left = node.Left;
            var right = node.Right;

            if (left?.Value > node.Value || right?.Value <= node.Value)
            {
                return false;
            }

            if (mustBeLessOrEqualThan.HasValue 
                && (left?.Value > mustBeLessOrEqualThan.Value || right?.Value > mustBeLessOrEqualThan.Value))
            {
                return false;
            }

            if (mustBeGreaterThan.HasValue 
                && (left?.Value <= mustBeGreaterThan.Value || right?.Value <= mustBeGreaterThan.Value))
            {
                return false;
            }

            return IsBst(node.Left, node.Value, null) 
                && IsBst(node.Right, null, node.Value);
        }
    }
}