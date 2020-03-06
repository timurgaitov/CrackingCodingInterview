namespace CrackingCodingInterview.Problems
{
    internal static class P_1_9_StringRotation
    {
        public static bool Solve(string str1, string str2)
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
    }
}
