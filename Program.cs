using System;
using CrackingCodingInterview.Algorithms;
using CrackingCodingInterview.Structures;

namespace CrackingCodingInterview
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            PrintSpiral(0);
            PrintSpiral(1);
            PrintSpiral(2);
            PrintSpiral(3);
            PrintSpiral(4);
            PrintSpiral(5);
            PrintSpiral(6);
        }

        private static void PrintSpiral(int n)
        {
            var spiral = new int[n, n];

            var current = 1;

            var lap = 0;

            while (lap < n / 2 + 1)
            {
                for (var col = lap; col < n - lap; col++)
                {
                    spiral[lap, col] = current++;
                }

                for (var row = lap + 1; row < n - lap; row++)
                {
                    spiral[row, n - lap - 1] = current++;
                }

                for (var col = n - lap - 2; col >= lap; col--)
                {
                    spiral[n - lap - 1, col] = current++;
                }

                for (var row = n - lap - 2; row >= lap + 1; row--)
                {
                    spiral[row, lap] = current++;
                }

                lap++;
            }

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Console.Write(spiral[i, j].ToString().PadLeft(2) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
