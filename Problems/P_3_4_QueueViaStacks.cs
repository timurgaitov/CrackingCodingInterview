using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.Problems
{
    public static class P_3_4_QueueViaStacks
    {
        private class Queue
        {
            private readonly Stack<int> stack1 = new Stack<int>();
            private readonly Stack<int> stack2 = new Stack<int>();

            public int Count => stack1.Count + stack2.Count;
            
            public void Enqueue(int value)
            {
                stack1.Push(value);
            }

            public int Dequeue()
            {
                if (stack1.Count == 0)
                {
                    throw new InvalidOperationException("Queue is empty");
                }
                
                while (stack1.Count > 1)
                {
                    stack2.Push(stack1.Pop());
                }

                var dequeued = stack1.Pop();

                while (stack2.Count > 0)
                {
                    stack1.Push(stack2.Pop());
                }

                return dequeued;
            }
        }
        
        public static void Solve()
        {
            var queue = new Queue();
            
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Dequeue();
            queue.Enqueue(2);
            queue.Enqueue(3);

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}