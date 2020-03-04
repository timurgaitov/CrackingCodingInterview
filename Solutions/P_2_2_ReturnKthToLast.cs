using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Solutions
{
    internal static class P_2_2_ReturnKthToLast
    {
        public static void Solve()
        {
            var l = new LinkedList<int>();
            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);
            l.AddLast(4);
            l.AddLast(5);
            l.AddLast(6);

            for (var i = 0; i <= l.Count; i++)
            {
                int? result = null;
                SolveRecursively(l.First, i, ref result);
                Console.WriteLine(result?.ToString() ?? "out of range");
            }
        }

        private static int SolveRecursively(LinkedListNode<int> node, int k, ref int? result)
        {
            var revI = node.Next == null ? 0 : SolveRecursively(node.Next, k, ref result) + 1;

            if (revI == k)
            {
                result = node.Value;
            }

            return revI;
        }
    }
}
