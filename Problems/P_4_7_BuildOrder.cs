using System;
using System.Collections.Generic;
using System.Linq;
using CrackingCodingInterview.Algorithms;
using CrackingCodingInterview.Debug;
using CrackingCodingInterview.Structures;
using CrackingCodingInterview.Helpers;
using BTN = BinaryTreeNode<int>;

namespace CrackingCodingInterview.Problems
{
    internal static class P_4_7_BuildOrder
    {
        private class Dep 
        {
            public Dep(char project, char isDependentOn)
            {
                Project = project;
                IsDependentOn = isDependentOn;
            }

            public char Project { get; }
            public char IsDependentOn { get; }
        }

        public static void Solve()
        {
            const char a = 'a', b = 'b', c = 'c', d = 'd', e = 'e', f = 'f';

            var projects = new[] { a, b, c, d, e, f };
            var deps = new[] { new Dep(d, a), new Dep(b, f), new Dep(d, b), new Dep(a, f), new Dep(c, d) };
            var expected = new[] { f, e, a, b, d, c };

            var nodes = new Dictionary<char, GraphNode<char>>();
            var hasDeps = new Dictionary<char, bool>();

            foreach (var project in projects)
            {
                nodes.Add(project, new GraphNode<char>(project));
            }

            foreach (var dep in deps)
            {
                nodes[dep.IsDependentOn].AddAdjacentNodes(nodes[dep.Project]);
                
                hasDeps[dep.Project] = true;
            }

            var projectsWithNoDeps = nodes.Values.Where(n => !hasDeps.ContainsKey(n.Value) || !hasDeps[n.Value]).ToList();

            var bfs = BreadthFirstSearch.Search(projectsWithNoDeps);

            Console.WriteLine(string.Join(", ", bfs.Select(n => n.Value)));
        }
    }
}