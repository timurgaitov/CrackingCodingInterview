using System;
using System.Collections.Generic;
using CrackingCodingInterview.Helpers;

namespace CrackingCodingInterview.Debug
{
    internal static class PrintBinaryTree
    {
        public static void Print<T>(this BinaryTreeNode<T> root)
        {
            const int valueStringMaxLength = 2;

            var queue = new Queue<BinaryTreeNode<T>>();

            queue.Enqueue(root);

            var count = 1;
            var lines = new List<List<string>>();
            var buf = new List<string>();

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }

                buf.Add(node.Value.ToString().PadLeft(valueStringMaxLength));

                count++;

                if (count.IsPowerOfTwo())
                {
                    lines.Add(buf);
                    buf = new List<string>();
                }
            }

            for (var i = 0; i < lines.Count; i++)
            {
                for (var j = 0; j < lines[i].Count; j++)
                {
                    Console.Write(lines[i][j].PadRight(2 * valueStringMaxLength, j % 2 == 0 && i != 0 ? '_' : ' '));
                }
                Console.WriteLine();
            }
        }
    }
}