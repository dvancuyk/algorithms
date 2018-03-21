using System.Collections.Generic;

namespace Graphs.Weighted
{
    public class EdgeWeightedGraph
    {
        private List<Edge>[] _adjacents;

        public EdgeWeightedGraph(int verticesCount)
        {
            VerticesCount = verticesCount;
            EdgesCount = 0;
            _adjacents = new List<Edge>[verticesCount];

            for(var i = 0; i < verticesCount; i++) 
            {
                _adjacents[i] = new List<Edge>();
            }
        }

        public int VerticesCount { get; }

        public int EdgesCount { get; private set; }

        public IEnumerable<Edge> Edges 
        {
            get
            {
                var edges = new List<Edge>();
                for(int v = 0; v < VerticesCount; v++) {
                    foreach(var edge in _adjacents[v]) {
                        if(edge.Other(v) > v)
                            edges.Add(edge);
                    }
                }

                return edges;
            }
        }

        public void AddEdge(Edge edge)
        {
            var vertex = edge.Either();
            _adjacents[vertex].Add(edge);
            _adjacents[edge.Other(vertex)].Add(edge);
            EdgesCount++;
        }

        public IEnumerable<Edge> Adjacent(int vertex)
        {
            return _adjacents[vertex];
        }
    }
}
