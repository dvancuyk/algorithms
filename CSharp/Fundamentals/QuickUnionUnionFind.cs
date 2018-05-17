
namespace Fundamentals
{
    public class QuickUnionUnionFind : IUnionFind
    {
        private readonly int[] _map;

        /// <summary>
        /// Instantiates a new instance of the <seealso cref="QuickFindUnionFind"/> strategy with the provided "N" number of points.
        /// </summary>
        /// <param name="n"></param>
        public QuickUnionUnionFind(int n)
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

            _map[pRoot] = qRoot;

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
