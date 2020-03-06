using System.Collections.Generic;

namespace CrackingCodingInterview.Solutions
{
    internal static class P_1_1_IsUnique
    {
        public static bool Solve(string str)
        {
            var hs = new HashSet<char>();

            for (var i = 0; i < str.Length; i++)
            {
                var ch = str[i];

                if (hs.Contains(ch)) {
                    return false;
                } else {
                    hs.Add(ch);
                }
            }

            return true;
        }
    }
}
