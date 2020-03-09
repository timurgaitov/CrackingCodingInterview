using System;
using System.Collections.Generic;
using CrackingCodingInterview.Structures;

namespace CrackingCodingInterview.Algorithms
{
    public static class HeapSort
    {
        public static void Sort(int[] array)
        {
            for (var i = array.Length / 2 - 1; i >= 0; i--) 
            {
                MaxHeapify(array, array.Length, i);
            }

            for (var i = array.Length - 1; i >= 0; i--) 
            { 
                int buf = array[0]; 
                array[0] = array[i]; 
                array[i] = buf; 
    
                MaxHeapify(array, i, 0); 
            }
        }

        private static void MaxHeapify(int[] array, int heapSize, int i)
        {
            var largest = i;
            var l = 2 * i + 1;
            var r = 2 * i + 2;

            if (l < heapSize && array[l] > array[largest])
            {
                largest = l;
            }

            if (r < heapSize && array[r] > array[largest])
            {
                largest = r;
            }

            if (largest != i) 
            { 
                var buf = array[i]; 
                array[i] = array[largest]; 
                array[largest] = buf; 
    
                MaxHeapify(array, heapSize, largest); 
            } 
        }
    }
}