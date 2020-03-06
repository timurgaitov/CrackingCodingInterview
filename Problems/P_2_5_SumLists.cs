using CrackingCodingInterview.Structures;

namespace CrackingCodingInterview.Problems
{
    internal static class P_2_5_SumLists
    {
        public static void Solve()
        {
            var head1 = SinglyLinkedListNode<int>.CreateSinglyLinkedList(9, 7, 8);
            var head2 = SinglyLinkedListNode<int>.CreateSinglyLinkedList(6, 8, 5);
            SinglyLinkedListNode<int> sumHead = null;
            SinglyLinkedListNode<int> sumNode = null;

            var node1 = head1;
            var node2 = head2;

            var overS = 0;
            
            while (node1 != null || node2 != null)
            {
                var s = overS;

                if (node1 != null)
                {
                    s += node1.Value;
                }

                if (node2 != null)
                {
                    s += node2.Value;
                }
                
                if (s > 9)
                {
                    overS = 1;
                    s -= 10;
                }

                if (sumHead == null)
                {
                    sumHead = new SinglyLinkedListNode<int>(s);
                    sumNode = sumHead;
                }
                else
                {
                    sumNode.Next = new SinglyLinkedListNode<int>(s);
                    sumNode = sumNode.Next;
                }

                node1 = node1?.Next;
                node2 = node2?.Next;
            }

            if (overS > 0)
            {
                sumNode.Next = new SinglyLinkedListNode<int>(overS);
            }
            
            sumHead.Print();
        }
    }
}