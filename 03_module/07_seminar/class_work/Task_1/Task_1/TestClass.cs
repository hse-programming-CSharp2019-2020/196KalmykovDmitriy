using System;

namespace Task_1
{
    internal class TestClass : IComparable<TestClass>
    {
        internal int X { get; set; }

        // ALTERNATIVE: could overload operators '<' and '>'.

        /// <summary>
        /// Compares 2 TestClass objects.
        /// </summary>
        /// <param name="another"> Second value </param>
        /// <returns> -1, 0 or 1 </returns>
        public int CompareTo(TestClass another) =>
            X.CompareTo(another.X);
    }
}
