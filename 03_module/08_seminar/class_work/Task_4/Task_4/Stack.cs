using System;

namespace Task_4
{
    internal class Stack<TItem>
    {
        // Size limit of stack.
        private const int StackSize = 100;

        // Stack.
        private readonly TItem[] _items = new TItem[StackSize];

        // Free element number.
        private int _index;

        /// <summary>
        /// Add element to stack.
        /// </summary>
        /// <param name="data"></param>
        internal void Push(TItem data)
        {
            if (_index == StackSize)
                throw new ApplicationException("The stack is full!");

            _items[_index++] = data;
        }

        /// <summary>
        /// Get item from stack.
        /// </summary>
        /// <returns> Item from stack </returns>
        internal TItem Pop()
        {
            if (_index == 0)
                throw new ApplicationException("The stack is empty!");

            return _items[--_index];
        }
    }
}
