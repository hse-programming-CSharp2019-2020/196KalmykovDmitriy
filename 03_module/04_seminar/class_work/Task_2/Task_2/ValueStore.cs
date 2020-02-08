namespace Task_2
{
    /// <summary>
    /// Class ValueStore.
    /// </summary>
    internal class ValueStore
    {
        private readonly Expression _exp;

        // Abscissa point.
        private readonly double _x0;

        // Constructor.
        internal ValueStore(Expression e1, double x0)
        {
            _exp = e1;
            (_x0, CurrentVal) = (x0, _exp.ExVal(x0));
        }

        // Property CurrentVal.
        internal double CurrentVal { get; private set; }

        /// <summary>
        /// Method handler.
        /// Change value.
        /// </summary>
        internal void OnExpChangeHandler() =>
            CurrentVal = _exp.ExVal(_x0);
    }
}
