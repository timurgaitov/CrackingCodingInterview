using System;
using CrackingCodingInterview.Debug;

namespace CrackingCodingInterview.Problems
{
    internal static class P_1_7_RotateMatrix
    {
        public static void Solve(int[,] nxnMatrix)
        {
            var N = nxnMatrix.GetUpperBound(0);
            var M = nxnMatrix.GetUpperBound(1);

            if (N != M)
            {
                throw new ArgumentException();
            }

            nxnMatrix.Print();

            for (var i = 0; i <= N / 2; i++)
            {
                for (var j = i; j <= N - 1 - i; j++)
                {
                    var buf = nxnMatrix[i, j];
                    nxnMatrix[i, j] = nxnMatrix[N - j, i];
                    nxnMatrix[N - j, i] = nxnMatrix[N - i, N - j];
                    nxnMatrix[N - i, N - j] = nxnMatrix[j, N - i];
                    nxnMatrix[j, N - i] = buf;
                }
            }

            nxnMatrix.Print();
        }
    }
}
