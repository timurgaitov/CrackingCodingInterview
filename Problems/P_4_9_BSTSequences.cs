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
    internal static class P_4_9_BSTSequences
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
                    Right = new BTN(100),
                },
            };

            root.Print();

            var sequences = GetSequences(root);

            foreach (var sequence in sequences.Select(s => string.Join(" ", s)).Distinct())
            {
                Console.WriteLine(sequence);
            }
        }

        private static IEnumerable<IEnumerable<int>> GetSequences(BTN node)
        {
            if (node == null)
            {
                yield return new int[0];
                yield break;
            }

            if (node.Left == null && node.Right == null)
            {
                yield return new[] { node.Value };
            }

            var left = GetSequences(node.Left);
            var right = GetSequences(node.Right);

            foreach (var l in left)
            {
                foreach (var r in right)
                {
                    // Console.WriteLine("l: " + string.Join(" ", l));
                    // Console.WriteLine("r: " + string.Join(" ", r));
                    yield return new[] { node.Value }.Concat(l).Concat(r);
                    yield return new[] { node.Value }.Concat(r).Concat(l);
                }
            }
        }
    }
}