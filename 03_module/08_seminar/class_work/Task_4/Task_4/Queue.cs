using System;
using System.Collections.Generic;

namespace Task_4
{
    internal class Queue<TItem>
    {
        // Size of queue.
        private const int Capacity = 100;

        // Queue.
        private readonly List<TItem> _items = new List<TItem>(100);

        // First element of the queue.
        internal TItem First
        {
            get
            {
                if (_items.Count == 0)
                    throw new ApplicationException("The queue is empty!");

                return _items[0];
            }
        }

        // Last element of the queue.
        internal TItem Last
        {
            get
            {
                if (_items.Count == 0)
                    throw new ApplicationException("The queue is empty!");

                return _items[_items.Count - 1];
            }
        }

        internal bool IsEmpty => _items.Count == 0;

        internal bool IsFull => _items.Count == Capacity;

        /// <summary>
        /// Add item to the queue.
        /// </summary>
        /// <param name="data"></param>
        internal void Enqueue(TItem data)
        {
            if (IsFull)
                throw new ApplicationException("The queue is full!");

            _items.Insert(0, data);
        }

        /// <summary>
        /// Delete item from queue.
        /// </summary>
        /// <returns></returns>
        internal TItem Dequeue()
        {
            if (IsEmpty)
                throw new ApplicationException("The queue is empty!");

            var temp = Last;
            _items.RemoveAt(_items.Count - 1);

            return temp;
        }
    }
}
