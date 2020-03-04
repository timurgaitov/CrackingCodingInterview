using System;

namespace CrackingCodingInterview.Debug
{
    internal static class PrintMatrix
    {
        public static void Print(this int[,] nxmMatrix)
        {
            var N = nxmMatrix.GetUpperBound(0);
            var M = nxmMatrix.GetUpperBound(1);

            for (var i = 0; i <= N; i++)
            {
                for (var j = 0; j <= M; j++)
                {
                    Console.Write(nxmMatrix[i, j].ToString().PadLeft(2) + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}