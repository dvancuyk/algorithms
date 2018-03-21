using Kayllian.Algorithms.Graphs;

namespace Graphs.Tests
{
    public static class GraphBuilder
    {
        public static Graph Basic()
        {
            var graph = new Graph(13);
            graph.AddEdge(0, 5);
            graph.AddEdge(4, 3);
            graph.AddEdge(0, 1);
            graph.AddEdge(9, 12);
            graph.AddEdge(6, 4);
            graph.AddEdge(5, 4);
            graph.AddEdge(0, 2);
            graph.AddEdge(11, 12);
            graph.AddEdge(9, 10);
            graph.AddEdge(0, 6);
            graph.AddEdge(7, 8);
            graph.AddEdge(9, 11);
            graph.AddEdge(5, 3);

            return graph;
        }

        /// <summary>
        /// Returns a graph that this is bipartite.
        /// </summary>
        /// <returns></returns>
        /// <devdoc>
        /// Bipartite means that the graph can be divided into two subsets where the vertices from one subset only have an edge
        /// to a vertex in the second subset and never to one in it's on subset.
        /// 
        /// The BiPartite.PNG file depicts what this model should look like.
        /// </devdoc>
        public static Graph Bipartite()
        {
            var graph = new Graph(13);

            graph.AddEdge(0, 5);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 6);
            graph.AddEdge(1, 3);
            graph.AddEdge(5, 3);
            graph.AddEdge(5, 4);
            graph.AddEdge(6, 4);
            graph.AddEdge(6, 7);
            graph.AddEdge(7, 8);
            graph.AddEdge(8, 10);
            graph.AddEdge(9, 10);
            graph.AddEdge(9, 11);
            graph.AddEdge(10, 12);
            graph.AddEdge(11, 12);
            
            
            return graph;
        }

        public static Graph Acyclic()
        {
            var graph = new Graph(8);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 6);
            graph.AddEdge(3, 7);

            return graph;
        }

        public static DirectedGraph DefaultDirected()
        {
            var graph = new DirectedGraph(13);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 5);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 2);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 2);
            graph.AddEdge(4, 3);
            graph.AddEdge(4, 5);
            graph.AddEdge(5, 4);
            graph.AddEdge(6, 0);
            graph.AddEdge(6, 4);
            graph.AddEdge(6, 9);
            graph.AddEdge(7, 6);
            graph.AddEdge(7, 8);
            graph.AddEdge(8, 7);
            graph.AddEdge(8, 9);
            graph.AddEdge(9, 10);
            graph.AddEdge(9, 11);
            graph.AddEdge(10, 12);
            graph.AddEdge(11, 4);
            graph.AddEdge(11, 12);
            graph.AddEdge(12, 9);
            
            return graph;
        }
    }
}
