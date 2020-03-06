using System;
using CrackingCodingInterview.Debug;

namespace CrackingCodingInterview.Problems
{
    internal static class P_1_8_ZeroMatrix
    {
        public static void Solve(int[,] nxmMatrix)
        {
            nxmMatrix.Print();

            var N = nxmMatrix.GetUpperBound(0);
            var M = nxmMatrix.GetUpperBound(1);

            const int zeroCol = -1;
            const int zeroRow = -2;

            if (nxmMatrix[N, M] == 0)
            {
                nxmMatrix[N, M] = zeroRow | zeroCol;
            }

            for (var r = 0; r <= N; r++)
            {
                for (var c = 0; c <= M; c++)
                {
                    if (nxmMatrix[r, c] == 0)
                    {
                        nxmMatrix[r, M] = zeroRow;
                        nxmMatrix[N, c] = zeroCol;
                    }

                    Console.WriteLine($"Step ({r}, {c})");
                    nxmMatrix.Print();
                }
            }

            for (var r = 0; r <= N; r++)
            {
                for (var c = 0; c <= M; c++)
                {
                    if ((nxmMatrix[r, M] & zeroRow) == zeroRow || (nxmMatrix[N, c] & zeroCol) == zeroCol) 
                    {
                        nxmMatrix[r, c] = 0;
                    }
                }
            }

            nxmMatrix.Print();
        }
    }
}
