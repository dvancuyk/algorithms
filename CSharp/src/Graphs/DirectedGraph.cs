using System;
using System.Collections.Generic;

namespace Kayllian.Algorithms.Graphs
{
    /// <summary>
    /// Represents a directed graph, one where the edges added are directional from vertices, v -> w.
    /// </summary>
    /// <devdoc>
    /// In the book, this was called a Digraph. I just have issues with abbreviations.
    /// </devdoc>
    public class DirectedGraph : IGraph
    {
        private readonly List<int>[] _map;

        public DirectedGraph(int vertices)
        {
            Vertices = vertices;
            _map = new List<int>[vertices];

            for (int i = 0; i < vertices; i++)
            {
                _map[i] = new List<int>();
            }
        }

        public int Vertices { get; }

        public int Edges { get; private set;}

        public void AddEdge(int first, int second)
        {
            _map[first].Add(second);
            Edges++;
        }

        public IEnumerable<int> Adjacent(int vertex)
        {
            return _map[vertex];
        }

        public DirectedGraph Reverse()
        {
            var graph = new DirectedGraph(Vertices);

            for(int current = 0; current < Vertices; current++)
            {
                foreach (var vertex in Adjacent(current))
                {
                    graph.AddEdge(vertex, current);
                }
            }

            return graph;
        }
    }
}
