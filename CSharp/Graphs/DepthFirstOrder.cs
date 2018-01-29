using System;
using System.Collections.Generic;
using System.Text;

namespace Kayllian.Algorithms.Graphs
{
    public class DepthFirstOrder
    {
        private readonly Queue<int> _pre = new Queue<int>();
        private readonly Queue<int> _post = new Queue<int>();
        private readonly Stack<int> _reversePost = new Stack<int>();
        private readonly bool[] _marked;

        public DepthFirstOrder(IGraph graph)
        {
            _marked = new bool[graph.Vertices];

            for(var i = 0; i < graph.Vertices; i++)
            {
                if (_marked[i])
                    continue;

                Search(graph, i);
            }
        }

        private void Search(IGraph graph, int vertex)
        {
            _marked[vertex] = true;
            _pre.Enqueue(vertex);

            foreach (var neighbor in graph.Adjacent(vertex))
            {
                if(!_marked[neighbor])
                    Search(graph, neighbor);
            }

            _post.Enqueue(vertex);
            _reversePost.Push(vertex);
        }

        public IEnumerable<int> Pre => _pre;

        public IEnumerable<int> Post => _post;

        public IEnumerable<int> ReversePost => _reversePost;
    }
}
