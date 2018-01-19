using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kayllian.Algorithms.Graphs
{
    public class BreadthFirstSearch
    {
        private int origin;
        private int[] edgeTo;
        private bool[] marked;

        public BreadthFirstSearch(Graph graph, int origin)
        {
            this.origin = origin;
            edgeTo = new int[graph.Vertices];
            marked = new bool[graph.Vertices];

            Search(graph);
        }

        /// <summary>
        /// Returns the path to the provided destination if it exists.
        /// </summary>
        /// <param name="destination"></param>
        /// <returns>A collection of integers which represents the path from the origin to the provided destination if it exists; otherwise null is returned</returns>
        public IEnumerable<int> PathTo(int destination)
        {
            var path = new Stack<int>();

            if(HasPathTo(destination))
            {
                for(int current = destination; current != origin; current = edgeTo[current])
                {
                    path.Push(current);
                }

                path.Push(origin);
            }

            return path;
        }

        public bool HasPathTo(int destination)
        {
            return marked[destination];
        }

        private void Search(Graph graph)
        {
            var queue = new Queue<int>();
            marked[origin] = true;

            queue.Enqueue(origin);

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                
                foreach (var vertex in graph.Adjacent(current).Where(v => !marked[v]))
                {
                    marked[vertex] = true;
                    edgeTo[vertex] = current;
                    queue.Enqueue(vertex);
                }
            }
            
        }
    }
}
