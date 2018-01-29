using System;
using System.Collections.Generic;
using System.Linq;

namespace Kayllian.Algorithms.Graphs
{
    /// <summary>
    /// Determines if a graph contains a cycle.
    /// </summary>
    public class DirectedCycle
    {
        private bool[] _marked;
        private bool[] _onStack;
        private int[] _edgeTo;

        private Stack<int> _cycle = new Stack<int>();

        public DirectedCycle(IGraph graph)
        {
            _marked = new bool[graph.Vertices];
            _onStack = new bool[graph.Vertices];
            _edgeTo = new int[graph.Vertices];

            for (int i = 0; i < graph.Vertices; i++)
            {
                if (_marked[i])
                    continue;

                Search(graph, i);
            }
        }

        /// <summary>
        /// Returns the determination whether or not the provided graph contains a cycle.
        /// </summary>
        public bool HasCycle => _cycle.Any();

        /// <summary>
        /// Returns back a cycle if one exists; otherwise an empty collection is returned.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> Cycle()
        {
            return _cycle;
        }

        private void Search(IGraph graph, int vertex)
        {
            _onStack[vertex] = true;
            _marked[vertex] = true;

            foreach (var neighbor in graph.Adjacent(vertex))
            {
                if (HasCycle)
                    break;

                _edgeTo[neighbor] = vertex;
                if (_onStack[neighbor]) // we have a cycle
                {
                    _cycle = new Stack<int>();
                    
                    for (int i = vertex; i != neighbor; i = _edgeTo[i])
                    {
                        _cycle.Push(i);
                    }

                    _cycle.Push(neighbor);
                    _cycle.Push(vertex);

                }
                else
                    Search(graph, neighbor);
            }

            _onStack[vertex] = false;
        }
    }
}
