using System;
using CrackingCodingInterview.Structures;

namespace CrackingCodingInterview.Problems
{
    public static class P_3_2_StackMin
    {
        private class StackMinNode
        {
            public StackMinNode Next { get; set; }
            public StackMinNode Min { get; set; }
            public int Value { get; set; }
        }
        
        private class StackMin
        {
            private StackMinNode _top;

            public void Push(int value)
            {
                var newTop = new StackMinNode
                {
                    Next = _top,
                    Value = value,
                };
                
                newTop.Min = _top == null || value < _top.Min.Value ? newTop : _top.Min;
                
                _top = newTop;

                Console.WriteLine(Min());
            }

            public int? Pop()
            {
                var top = _top;
                
                _top = _top?.Next;
                
                Console.WriteLine(Min());

                return top?.Value;
            }

            public int? Min()
            {
                return _top?.Min.Value;
            }
        }
        
        public static void Solve()
        {
            var stackMin = new StackMin();
            
            stackMin.Push(4);
            stackMin.Push(3);
            stackMin.Push(2);
            stackMin.Push(1);
            stackMin.Push(2);
            stackMin.Push(3);
            stackMin.Pop();
            stackMin.Pop();
            stackMin.Pop();
            stackMin.Pop();
            stackMin.Pop();
            stackMin.Pop();
        }
    }
}