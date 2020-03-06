using CrackingCodingInterview.Structures;
using CrackingCodingInterview.Algorithms;

namespace CrackingCodingInterview
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var node0 = new GraphNode<int>(0);
            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);
            var node3 = new GraphNode<int>(3);
            var node4 = new GraphNode<int>(4);
            var node5 = new GraphNode<int>(5);
            var node6 = new GraphNode<int>(6);
            var node7 = new GraphNode<int>(7);

            node0.AdjacentNodes.Add(node2);
            node1.AdjacentNodes.Add(node3);
            node2.AdjacentNodes.Add(node0);
            node2.AdjacentNodes.Add(node1);
            node2.AdjacentNodes.Add(node4);
            node3.AdjacentNodes.Add(node1);
            node3.AdjacentNodes.Add(node5);
            node4.AdjacentNodes.Add(node2);
            node4.AdjacentNodes.Add(node6);
            node4.AdjacentNodes.Add(node7);
            node5.AdjacentNodes.Add(node3);
            node5.AdjacentNodes.Add(node6);
            node5.AdjacentNodes.Add(node7);
            node6.AdjacentNodes.Add(node2);
            node6.AdjacentNodes.Add(node4);
            node7.AdjacentNodes.Add(node6);

            BreadthFirstSearch.Search(new[] { node0, node1, node2, node3, node4, node5, node6, node7 });
        }
    }
}
