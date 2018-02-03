using Commons;
using System;

namespace Kayllian.Algorithms.Graphs
{
    public class StronglyConnectedComponents
    {
        private readonly bool[] _marked;
        private readonly int[] _componentMap; // Tracks which component the given vertice is at.

        public StronglyConnectedComponents(DirectedGraph graph)
        {
            var search = new DepthFirstOrder(graph.Reverse());
            var sort = search.ReversePost;

            _marked = new bool[graph.Vertices];
            _componentMap = new int[graph.Vertices];

            foreach (var vertex in sort)
            {
                if (_marked[vertex])
                    continue;

                _componentMap[vertex] = ++Count;
                Search(graph, vertex);
            }
        }

        private void Search(IGraph graph, int vertex)
        {
            _marked[vertex] = true;

            foreach (var w in graph.Adjacent(vertex))
            {
                if(!_marked[w])
                {
                    DomainEvents.Raise(new EdgeTraversed(vertex, w, "StronglyConnectedComponents"));

                    _componentMap[w] = Count;
                    Search(graph, w);
                }
            }
        }

        /// <summary>
        /// Gets the number of unique connected components in the graph.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Returns back the unique id of the connected component that the vertex is a part of.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public int Id(int vertex)
        {
            return _componentMap[vertex];
        }

        /// <summary>
        /// Determines if the two vertices (v and w) are strongly connected.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool StronglyConnected(int v, int w)
        {
            return Id(v) == Id(w);
        }        

    }
}
