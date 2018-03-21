using System;
using System.Collections.Generic;
using System.Text;

namespace Kayllian.Algorithms.Graphs
{
    /// <summary>
    /// A simple graph which uses in array index nomenclature for the represented vertices.
    /// </summary>
    /// <remarks>
    /// This instance uses an array index style naming convention such that the first vertex is 0 and the last is 
    /// N - 1.
    /// 
    /// </remarks>
    public class Graph : IGraph
    {
        private readonly List<int>[] _vertices;

        public Graph(int vertices)
        {
            this._vertices = new List<int>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                _vertices[i] = new List<int>();
            }
        }
        

        /// <summary>
        /// Gets the number of vertices that are in the graph.
        /// </summary>
        public int Vertices => _vertices.Length;

        /// <summary>
        /// Gets the number of edges that are 
        /// </summary>
        public int Edges { get; private set; }

        /// <summary>
        /// Adds an edges between the first and second vertices.
        /// </summary>
        /// <param name="first">The first vertice being connected</param>
        /// <param name="second">The second vertice being added</param>
        public void AddEdge(int first, int second)
        {
            ValidateVertex(first);
            ValidateVertex(second);

            _vertices[first].Add(second);
            _vertices[second].Add(first);

            Edges++;
        }

        private void ValidateVertex(int value)
        {
            var isValid = value >= 0 && value < Vertices;
            if(!isValid)
                throw new ArgumentException($"The value '{value}' must be between 0 and {Vertices}");
        }

        /// <summary>
        /// Returns the vertices which are immediate adjacent to the provide vertex.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> Adjacent(int vertex)
        {
            ValidateVertex(vertex);

            return _vertices[vertex];
        }


        public override string ToString()
        {
            var value = new StringBuilder(Vertices + " vertices, " + Edges + " edges" + Environment.NewLine);
            for (var current = 0; current < Vertices; current++)
            {
                value.Append(current + ":");
                foreach (var w in Adjacent(current))
                {
                    value.Append(" " + w);
                }

                value.AppendLine();
            }

            return value.ToString();
        }
    }
}
