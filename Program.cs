using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CrackingCodingInterview.Problems;

namespace CrackingCodingInterview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            P_3_4_QueueViaStacks.Solve();
        }

        static bool Q_1_1_HasAllUniqueChars(string str)
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

        static bool Q_1_1_HasAllUniqueChars_NoAdditionalStructures(string str)
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

        static bool Q_1_2_IsPermutation(string str, string original) 
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

        static string Q_1_3_UrlEncodeSpaces(string str, int strSize)
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

        static bool Q_1_4_IsPalindromPermutation(string str)
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

        static bool Q_1_5_IsStringOneEditAway(string str1, string str2)
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

        static string Q_1_6_CompressString(string str)
        {
            var sb = new StringBuilder();

            const char nullChar = '\0';

            char countChar = nullChar;
            var count = 0;

            for (var i = 0; i <= str.Length; i++)
            {
                var ch = i == str.Length ? nullChar : str[i];

                if (ch != countChar)
                {
                    if (countChar != nullChar)
                    {
                        sb.Append(count);
                        count = 0;
                    }

                    countChar = ch;
                    sb.Append(countChar);
                }
                
                count++;
            }

            return sb.Length < str.Length ? sb.ToString() : str;
        }

        static void Q_1_7_RotateMatrix90Deg(int[,] nxnMatrix)
        {
            var N = nxnMatrix.GetUpperBound(0);
            var M = nxnMatrix.GetUpperBound(1);

            if (N != M)
            {
                throw new ArgumentException();
            }

            _PrintMatrix(nxnMatrix);

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

            _PrintMatrix(nxnMatrix);
        }

        static void Q_1_8_ZeroMatrix(int[,] nxmMatrix)
        {
            _PrintMatrix(nxmMatrix);

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
                    _PrintMatrix(nxmMatrix);
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

            _PrintMatrix(nxmMatrix);
        }

        static void _PrintMatrix(int[,] nxmMatrix)
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

        static bool Q_1_9_IsStringRotation(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            return (str1 + str1).IndexOf(str2) != -1;


            // var str1Canonical = _RotateStringToCanonicalForm(str1);
            // var str2Canonical = _RotateStringToCanonicalForm(str2);

            // return str1Canonical == str2Canonical; // uses IsSubstring
        }

        // static string _RotateStringToCanonicalForm(string str)
        // {
        //     var minPos = 0;

        //     for (var i = 1; i < str.Length; i++)
        //     {
        //         if (str[i] < str[minPos])
        //         {
        //             minPos = i;
        //         }
        //         else if (str[i] == str[minPos])
        //         {
        //             for (var j = 1; j < str.Length; j++)
        //             {
        //                 var strJ = str[(i + j) % str.Length];
        //                 var minPosJ = str[(minPos + j) % str.Length];

        //                 if (strJ < minPosJ)
        //                 {
        //                     minPos = i;
        //                     break;
        //                 }
        //                 else if (strJ > minPosJ)
        //                 {
        //                     break;
        //                 }
        //             }
        //         }
        //     }

        //     return str.Substring(minPos) + str.Substring(0, minPos);
        // }

        static void Q_2_1_RemoveDuplicatesFromLinkedList()
        {
            var l = new LinkedList<int>();
            l.AddLast(1);
            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);
            l.AddLast(1);
            l.AddLast(2);

            var hs = new HashSet<int>();

            var p = l.First;

            while (p != null)
            {
                var next = p.Next;

                if (hs.Contains(p.Value))
                {
                    l.Remove(p);
                }
                else
                {
                    hs.Add(p.Value);
                }

                p = next;
            }
            
            p = l.First;

            while (p != null)
            {
                Console.WriteLine(p.Value);

                p = p.Next;
            }
        }

        static void Q_2_1_RemoveDuplicatesFromLinkedList_WithoutAdditionalStructures()
        {
            var l = new LinkedList<int>();
            l.AddLast(1);
            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);
            l.AddLast(1);
            l.AddLast(2);

            var p = l.First;

            while (p != null)
            {
                var duplicateP = p.Next;

                while (duplicateP != null)
                {
                    var next = duplicateP.Next;

                    if (duplicateP.Value == p.Value)
                    {
                        l.Remove(duplicateP);
                    }

                    duplicateP = next;
                }

                p = p.Next;
            }
            
            p = l.First;

            while (p != null)
            {
                Console.WriteLine(p.Value);

                p = p.Next;
            }
        }

        static void Q_2_2_KthToLast()
        {
            var l = new LinkedList<int>();
            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);
            l.AddLast(4);
            l.AddLast(5);
            l.AddLast(6);

            for (var i = 0; i <= l.Count; i++)
            {
                int? result = null;
                Q_2_2_KthToLast_Impl(l.First, i, ref result);
                Console.WriteLine(result?.ToString() ?? "out of range");
            }
        }

        static int Q_2_2_KthToLast_Impl(LinkedListNode<int> node, int k, ref int? result)
        {
            var revI = node.Next == null ? 0 : Q_2_2_KthToLast_Impl(node.Next, k, ref result) + 1;

            if (revI == k)
            {
                result = node.Value;
            }

            return revI;
        }

        static void Q_2_2_KthToLast_Iteratively()
        {
            var l = new LinkedList<int>();
            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);
            l.AddLast(4);
            l.AddLast(5);
            l.AddLast(6);

            const int k = 2;

            var node = l.First;
            var i = 0;

            LinkedListNode<int> kth = null;

            while (node != null)
            {
                if (kth == null && i == k)
                {
                    kth = l.First;
                }
                else if (kth != null)
                {
                    kth = kth.Next;
                }

                node = node.Next;
                i++;
            }

            Console.WriteLine(kth?.Value);
        }

        static void Q_2_3_DeleteMiddleNode()
        {
            var l = new LinkedList<int>();
            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);
            l.AddLast(4);
            l.AddLast(5);
            l.AddLast(6);

            var node = l.First.Next.Next;

            while (node.Next != null)
            {
                node.Value = node.Next.Value;
                node = node.Next;
            }

            l.Remove(node);

            Console.WriteLine(string.Join(", ", l.ToArray()));
        }
    }
}
