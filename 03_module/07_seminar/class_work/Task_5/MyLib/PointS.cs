using System;

namespace MyLib
{
    public struct PointS : IComparable<PointS>
    {
        // Coordinates.
        public double X { get; set; }

        public double Y { get; set; }

        // Constructor.
        public PointS(double x, double y) =>
            (X, Y) = (x, y);

        /// <summary>
        /// Get distance between 2 points.
        /// </summary>
        /// <param name="point"> Second point </param>
        /// <returns> Distance between 2 points </returns>
        public double GetDistance(PointS point) =>
            Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));

        // ALTERNATIVE: could overload operators '>' and '<'.

        /// <summary>
        /// Implement IComparable interface.
        /// </summary>
        /// <param name="other"> Second point </param>
        /// <returns> -1, 1, or 0 </returns>
        public int CompareTo(PointS other) =>
            other.GetDistance(new PointS(0, 0)).CompareTo(
                GetDistance(new PointS(0, 0)));
    }
}
