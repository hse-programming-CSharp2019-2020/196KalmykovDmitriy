namespace Task_2
{
    internal class ElectronicQueue<T>
        where T : struct
    {
        // Queue.
        private readonly MyQueue<T> _electronicQueue = new MyQueue<T>();

        // Length of the queue.
        internal int Length => _electronicQueue.Count;

        /// <summary>
        /// Add element to the queue.
        /// </summary>
        /// <param name="item"> Item to add </param>
        public void AddToElectronicQueue(T item) =>
            _electronicQueue.Enqueue(item);

        /// <summary>
        /// Get first element of the queue.
        /// </summary>
        /// <returns></returns>
        public string CallFromElectronicQueue()
        {
            T tmp = default;
            if (_electronicQueue.Count > 0)
                tmp = _electronicQueue.Dequeue();

            var output = tmp.ToString();
            return output;
        }

        /// <summary>
        /// Delete element of the queue.
        /// </summary>
        internal void DeleteFromElectronicQueue()
        {
            if (_electronicQueue.Count > 0)
                _electronicQueue.Dequeue();
        }
    }
}
