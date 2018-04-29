using System.Collections.Generic;
using System.Linq;
using Sorting.PriorityQueue;

namespace Graphs.Weighted
{
    /// <summary>
    /// Class which calculates the minimal spanning tree (MST) of an EdgeWeightedGraph using an lazy implementation of
    /// the Prim algorithm.
    /// </summary>
    public class LazyPrimMst
    {
        private readonly bool[] _visited;
        private readonly Queue<Edge> _edges;

        public LazyPrimMst(EdgeWeightedGraph graph)
        {
            _visited = new bool[graph.VerticesCount];
            _edges = new Queue<Edge>(graph.VerticesCount - 1);

            var pq = new MinPriorityQueue<Edge>();
            Visit(0, graph, pq);

            while (!pq.IsEmpty)
            {
                var edge = pq.DeleteMax();
                int v = edge.Either(),
                    w = edge.Other(v);

                if (_visited[v] && _visited[w])
                    continue;

                _edges.Enqueue(edge);

                if(!_visited[v])
                    Visit(v, graph, pq);
                if (!_visited[w])
                    Visit(w, graph, pq);
            }
        }

        /// <summary>
        /// Retrieves the list of edges that comprise the MST.
        /// </summary>
        public IEnumerable<Edge> Edges => _edges;

        /// <summary>
        /// Retrieves the total weight for the resulting minimal spanning tree.
        /// </summary>
        public double Weight => _edges.Sum(e => e.Weight);

        private void Visit(int v, EdgeWeightedGraph graph, MinPriorityQueue<Edge> pq)
        {
            _visited[v] = true;
            foreach (var edges in graph.Adjacent(v))
            {
                pq.Insert(edges);
            }
        }
    }
}