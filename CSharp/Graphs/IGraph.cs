using System.Collections.Generic;

namespace Kayllian.Algorithms.Graphs
{
    public interface IGraph
    {
        /// <summary>
        /// Gets the number of vertices that are in the graph.
        /// </summary>
        int Vertices { get; }

        /// <summary>
        /// Gets the number of edges that are 
        /// </summary>
        int Edges { get; }

        /// <summary>
        /// Adds an edges between the first and second vertices.
        /// </summary>
        /// <param name="first">The first vertice being connected</param>
        /// <param name="second">The second vertice being added</param>
        void AddEdge(int first, int second);

        /// <summary>
        /// Returns the vertices which are immediate adjacent to the provide vertex.
        /// </summary>
        /// <returns></returns>
        IEnumerable<int> Adjacent(int vertex);
    }
}