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
    internal static class P_4_6_Successor
    {
        public static void Solve()
        {
            var root = new BTN(8)
            {
                Left = new BTN(4)
                {
                    Left = new BTN(2),
                    Right = new BTN(6),
                },
                Right = new BTN(10)
                {
                    // Left = new BTN(123),
                    Right = new BTN(20),
                },
            };

            root.Print();

            var visited = new HashSet<BTN>();

            PrintSuccessor(root.Left.Right, visited);
        }

        private static void PrintSuccessor(BTN node, HashSet<BTN> visited)
        {
            Console.WriteLine($"Find successor of {node.Value}");

            if (node == null)
            {
                return;
            }

            if (!visited.Contains(node.Right) && node.Right != null)
            {
                var leftmost = TraveseToLeftmost(node.Right);

                Console.WriteLine($"Successor: {leftmost.Value}");
            }
            else
            {
                visited.Add(node);

                PrintSuccessor(node.Parent, visited);
            }
        }

        private static BTN TraveseToLeftmost(BTN node)
        {
            if (node == null)
            {
                return null;
            }

            return TraveseToLeftmost(node.Left) ?? node;
        }
    }
}