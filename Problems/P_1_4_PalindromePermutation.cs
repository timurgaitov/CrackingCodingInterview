namespace CrackingCodingInterview.Solutions
{
    internal static class P_1_4_PalindromePermutation
    {
        public static bool Solve(string str)
        {
            long bits = 0;

            for (var i = 0; i < str.Length; i++)
            {
                long bit = (long)1 << str[i];

                if ((bits & bit) == bit)
                {
                    bits ^= bit;
                }
                else
                {
                    bits |= bit;
                }
            }

            while (bits != 0)
            {
                if ((bits & 1) == 1)
                {
                    if ((bits >> 1) != 0)
                    {
                        return false;
                    }
                }

                bits >>= 1;
            }

            return true;
        }
    }
}
