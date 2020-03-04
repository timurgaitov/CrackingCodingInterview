using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Debug
{
    internal static class PrintStack
    {
        public static void Print<T>(this Stack<T> stack)
        {
            Console.WriteLine(string.Join(" → ", stack));
        }
    }
}