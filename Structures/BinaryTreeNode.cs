using System.Collections.Generic;
using CrackingCodingInterview.Structures;

public class BinaryTreeNode<T> : IBreadthFirstSearchable<BinaryTreeNode<T>>
{
    private BinaryTreeNode<T> _left;
    private BinaryTreeNode<T> _right;

    public BinaryTreeNode(T value)
    {
        Value = value;
    }

    public T Value { get; set; }
    public BinaryTreeNode<T> Left 
    { 
        get { return _left; } 
        set 
        { 
            if (value != null)
            {
                value.Parent = this;
            }
            _left = value;
        } 
    }
    public BinaryTreeNode<T> Right 
    { 
        get { return _right; } 
        set 
        {
            if (value != null)
            {
                value.Parent = this;
            }
            _right = value; 
        } 
    }
    public BinaryTreeNode<T> Parent { get; set; }

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