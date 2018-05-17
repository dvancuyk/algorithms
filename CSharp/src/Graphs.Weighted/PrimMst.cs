using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using Sorting.PriorityQueue;

namespace Graphs.Weighted
{
    /// <summary>
    /// Calculates the minimal spanning tree of a graph using an eager implementation of Prim's MST algorithm.
    /// </summary>
    public class PrimMst
    {
        private readonly double[] _distanceTo;
        private readonly Edge[] _edgeTo;

        public PrimMst(EdgeWeightedGraph graph)
        {
            throw new System.NotImplementedException();
            _distanceTo = new double[graph.VerticesCount];
            _edgeTo= new Edge[graph.VerticesCount - 1];

            for (int i = 0; i < graph.VerticesCount; i++)
            {
                _distanceTo[i] = double.PositiveInfinity;
            }

            _distanceTo[0] = 0.0;
            var pq = new MinPriorityQueue<double>();
            //pq.Insert(0, _distanceTo[0]);
            Visit(0, graph, pq);
        }

        /// <summary>
        /// Retrieves the list of edges that comprise the MST.
        /// </summary>
        public IEnumerable<Edge> Edges => _edgeTo;

        /// <summary>
        /// Retrieves the total weight for the resulting minimal spanning tree.
        /// </summary>
        public double Weight => _edgeTo.Sum(e => e.Weight);

        private void Visit(int v, EdgeWeightedGraph graph, MinPriorityQueue<double> pq)
        {
            throw new System.NotImplementedException();
            //foreach (var edges in graph.Adjacent(v))
            //{
            //    pq.Insert(edges);
            //}
        }
    }
}
