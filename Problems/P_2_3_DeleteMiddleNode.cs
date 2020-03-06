using System;
using System.Collections.Generic;
using System.Linq;

namespace CrackingCodingInterview.Problems
{
    internal static class P_2_3_DeleteMiddleNode
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

            var node = l.First.Next.Next;

            while (node.Next != null)
            {
                node.Value = node.Next.Value;
                node = node.Next;
            }

            l.Remove(node);

            Console.WriteLine(string.Join(", ", l.ToArray()));
        }
    }
}
