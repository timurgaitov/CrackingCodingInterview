using CrackingCodingInterview.Structures;

namespace CrackingCodingInterview.Solutions
{
    internal static class P_2_5_SumLists_2
    {
        public static void Solve()
        {
            var head1 = SinglyLinkedListNode<int>.CreateSinglyLinkedList(1, 0);
            var head2 = SinglyLinkedListNode<int>.CreateSinglyLinkedList(1, 0, 0, 0);
            SinglyLinkedListNode<int> sumHead = null;

            var lengthDiff = GetLengthDiff(head1, head2);

            if (lengthDiff < 0)
            {
                for (var i = 0; i < -lengthDiff; i++)
                {
                    var newHead1 = new SinglyLinkedListNode<int>(0)
                    {
                        Next = head1
                    };
                    head1 = newHead1;
                }
            }
            else if (lengthDiff > 0)
            {
                for (var i = 0; i < lengthDiff; i++)
                {
                    var newHead2 = new SinglyLinkedListNode<int>(0)
                    {
                        Next = head2
                    };
                    head2 = newHead2;
                }
            }

            Sum(head1, head2, ref sumHead);
            
            sumHead.Print();
        }

        private static int Sum(SinglyLinkedListNode<int> node1, SinglyLinkedListNode<int> node2, ref SinglyLinkedListNode<int> sumHead)
        {
            var overSum = 0;
            
            if (node1.Next != null)
            {
                overSum = Sum(node1.Next, node2.Next, ref sumHead);
            }
            
            var sum = node1.Value + node2.Value + overSum;

            if (sum > 9)
            {
                var newSumHead = new SinglyLinkedListNode<int>(0)
                {
                    Next = sumHead,
                    Value = 0,
                };
                sumHead = newSumHead;
                return sum - 10;
            }
            else
            {
                var newSumHead = new SinglyLinkedListNode<int>(0)
                {
                    Next = sumHead,
                    Value = sum,
                };
                sumHead = newSumHead;
                return 0;
            }
        }

        private static int GetLengthDiff(SinglyLinkedListNode<int> node1, SinglyLinkedListNode<int> node2)
        {
            while (node1 != null && node2 != null)
            {
                node1 = node1.Next;
                node2 = node2.Next;
            }
            
            if (node1 == null && node2 != null)
            {
                return GetLengthDiff(null, node2.Next) - 1;
            }

            if (node1 != null)
            {
                return GetLengthDiff(node1.Next, null) + 1;
            }

            return 0;
        }
    }
}