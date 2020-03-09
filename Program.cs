using System;
using CrackingCodingInterview.Algorithms;
using CrackingCodingInterview.Structures;

namespace CrackingCodingInterview
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var test = new [] { 5, 4, 1, 2, 3, 2, 19 };

            Console.WriteLine(string.Join(" ", test));
            HeapSort.Sort(test);
            Console.WriteLine(string.Join(" ", test));
        }
    }
}
