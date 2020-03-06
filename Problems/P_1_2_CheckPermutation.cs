using System.Collections.Generic;
using System.Linq;

namespace CrackingCodingInterview.Problems
{
    internal static class P_1_2_CheckPermutation
    {
        public static bool Solve(string str, string original) 
        {
            if (str.Length != original.Length) 
            {
                return false;
            }

            var dict = new Dictionary<char, int>();

            for (var i = 0; i < original.Length; i++)
            {
                var key = original[i];

                if (!dict.ContainsKey(key)) 
                {
                    dict.Add(key, 1);
                }
                else
                {
                    dict[key]++;
                }
            }

            for (var i = 0; i < str.Length; i++)
            {
                var key = str[i];

                if (!dict.ContainsKey(key)) 
                {
                    return false;
                }

                if (dict[key] < 1)
                {
                    return false;
                }

                dict[key]--;
            }

            return dict.Values.All(v => v == 0);
        }
    }
}
