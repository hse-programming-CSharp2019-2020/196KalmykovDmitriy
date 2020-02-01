namespace Task_7
{
    // Declare delegate.
    internal delegate void SortHandler(long cn, int si, int kl);

    /// <summary>
    /// Class Sorting.
    /// </summary>
    internal class Sorting
    {
        private readonly int[] _arr;

        // Amount of exchanges.
        internal long count;

        // Event.
        internal event SortHandler OnSort;

        // Constructor.
        internal Sorting(int[] ls) => (count, _arr) = (0, ls);

        /// <summary>
        /// Sort array.
        /// </summary>
        internal void Sort()
        {
            // Sort array.
            for (var i = 0; i < _arr.Length - 1; i++)
            {
                for (var j = i + 1; j < _arr.Length; j++)
                    if (_arr[i] > _arr[j])
                    {
                        (_arr[i], _arr[j]) = (_arr[j], _arr[i]);

                        count++;
                    }

                OnSort?.Invoke(count, _arr.Length, i);
            }
        }
    }
}
