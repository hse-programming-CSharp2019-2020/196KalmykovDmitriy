namespace Task_2
{
    // Initialize some delegate.
    internal delegate double ExpDel(double x);
    internal delegate void ExpChange();

    /// <summary>
    /// Class Expression.
    /// </summary>
    internal class Expression
    {
        // Event.
        internal event ExpChange OnExpChange;

        // Field for expression method reference.
        private ExpDel _ex;

        // Constructor.
        internal Expression(ExpDel e) =>
            _ex = e;

        /// <summary>
        /// Callback.
        /// </summary>
        /// <param name="x"> Abscissa point </param>
        /// <returns> Modified value of point </returns>
        internal double ExVal(double x) =>
             _ex(x);

        internal ExpDel Ex
        {
            set
            {
                _ex = value;

                // Raise event.
                OnExpChange?.Invoke();
            }
        }
    }
}
