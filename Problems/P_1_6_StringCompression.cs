using System.Text;

namespace CrackingCodingInterview.Problems
{
    internal static class P_1_6_StringCompression
    {
        public static string Solve(string str)
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
    }
}
