namespace CrackingCodingInterview.Problems
{
    internal static class P_1_1_IsUnique_2
    {
        public static bool Solve(string str)
        {
            ulong bits = 0;

            for (var i = 0; i < str.Length; i++)
            {
                var bit = (ulong)1 << str[i];

                if ((bits & bit) == bit) 
                {
                    return false;
                }
                else 
                {
                    bits = bits | bit;
                }
            }

            return true;

            // var chars = str.ToCharArray();

            // Array.Sort(chars); // O(nlog(n))

            // for (var i = 1; i < str.Length; i++) // O(n)
            // {
            //     if (str[i - 1] == str[i]) 
            //     {
            //         return false;
            //     }
            // }

            // return true;

            // for (var i = 0; i < str.Length; i++)
            // {
            //     for (var j = i + 1; j < str.Length; j++) 
            //     {
            //         if (str[i] == str[j]) 
            //         {
            //             return false;
            //         }
            //     }
            // }

            // return true;
        }
    }
}
