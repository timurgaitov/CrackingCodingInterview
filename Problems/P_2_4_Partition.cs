using System;
using CrackingCodingInterview.Structures;

namespace CrackingCodingInterview.Problems
{
    internal class P_2_4_Partition
    {
        public static void Solve()
        {
            var head = SinglyLinkedListNode<int>.CreateSinglyLinkedList(3, 5, 8, 5, 10, 2, 1);

            const int partition = 5;

            var node = head;
            SinglyLinkedListNode<int> prev = null;
            SinglyLinkedListNode<int> lastLeft = null;
            SinglyLinkedListNode<int> firstRight = null;

            while (node != null)
            {
                if (node.Value >= partition)
                {
                    if (firstRight == null)
                    {
                        firstRight = node;
                    }

                    prev = node;
                    node = node.Next;
                }
                else
                {
                    if (firstRight == null)
                    {
                        lastLeft = node;
                        prev = node;
                        node = node.Next;
                    }
                    else if (lastLeft != null)
                    {
                        prev.Next = node.Next;
                        node.Next = lastLeft.Next;
                        lastLeft.Next = node;
                        lastLeft = node;
                        node = prev.Next;
                    }
                    else
                    {
                        prev.Next = node.Next;
                        node.Next = firstRight;
                        lastLeft = node;
                        head = lastLeft;
                        node = prev.Next;
                    }
                }
            }

            node = head;

            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}