using System.Collections.Generic;

namespace Graphs.Weighted
{
    /// <summary>
    /// Class which calculates the minimal spanning tree (MST) of an EdgeWeightedGraph.
    /// </summary>
    public class MinimalSpanningTree
    {
        public MinimalSpanningTree(EdgeWeightedGraph graph)
        {

        }

        /// <summary>
        /// Retrieves the list of edges that comprise the MST.
        /// </summary>
        public IEnumerable<Edge> Edges { get; }

        /// <summary>
        /// Retrieves the total weight for the resulting minimal spanning tree.
        /// </summary>
        public double Weight { get; }
    }
}