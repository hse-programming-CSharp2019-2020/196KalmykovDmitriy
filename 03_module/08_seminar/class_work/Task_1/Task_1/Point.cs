using System;

namespace Task_1
{
    internal class Point<T> : IComparable<Point<T>>
        where T : struct
    {
        // Coordinates.
        internal T X { get; }
        internal T Y { get; }

        // Distance(^2) from (0; 0).
        internal dynamic Distance => (dynamic)X * X + (dynamic)Y * Y;

        // Constructor.
        internal Point(T x, T y) =>
            (X, Y) = (x, y);

        /// <summary>
        /// Implement IComparable.
        /// </summary>
        /// <param name="other"> Second point </param>
        /// <returns> -1, 1 or 0 </returns>
        public int CompareTo(Point<T> other) =>
            Distance.CompareTo(other.Distance);

        /// <summary>
        /// Return info about point.
        /// </summary>
        /// <returns> Info about point </returns>
        public override string ToString() =>
            $"Type of coordinates: {typeof(T)}\n" +
            $"X: {X:0.####}\nY: {Y:0.####}\n" +
            $"Distance from (0; 0): {Distance:0.####}\n\n";
    }
}
