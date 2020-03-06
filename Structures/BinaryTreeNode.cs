using System.Collections.Generic;
using CrackingCodingInterview.Structures;

public class BinaryTreeNode<T> : IBreadthFirstSearchable<BinaryTreeNode<T>>
{
    public BinaryTreeNode(T value)
    {
        Value = value;
    }

    public T Value { get; set; }

    public BinaryTreeNode<T> Left { get; set; }
    public BinaryTreeNode<T> Right { get; set; }

    public IEnumerable<BinaryTreeNode<T>> AdjacentNodes { 
        get 
        {
            if (Left != null)
            {
                yield return Left;
            }

            if (Right != null)
            {
                yield return Right;
            }
        } 
    }
}