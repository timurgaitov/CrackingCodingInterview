using System;
using System.Linq;

namespace CrackingCodingInterview.Solutions
{
    internal static class P_1_3_Urlify
    {
        public static string Solve(string str, int strSize)
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
    }
}
