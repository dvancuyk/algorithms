using System;
using System.Collections.Generic;
using System.Text;

namespace Kayllian.Algorithms.Graphs
{
    /// <summary>
    /// Determines if a give graph contains a cycle or is acyclic.
    /// </summary>
    public class Cycle
    {
        private readonly Graph _graph;
        private readonly bool[] _marked;

        public Cycle(Graph graph)
        {
            _graph = graph;
            _marked = new bool[graph.Vertices];

            for (int current = 0; current < graph.Edges; current++)
            {
                Search(graph, current, current);
            }
        }

        public bool HasCycle { get; private set; }

        /// <summary>
        /// Searches the graph to determine if there are any cycles
        /// </summary>
        /// <param name="graph">The graph to be searched.</param>
        /// <param name="v"></param>
        /// <param name="origin">This is the previous vertex in the chain</param>
        /// <devdoc>
        /// The primary difference between this and the normal DFS, is that when we hit a marked value, we update our HasCycle 
        /// property to indicate we have a cycle. B/c a marked node is now important, we track the origin (u in the books) so that 
        /// when we search the neighbors, we don't accidentally mark it as a cycle when we look at the origin.
        /// 
        /// For example, given the path u-v, we would call Search(graph, v, u). The call to graph.Adjacent(v) would return u as
        /// a neighbor (undirected graph so we keep track from both directions) and this is not a cycle b/c it is the same edge we 
        /// just discovered (no parallel edges).
        /// </devdoc>
        private void Search(Graph graph, int v, int origin)
        {
            _marked[v] = true;
            foreach (var neighbor in graph.Adjacent(v))
            {
                if(!_marked[neighbor])
                    Search(graph, neighbor, v);
                else if (neighbor != origin)
                    HasCycle = true;
            }
        }
    }
}
