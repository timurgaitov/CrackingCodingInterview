using System;
using System.Linq;

namespace CrackingCodingInterview.Problems
{
    internal static class P_3_1_ThreeInOne
    {
        private class ThreeInOneStack
        {
            private int?[] array = new int?[20];
            private int?[] tops = new int?[3];
            private int nextNeverUsedPos = 0;
            private int? insertTop = null;

            public void Push(int stackIndex, int value)
            {
                var insertPos = nextNeverUsedPos;
                
                if (insertTop != null)
                {
                    insertPos = insertTop.Value;
                    insertTop = array[insertTop.Value + 1];
                }
                else
                {
                    nextNeverUsedPos += 3;
                }

                array[insertPos] = stackIndex;
                array[insertPos + 1] = tops[stackIndex]; // prev index
                array[insertPos + 2] = value;
                
                tops[stackIndex] = insertPos;

                PrintArray();
            }

            public int? Pop(int stackIndex)
            {
                if (tops[stackIndex] == null)
                {
                    return null;
                }

                var topIndex = tops[stackIndex].Value;
                
                tops[stackIndex] = array[topIndex + 1];
                
                array[topIndex + 1] = insertTop;
                insertTop = topIndex;
                
                PrintArray();

                return array[topIndex];
            }

            public void Print(int stackIndex)
            {
                Console.WriteLine($"Stack {stackIndex}");
                
                var pos = tops[stackIndex];

                while (pos.HasValue)
                {
                    Console.WriteLine(array[pos.Value + 2]);
                    pos = array[pos.Value + 1];
                }
            }

            private void PrintArray()
            {
                Console.WriteLine($"[{string.Join(", ", array.Select(v => v?.ToString().PadLeft(2) ?? "  "))}]");
            }
        }
        
        public static void Solve()
        {
            var stack = new ThreeInOneStack();
            
            stack.Push(0, 3);
            stack.Push(1, 2);
            stack.Push(1, 3);
            stack.Push(1, 1);
            stack.Push(2, 4);
            stack.Push(2, 3);
            stack.Pop(0);
            stack.Pop(1);
            stack.Pop(2);
            stack.Push(1, 10);
            stack.Push(0, 10);
            stack.Push(2, 10);
            stack.Print(0);
            stack.Print(1);
            stack.Print(2);
        }
    }
}