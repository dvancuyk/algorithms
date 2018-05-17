using System.Net.NetworkInformation;

namespace Fundamentals
{
    /// <summary>
    /// Algorithm which allows clients to connect a given set of indices and determine through these connections if any given point is 
    /// </summary>
    public class QuickFindUnionFind : IUnionFind
    {
        private readonly int[] _map;

        /// <summary>
        /// Instantiates a new instance of the <seealso cref="QuickFindUnionFind"/> strategy with the provided "N" number of points.
        /// </summary>
        /// <param name="n"></param>
        public QuickFindUnionFind(int n)
        {
            _map = new int[n];
            for (int i = 0; i < n; i++)
            {
                _map[i] = i;
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

            for (int i = 0; i < _map.Length; i++)
            {
                if (_map[i] == pRoot)
                    _map[i] = qRoot;
            }

            Count--;
        }
        
        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        private int Find(int p)
        {
            return _map[p];
        }
    }
}
