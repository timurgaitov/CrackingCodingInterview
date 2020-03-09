using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Algorithms
{
    public static class InsertionSort
    {
        public static void Sort(IList<int> array)
        {
            for (var i = 1; i < array.Count; i++)
            {
                var r = i - 1;

                while (r >= 0 && array[r] > array[r + 1])
                {
                    var buf = array[r];
                    array[r] = array[r + 1];
                    array[r + 1] = buf;

                    r--;
                }
            }
        }
    }
}