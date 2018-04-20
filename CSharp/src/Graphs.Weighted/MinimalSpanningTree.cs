using System.Collections.Generic;
using System.Linq;
using Sorting.PriorityQueue;

namespace Graphs.Weighted
{
    /// <summary>
    /// Class which calculates the minimal spanning tree (MST) of an EdgeWeightedGraph.
    /// </summary>
    public class MinimalSpanningTree
    {
        private readonly bool[] _visited;
        private readonly Edge[] _edges;
        private int _count = 0;

        public MinimalSpanningTree(EdgeWeightedGraph graph)
        {
            _visited = new bool[graph.VerticesCount];
            for (int i = 0; i < graph.VerticesCount; i++)
            {
                _visited[i] = false;
            }

            _edges = new Edge[graph.VerticesCount - 1];

            Search(0, graph, new MinPriorityQueue<Edge>(graph.EdgesCount));
        }

        /// <summary>
        /// Retrieves the list of edges that comprise the MST.
        /// </summary>
        public IEnumerable<Edge> Edges => _edges;

        /// <summary>
        /// Retrieves the total weight for the resulting minimal spanning tree.
        /// </summary>
        public double Weight => _edges.Sum(e => e.Weight);

        private void Search(int v, EdgeWeightedGraph graph, MinPriorityQueue<Edge> pq)
        {
            _visited[v] = true;
            foreach (var edges in graph.Adjacent(v))
            {
                pq.Insert(edges);
            }

            var candidate = pq.DeleteMax();
            var o = candidate.Other(candidate.Either());

            while (_visited[o] && _count < graph.VerticesCount - 1)
            {
                candidate = pq.DeleteMax();
                o = candidate.Other(candidate.Either());
            }

            if (!_visited[o])
            {
                _edges[_count++] = candidate;
                Search(o, graph, pq);
            }
        }
    }
}