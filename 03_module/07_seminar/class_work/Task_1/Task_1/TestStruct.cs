using System;

namespace Task_1
{
    internal struct TestStruct : IComparable<TestStruct>
    {
        internal int X;

        // ALTERNATIVE: could overload operators '<' and '>'.

        /// <summary>
        /// Compares 2 TestStruct elements.
        /// </summary>
        /// <param name="another"> Second value </param>
        /// <returns> -1, 0 or 1 </returns>
        public int CompareTo(TestStruct another) =>
            X.CompareTo(another.X);
    }
}
