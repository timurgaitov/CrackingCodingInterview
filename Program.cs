using System;
using System.Linq;
using System.Collections.Generic;

namespace CrackingCodingInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = IsStringOneEditAway("axa", "aba");

            System.Console.WriteLine(result);
        }

        static bool HasAllUniqueChars(string str)
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

        static bool HasAllUniqueChars_NoAdditionalStructures(string str)
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

        static bool IsPermutation(string str, string original) 
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

        static string UrlEncodeSpaces(string str, int strSize)
        {
            var arr = str.ToCharArray();

            Array.Resize(ref arr, str.Length);

            var spaceCount = arr.Where((ch, i) => i < strSize).Count(ch => ch == ' ');

            for (var i = strSize - 1; i >= 0; i--)
            {
                var shiftedI = i + spaceCount * 2;

                if (arr[i] == ' ')
                {
                    arr[shiftedI] = '0';
                    arr[shiftedI - 1] = '2';
                    arr[shiftedI - 2] = '%';
                    spaceCount--;
                }
                else
                {
                    arr[shiftedI] = arr[i];
                }
            }

            // var q = new Queue<char>();

            // var startReplace = false;

            // for (var i = 0; i < str.Length; i++)
            // {
            //     if (arr[i] == ' ')
            //     {
            //         startReplace = true;
            //     }

            //     while (startReplace || q.Count > 0) 
            //     {
            //         startReplace = false;

            //         if (arr[i] == ' ') 
            //         {
            //             q.Enqueue('%');
            //             q.Enqueue('2');
            //             q.Enqueue('0');
            //         }
            //         else if (arr[i] != '\0')
            //         {
            //             q.Enqueue(arr[i]);
            //         }

            //         arr[i] = q.Dequeue();
            //         i++;
            //     }
            // }

            return new string(arr);
        }

        static bool IsPalindromPermutation(string str)
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

        static bool IsStringOneEditAway(string str1, string str2)
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
