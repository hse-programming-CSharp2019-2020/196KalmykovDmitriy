using System;

namespace Task_4
{
    /// <summary>
    /// Class series.
    /// </summary>
    internal class Series
    {
        // Array from int numbers.
        internal int[] intsArr;

        /// <summary>
        /// Callback method.
        /// </summary>
        /// <param name="cond"> Condition </param>
        internal void Order(Comparison<int> cond)
        {
            if (cond is null)
                throw new ArgumentNullException("Attempt to convey null");

            Array.Sort(intsArr, cond);
        }
    }
}
