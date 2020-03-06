namespace CrackingCodingInterview.Helpers
{
    internal static class NumberExtensions
    {
        public static bool IsPowerOfTwo(this int x)
        {
            return x != 0 && (x & (x - 1)) == 0;
        }
    }
}