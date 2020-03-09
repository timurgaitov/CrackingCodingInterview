using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Algorithms
{
    public static class QuickSort
    {
        public static void Sort(IList<int> array)
        {
            SortImpl(array, 0, array.Count - 1);
        }

        private static void SortImpl(IList<int> array, int lBound, int rBound)
        {
            if (lBound >= rBound)
            {
                return;
            }

            var p = Partition(array, lBound, rBound);

            SortImpl(array, lBound, p);
            SortImpl(array, p + 1, rBound);
        }

        private static int Partition(IList<int> array, int lBound, int rBound)
        {
            var pivot = (array[lBound] + array[(lBound + rBound) / 2] + array[rBound]) / 3; // median of three

            var l = lBound - 1;
            var r = rBound + 1;

            while (true)
            {
                do
                {
                    l++;
                }
                while (array[l] < pivot);

                do
                {
                    r--;
                }
                while (array[r] > pivot);

                if (l >= r)
                {
                    return r;
                }

                var buf = array[l];
                array[l] = array[r];
                array[r] = buf;
            }
        }
    }
}