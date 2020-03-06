using System.Collections.Generic;

public interface IBreadthFirstSearchable<T> where T : IBreadthFirstSearchable<T>
{
    IEnumerable<T> AdjacentNodes { get; }
}