using System;

namespace Graphs.Weighted
{
    public class Edge : IComparable<Edge>
    {
        private readonly int v;
        private readonly int w;

        public Edge(int v, int w, double weight)
        {
            this.v = v;
            this.w = w;
            Weight = weight;
        }

        public double Weight { get; }

        /// <summary>
        /// Returns any one of the vertices on the end of this edge.
        /// </summary>
        /// <returns></returns>
        public int Either()
        {
            return v;
        }

        /// <summary>
        /// Returns back the vertex that on this edge opposite of the provided vertex parameter.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when the provided vertex is not on this edge.</exception>
        public int Other(int vertex)
        {
            if (vertex == v) return w;
            if (vertex == w) return v;

            throw new ArgumentException("Inconsistent edge");
        }

        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }
}
