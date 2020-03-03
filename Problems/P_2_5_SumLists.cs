using CrackingCodingInterview.Structures;

namespace CrackingCodingInterview.Problems
{
    public static class P_2_5_SumLists
    {
        public static void Solve()
        {
            var head1 = SinglyLinkedListNode<int>.CreateSinglyLinkedList(7, 1, 6);
            var head2 = SinglyLinkedListNode<int>.CreateSinglyLinkedList(5, 9, 2);
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
            
            sumHead.Print();
        }
    }
}