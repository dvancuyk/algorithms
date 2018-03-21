namespace Kayllian.Algorithms.Graphs
{
    /// <summary>
    /// Determines if a graph is bipartite.
    /// </summary>
    public class TwoColor
    {
        private readonly bool[] _colors;
        private readonly bool[] _marked;

        public TwoColor(Graph graph)
        {
            IsBipartite = true;
            _colors = new bool[graph.Vertices];
            _marked = new bool[graph.Vertices];

            for (int i = 0; i < graph.Vertices; i++)
            {
                if (!_marked[i])
                {
                    Scan(graph, i);
                }
            }
        }

        public bool IsBipartite { get; private set; }

        private void Scan(Graph graph, int vertex)
        {
            _marked[vertex] = true;

            foreach (var neighbor in graph.Adjacent(vertex))
            {

                if (!_marked[neighbor])
                {
                    _colors[neighbor] = !_colors[vertex];
                    Scan(graph,  neighbor);
                }
                else if (_colors[neighbor] == _colors[vertex])
                {
                    IsBipartite = false;
                }
            }

        }
    }
}
