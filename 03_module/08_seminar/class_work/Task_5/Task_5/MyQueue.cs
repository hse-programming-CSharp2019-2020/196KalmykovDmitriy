using System;
using System.Collections.Generic;
using System.Text;

namespace Task_5
{
    internal class MyQueue<T>
    {
        // Size of queue.
        private const int Capacity = 100;

        // Queue.
        private readonly List<T> _items = new List<T>(100);

        // First element of the queue.
        internal T First
        {
            get
            {
                if (_items.Count == 0)
                    throw new ApplicationException("The queue is empty!");

                return _items[0];
            }
        }

        // Last element of the queue.
        internal T Last
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
        internal void Enqueue(T data)
        {
            if (IsFull)
                throw new ApplicationException("The queue is full!");

            _items.Insert(0, data);
        }

        /// <summary>
        /// Delete item from queue.
        /// </summary>
        /// <returns></returns>
        internal T Dequeue()
        {
            if (IsEmpty)
                throw new ApplicationException("The queue is empty!");

            var temp = Last;
            _items.RemoveAt(_items.Count - 1);

            return temp;
        }

        /// <summary>
        /// Return info about elements.
        /// </summary>
        /// <returns> Info about elements </returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            for (var i = _items.Count - 1; i >= 0; i--)
            {
                result.Append($"Value: {_items[i]}\n");
            }

            return result.ToString();
        }
    }
}
