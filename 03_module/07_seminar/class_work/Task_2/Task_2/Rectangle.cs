using System;

namespace Task_2
{
    internal class Rectangle : IComparable<Rectangle>
    {
        private Coords _lowerRightCorner;

        internal Coords UpperLeftCorner { get; set; }

        internal Coords LowerRightCorner
        {
            get => _lowerRightCorner;
            set
            {
                var notRectangle = NotRectangle(value);

                // Check figure for shape.
                if (notRectangle)
                    throw new ArgumentOutOfRangeException("It's not a rectangle!\n");

                _lowerRightCorner = value;
            }
        }

        /// <summary>
        /// Check figure for shape.
        /// </summary>
        /// <param name="lowerRightCorner"> Lower right corner </param>
        /// <returns> True or false </returns>
        private bool NotRectangle(Coords lowerRightCorner) =>
            lowerRightCorner.X > UpperLeftCorner.X &&
            lowerRightCorner.Y < UpperLeftCorner.Y;

        // Constructor.
        internal Rectangle(Coords upperLeftCorner, Coords lowerRightCorner) =>
            (UpperLeftCorner, LowerRightCorner) = (upperLeftCorner, lowerRightCorner);

        /// <summary>
        /// Get area of rectangle.
        /// </summary>
        /// <returns> Area of rectangle </returns>
        private double GetArea() =>
            Math.Abs((LowerRightCorner.X - UpperLeftCorner.X) *
                     (UpperLeftCorner.Y - LowerRightCorner.Y));

        // ALTERNATIVE: could overload operators '<' and '>'.

        /// <summary>
        /// Implement IComparable interface. 
        /// </summary>
        /// <param name="other"> Second rectangle </param>
        /// <returns> 1, 0 or -1 </returns>
        public int CompareTo(Rectangle other) =>
            GetArea().CompareTo(other.GetArea());

        public override string ToString() =>
            $"Upper left corner: {UpperLeftCorner}\n" +
            $"Lower right corner: {LowerRightCorner}\n" +
            $"Area: {GetArea():0.####}\n\n";
    }
}
