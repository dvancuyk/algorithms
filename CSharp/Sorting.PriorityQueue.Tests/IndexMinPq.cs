using System;

namespace Sorting.PriorityQueue.Tests
{
    /// <summary>
    /// A priority queue implementation that allows clients to add an index to an item on the priority queue.
    /// </summary>
    public class IndexMinPq<TItem>
        where TItem : IComparable<TItem>
    {
        public IndexMinPq()
        {
            
        }

        public IndexMinPq(int maxSize)
        {
            
        }

        public int Count { get; }

        public bool IsEmpty { get; }
        

        public TItem Min { get; }

        public int MinIndex { get; }

        public void Insert(int k, TItem item)
        {

        }

        public void Change(int k, TItem item)
        {

        }
        public bool Contains(int k)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int k)
        {

        }
    }
}
