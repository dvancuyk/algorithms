using System.Collections.Generic;

namespace Kayllian.Algorithms.Graphs
{
    /// <summary>
    /// This is an algorithm that searchs for 
    /// </summary>
    public class DepthFirstPaths
    {
        private readonly Graph _graph;
        private readonly int _origin;
        private readonly bool[] _marked;
        private int[] _edgeTo;

        /// <summary>
        /// Instantiates a new instance of <see cref="DepthFirstSearch"/>
        /// </summary>
        /// <param name="graph">The graph</param>
        /// <param name="vertex">The initial vertex where the search starts</param>
        public DepthFirstPaths(Graph graph, int vertex)
        {
            _graph = graph;
            _origin = vertex;
            _marked = new bool[graph.Vertices];
            _edgeTo = new int[graph.Vertices];

            Search(vertex);
        }

        public int Count { get; private set; }

        /// <summary>
        /// Indicates whether this original vertex has a path to the provided vertex.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool HasPathTo(int vertex)
        {
            return _marked[vertex];
        }

        public IEnumerable<int> PathTo(int vertex)
        {
            if (!HasPathTo(vertex))
                return null;

            var stack = new Stack<int>();

            for(int x = vertex; x != _origin; x = _edgeTo[x])
            {
                stack.Push(x);
            }

            stack.Push(_origin);

            return stack;
        }

        private void Search(int vertex)
        {
            _marked[vertex] = true;

            foreach (var neighbor in _graph.Adjacent(vertex))
            {
                if (!_marked[neighbor])
                {
                    _edgeTo[neighbor] = vertex;
                    Search(neighbor);
                    Count++;
                }
            }
        }
        
    }
}
