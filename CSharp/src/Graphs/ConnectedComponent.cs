using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kayllian.Algorithms.Graphs
{
    /// <summary>
    /// Algorithm which determines if two vertices are connected to each other on a given graph.
    /// </summary>
    /// <devdoc>
    /// 
    /// </devdoc>
    public class ConnectedComponent
    {
        private readonly Graph _graph;
        private readonly int[] _ids;
        private readonly bool[] _marked;

        public ConnectedComponent(Graph graph)
        {
            _graph = graph;
            _ids = new int[graph.Vertices];
            _marked = new bool[graph.Vertices];

            for(var id = 0; id < _ids.Length; id++)
            {
                if (_ids[id] != 0)
                    continue;

                Count++;
                Search(id);
            }
        }

        /// <summary>
        /// Gets the number of connected components in a graph. 
        /// </summary>
        /// <devdoc>
        /// A connected component is a set of vertices connected with edges in a graph. A graph with a single connected component
        /// means that you can traverse from one point to every other point in the graph. If multiple connected components
        /// exist on a graph, there will be areas where you cannot traverse from one point to another. 
        /// </devdoc>
        public int Count { get; } = 0;

        /// <summary>
        /// Gets the internal id of the connected component that the provided vertex can be found in.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        /// <devdoc>
        /// According to the documentation on page 543, this is for client use in indexing an array by component.
        /// </devdoc>
        public int Id(int vertex)
        {
            return _ids[vertex];
        }

        /// <summary>
        /// Determines if the two vertices {v, w} are connected in the graph.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool IsConnected(int v, int w)
        {
            return _ids[v] == _ids[w];
        }

        private void Search(int vertex)
        {
            _marked[vertex] = true;
            _ids[vertex] = Count;

            foreach (var neighbor in _graph.Adjacent(vertex))
            {
                if (!_marked[neighbor])
                {
                    Search(neighbor);
                }
            }
        }
    }
}
