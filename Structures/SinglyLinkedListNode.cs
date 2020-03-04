using System;

namespace CrackingCodingInterview.Structures
{
    internal class SinglyLinkedListNode<T>
    {
        public static SinglyLinkedListNode<T> CreateSinglyLinkedList<T>(params T[] values)
        {
            if (values.Length == 0)
            {
                return null;
            }
            
            var head = new SinglyLinkedListNode<T>(values[0]);
            var node = head;

            for (var i = 1; i < values.Length; i++)
            {
                node.Next = new SinglyLinkedListNode<T>(values[i]);
                node = node.Next;
            }

            return head;
        }
        
        public SinglyLinkedListNode(T value)
        {
            Value = value;
        }

        public SinglyLinkedListNode<T> Next { get; set; }
        public T Value { get; set; }

        public void Print()
        {
            var node = this;

            while (node != null)
            {
                Console.Write($"{node.Value} → ");
                node = node.Next;
            }

            Console.WriteLine("null");
        }
    }
}