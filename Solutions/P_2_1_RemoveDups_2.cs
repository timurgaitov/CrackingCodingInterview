using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Solutions
{
    internal static class P_2_1_RemoveDups_2
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

            var p = l.First;

            while (p != null)
            {
                var duplicateP = p.Next;

                while (duplicateP != null)
                {
                    var next = duplicateP.Next;

                    if (duplicateP.Value == p.Value)
                    {
                        l.Remove(duplicateP);
                    }

                    duplicateP = next;
                }

                p = p.Next;
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
