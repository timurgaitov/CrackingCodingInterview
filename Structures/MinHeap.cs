using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Structures
{
    internal class MinHeap
    {
        private readonly List<int> _minHeap = new List<int>();

        public void Insert(int value)
        {
            _minHeap.Add(value);

            var valueIndex = _minHeap.Count - 1;
            var parentIndex = (valueIndex + 1) / 2 - 1;

            while (parentIndex >= 0)
            {
                if (value < _minHeap[parentIndex])
                {
                    var buf = _minHeap[parentIndex];
                    _minHeap[parentIndex] = _minHeap[valueIndex];
                    _minHeap[valueIndex] = buf;

                    valueIndex = parentIndex;
                    parentIndex = (valueIndex + 1) / 2 - 1;
                }
                else
                {
                    break;
                }
            }
        }

        public int ExtractMin()
        {
            var min = _minHeap[0];

            _minHeap[0] = _minHeap[^1];
            
            _minHeap.RemoveAt(_minHeap.Count - 1);

            var valueIndex = 0;
            var leftIndex = 2 * (valueIndex + 1) - 1;
            var rightIndex = 2 * (valueIndex + 1);

            var swapWithIndex = _minHeap[leftIndex] <= _minHeap[rightIndex] ? leftIndex : rightIndex;

            while (_minHeap[valueIndex] > _minHeap[swapWithIndex])
            {
                var buf = _minHeap[valueIndex];
                _minHeap[valueIndex] = _minHeap[swapWithIndex];
                _minHeap[swapWithIndex] = buf;

                valueIndex = swapWithIndex;
                leftIndex = 2 * (valueIndex + 1) - 1;
                rightIndex = 2 * (valueIndex + 1);

                if (leftIndex >= _minHeap.Count)
                {
                    break;
                }
                else if (rightIndex >= _minHeap.Count)
                {
                    swapWithIndex = leftIndex;
                }
                else
                {
                    swapWithIndex = _minHeap[leftIndex] <= _minHeap[rightIndex] ? leftIndex : rightIndex;
                }
            }
            
            return min;
        }

        public void Print()
        {
            var nextLevelI = 0;
            var level = 0;
            
            for (var i = 0; i < _minHeap.Count; i++)
            {
                if (i >= nextLevelI)
                {
                    Console.WriteLine();
                    nextLevelI = (2 << level) - 1;
                    level++;
                }
                
                Console.Write($" {_minHeap[i]} ");
            }

            Console.WriteLine();
        }
    }
}