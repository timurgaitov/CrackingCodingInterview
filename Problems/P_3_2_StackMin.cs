using System;

namespace CrackingCodingInterview.Solutions
{
    internal static class P_3_2_StackMin
    {
        private class StackMinNode
        {
            public StackMinNode Next { get; set; }
            public StackMinNode Min { get; set; }
            public int Value { get; set; }
        }
        
        private class StackMin
        {
            private StackMinNode top;

            public void Push(int value)
            {
                var newTop = new StackMinNode
                {
                    Next = top,
                    Value = value,
                };
                
                newTop.Min = top == null || value < top.Min.Value ? newTop : top.Min;
                
                top = newTop;

                Console.WriteLine(Min());
            }

            public int? Pop()
            {
                var top = this.top;
                
                this.top = this.top?.Next;
                
                Console.WriteLine(Min());

                return top?.Value;
            }

            public int? Min()
            {
                return top?.Min.Value;
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