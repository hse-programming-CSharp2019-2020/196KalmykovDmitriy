using System.Text;

namespace Task_5
{
    internal class MyStack<T>
    {
        // Limit size of stack.
        private const int MaxStack = 10;

        // Stack.
        private readonly T[] _stackArray;

        // Amount of elements in stack.
        private int _stackPointer;

        public MyStack() =>
        _stackArray = new T[MaxStack];

        private bool IsStackFull => _stackPointer >= MaxStack;
        private bool IsStackEmpty => _stackPointer <= 0;

        /// <summary>
        /// Add element to stack.
        /// </summary>
        /// <param name="x"> element </param>
        public void Push(T x)
        {
            if (!IsStackFull)
                _stackArray[_stackPointer++] = x;
        }

        /// <summary>
        /// Get element from stack.
        /// </summary>
        /// <returns> element of stack </returns>
        public T Pop() =>
            !IsStackEmpty
            ? _stackArray[--_stackPointer]
            : _stackArray[0];

        /// <summary>
        /// Return info about stack elements.
        /// </summary>
        /// <returns> Info about stack elements </returns>
        public override string ToString()
        {
            var result = new StringBuilder();

            for (var i = _stackPointer - 1; i >= 0; i--)
                result.Append($"Value: {_stackArray[i]}\n");

            return result.ToString();
        }
    }
}
