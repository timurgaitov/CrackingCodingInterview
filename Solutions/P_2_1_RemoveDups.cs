using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Solutions
{
    internal static class P_2_1_RemoveDups
    {
        public static void Solve()
        {
            var l = new LinkedList<int>();
            l.AddLast(1);
            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);
            l.AddLast(1);
            l.AddLast(2);

            var hs = new HashSet<int>();

            var p = l.First;

            while (p != null)
            {
                var next = p.Next;

                if (hs.Contains(p.Value))
                {
                    l.Remove(p);
                }
                else
                {
                    hs.Add(p.Value);
                }

                p = next;
            }
            
            p = l.First;

            while (p != null)
            {
                Console.WriteLine(p.Value);

                p = p.Next;
            }
        }
    }
}
