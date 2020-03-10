using System;
using System.Collections.Generic;
using System.Text;
using CrackingCodingInterview.Algorithms;
using CrackingCodingInterview.Structures;

namespace CrackingCodingInterview
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            PrintLookAndSay("1", 15);
        }

        private static void PrintLookAndSay(string seed, int take)
        {
            Console.WriteLine(seed);

            var current = seed;
            var printed = 0;

            while (printed < take)
            {
                var last = '$';
                var counter = 0;
                var output = new StringBuilder();

                for (var i = 0; i < current.Length; i++)
                {
                    var cur = current[i];

                    if (cur == last)
                    {
                        counter++;
                    }
                    else if (last != '$')
                    {
                        output.Append($"{counter}{last}");
                        counter = 1;
                    }
                    else
                    {
                        counter = 1;
                    }

                    last = cur;
                }
                output.Append($"{counter}{last}");

                var print = output.ToString();

                Console.WriteLine(print);
                current = print;

                printed++;
            }
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
