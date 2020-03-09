namespace Task_3
{
    internal class Square : IFigure
    {
        // Side of square.
        private readonly int _side;

        // Constructor.
        internal Square(int side) =>
            _side = side;

        /// <summary>
        /// Return info about square.
        /// </summary>
        /// <returns> Info about square </returns>
        public override string ToString() =>
            "Side of square: " + _side;

        /// <summary>
        /// Area of square.
        /// </summary>
        public double GetArea => _side * _side;
    }
}
