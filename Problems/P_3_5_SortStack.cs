using System.Collections.Generic;
using CrackingCodingInterview.Debug;

namespace CrackingCodingInterview.Solutions
{
    internal static class P_3_5_SortStack
    {
        public static void Solve()
        {
            var stack = new Stack<int>(new[] { 4, 2, 3, 3, 1 });
            var buf = new Stack<int>();

            while (stack.Count > 0)
            {
                var x = stack.Pop();

                while (buf.Count > 0 && x < buf.Peek())
                {
                    stack.Push(buf.Pop());
                }
                
                buf.Push(x);
            }

            while (buf.Count > 0)
            {
                stack.Push(buf.Pop());
            }
            
            stack.Print();
        }
    }
}