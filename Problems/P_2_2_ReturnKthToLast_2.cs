using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Problems
{
    internal static class P_2_2_ReturnKthToLast_2
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

            const int k = 2;

            var node = l.First;
            var i = 0;

            LinkedListNode<int> kth = null;

            while (node != null)
            {
                if (kth == null && i == k)
                {
                    kth = l.First;
                }
                else if (kth != null)
                {
                    kth = kth.Next;
                }

                node = node.Next;
                i++;
            }

            Console.WriteLine(kth?.Value);
        }
    }
}
