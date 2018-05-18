using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting.PriorityQueue
{
    /// <summary>
    /// An implementation of a priority queue which allows a client to assign and track a provided id for a given item placed on the queue.
    /// </summary>
    public class IndexMinPriorityQueue<T>
        where T : IComparable<T>
    {
        public IndexMinPriorityQueue(int capacity)
        {
            
        }

        /// <summary>
        /// Gets the number of items that are on the queue.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Gets the item that is next on the queue.
        /// </summary>
        public T Next { get; }

        /// <summary>
        /// Retrieves the index of the of the next item in the priority queue.
        /// </summary>
        public int NextIndex { get; }

        /// <summary>
        /// Determines if the queue is empty or not.
        /// </summary>
        public bool IsEmpty => Count == 0;

        /// <summary>
        /// Adds an item to the queue.
        /// </summary>
        /// <param name="id">An externally provided id that should be associated with the provided item</param>
        /// <param name="item">The item that is placed on the queue.</param>
        public void Insert(int id, T item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Changes the item that is associated with the provided id to the new provided item.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        public void Change(int id, T item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes the 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public T DeleteMinimum()
        {
            throw new System.NotImplementedException();
        }


    }
}
