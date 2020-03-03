namespace CrackingCodingInterview.Structures
{
    class SinglyLinkedListNode<T>
    {
        public SinglyLinkedListNode(T value)
        {
            Value = value;
        }

        public SinglyLinkedListNode<T> Next { get; set; }
        public T Value { get; set; }

        public SinglyLinkedListNode<T> AddNext(T data)
        {
            Next = new SinglyLinkedListNode<T>(data);
            
            return Next;
        }
    }
}