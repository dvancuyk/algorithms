using System;
using System.Collections.Generic;

namespace Sorting.PriorityQueue
{
    /// <summary>
    /// Sorting mechanism which maintains a queue of items based on the highest priority of the items enqueued.
    /// </summary>
    public class MaxPriorityQueue<T> : PriorityQueue<T>
        where T : IComparable<T>
    {
        public MaxPriorityQueue(int max)
         : base(max)
        {

        }

        public MaxPriorityQueue(IReadOnlyList<T> keys)
            : base(keys)
        {
            
        }

        protected override bool Less(T i, T j)
        {
            return i.CompareTo(j) < 0;
        }
    }
}
