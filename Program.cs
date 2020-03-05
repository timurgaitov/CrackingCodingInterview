using CrackingCodingInterview.Solutions;
using CrackingCodingInterview.Structures;

namespace CrackingCodingInterview
{
    public static class Program
    {
        public static void Main(string[] args)
        {
             var minHeap = new MinHeap();
             
             minHeap.Insert(9);
             minHeap.Print();
             minHeap.Insert(7);
             minHeap.Print();
             minHeap.Insert(4);
             minHeap.Print();
             minHeap.Insert(1);
             minHeap.Print();
             minHeap.Insert(18);
             minHeap.Print();
             minHeap.Insert(11);
             minHeap.Print();
             minHeap.Insert(0);
             minHeap.Print();
             minHeap.ExtractMin();
             minHeap.Print();
        }
    }
}
