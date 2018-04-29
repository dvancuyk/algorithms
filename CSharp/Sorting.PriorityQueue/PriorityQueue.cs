using System;
using System.Collections.Generic;

namespace Sorting.PriorityQueue
{
    public abstract class PriorityQueue<T>
        where T : IComparable<T>
    {
        private readonly List<T> _pq;

        protected PriorityQueue()
        {
            _pq = new List<T> {default(T)};
        }

        protected PriorityQueue(int max)
        {
            _pq = new List<T>(max + 1) {default(T)};
        }

        protected PriorityQueue(IReadOnlyList<T> keys)
            : this(keys.Count)
        {
            foreach (var key in keys)
            {
                Insert(key);
            }
        }

        /// <summary>
        /// Gets the number of keys currently in the queue.
        /// </summary>
        public int Count => _pq.Count - 1;

        /// <summary>
        /// Returns a <seealso cref="bool"/> indicating if the queue is currently empty.
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Retrieves the highest priority key currently in the queue. If no items are in the queue, then <c>null</c>
        /// is returned
        /// </summary>
        public T Max
        {
            get
            {
                if (IsEmpty)
                    throw new System.InvalidOperationException("Cannot call DeleteMax on an empty priority queue.");

                return _pq[1];
            }
        }

        /// <summary>
        /// Retrieves the highest priority key currently on the queue and removes it from the queue.
        /// </summary>
        /// <returns></returns>
        public T DeleteMax()
        {
            var key = Max;
            Exchange(1, Count);
            _pq.RemoveAt(Count);
            Sink(1);

            return key;
        }

        public void Insert(T key)
        {
            var index = _pq.Count;

            _pq.Insert(index, key);
            Swim(_pq.Count - 1);
        }

        /// <summary>
        /// Determines if the first operand is less than the second operand per the heap ordering.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        protected abstract bool Less(T i, T j);

        private void Exchange(int i, int j)
        {
            var key = _pq[i];
            _pq[i] = _pq[j];
            _pq[j] = key;
        }

        private void Swim(int k)
        {
            while (k > 1 && Less(_pq[k / 2], _pq[k]))
            {
                Exchange(k / 2, k);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2 * k <= Count)
            {
                var j = 2 * k;
                if (j < Count && Less(_pq[j], _pq[j + 1]))
                    j++;

                Exchange(k, j);
                k = j;
            }
        }
    }
}
