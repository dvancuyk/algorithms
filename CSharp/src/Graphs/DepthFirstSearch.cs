namespace Kayllian.Algorithms.Graphs
{
    /// <summary>
    /// A basic implementation of the depth first search algorithm using a <see cref="Graph"/>
    /// </summary>
    public class DepthFirstSearch
    {
        private readonly IGraph _graph;
        private readonly bool[] _marked;

        /// <summary>
        /// Instantiates a new instance of <see cref="DepthFirstSearch"/>
        /// </summary>
        /// <param name="graph">The graph</param>
        /// <param name="vertex">The initial vertex where the search starts</param>
        public DepthFirstSearch(IGraph graph, int vertex)
        {
            _graph = graph;
            _marked = new bool[graph.Vertices];
            Search(vertex);
        }

        public int Count { get; private set; }

        /// <summary>
        /// Indicates whether or not the provided vertex is connected to the original vertex in the graph.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool Marked(int vertex)
        {
            return _marked[vertex];
        }

        private void Search(int vertex)
        {
            _marked[vertex] = true;

            foreach (var neighbor in _graph.Adjacent(vertex))
            {
                if (!_marked[neighbor])
                {
                    Search(neighbor);
                    Count++;
                }
            }
        }
    }
}
