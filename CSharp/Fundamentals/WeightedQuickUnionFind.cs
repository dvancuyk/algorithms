using System;
using System.ComponentModel.DataAnnotations;

namespace Fundamentals
{
    /// <summary>
    /// An implementation of Quick Union which tracks the weights of each graph and a union merges the smaller of the trees to the larger.
    /// </summary>
    /// <devdoc>
    /// We expect better overall performance from this implementation because 
    /// </devdoc>
    public class WeightedQuickUnionFind : IUnionFind
    {
        private readonly int[] _map;
        private readonly int[] _size;

        /// <summary>
        /// Instantiates a new instance of the <seealso cref="QuickFindUnionFind"/> strategy with the provided "N" number of points.
        /// </summary>
        /// <param name="n"></param>
        public WeightedQuickUnionFind(int n)
        {
            _map = new int[n];
            _size = new int[n];
            for (int i = 0; i < n; i++)
            {
                _map[i] = i;
                _size[i] = 1;
            }

            Count = n;
        }

        public int Count { get; private set; }

        public void Union(int p, int q)
        {
            var pRoot = Find(p);
            var qRoot = Find(q);

            if (pRoot == qRoot)
                return;

            if (_size[pRoot] < _size[qRoot])
            {
                _map[pRoot] = qRoot;
                _size[qRoot] += _size[pRoot];
            }
            else
            {
                _map[qRoot] = pRoot;
                _size[pRoot] += _size[qRoot];
            }
            Count--;
        }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        private int Find(int p)
        {
            while (_map[p] != p)
                p = _map[p];

            return p;
        }
    }
}
