using System;

namespace CrackingCodingInterview.Solutions
{
    internal static class P_1_5_OneWay
    {
        public static bool Solve(string str1, string str2)
        {
            var lengthDiff = Math.Abs(str1.Length - str2.Length);

            if (lengthDiff == 0) // may have a replacement
            {
                var hasReplacement = false;

                for (var i = 0; i < str1.Length; i++)
                {
                    if (str1[i] != str2[i])
                    {
                        if (hasReplacement) 
                        {
                            return false; // more than one edits
                        }

                        hasReplacement = true;
                    }
                }

                return true;
            }
            else if (lengthDiff == 1) // should have an insertion or a removal
            {
                string shortStr, longStr;

                if (str1.Length > str2.Length)
                {
                    shortStr = str2;
                    longStr = str1;
                }
                else
                {
                    shortStr = str1;
                    longStr = str2;
                }

                for (int i = 0, j = 0; i < longStr.Length && j < shortStr.Length; i++, j++)
                {
                    if (longStr[i] != shortStr[j])
                    {
                        i++;

                        if (i >= longStr.Length || longStr[i] != shortStr[j])
                        {
                            return false; // more than one edits
                        }
                    }
                }

                return true;
            }

            return false;
        }
    }
}
