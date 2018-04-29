using System;
using System.Collections.Generic;

namespace Sorting.PriorityQueue
{
    public class MinPriorityQueue<T> : PriorityQueue<T>
        where T : IComparable<T>
    {
        public MinPriorityQueue()
        {
            
        }

        public MinPriorityQueue(int max)
            : base(max)
        {

        }

        public MinPriorityQueue(IReadOnlyList<T> keys)
            : base(keys)
        {

        }

        protected override bool Less(T i, T j)
        {
            return i.CompareTo(j) > 0;
        }
    }
}
