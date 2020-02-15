using System;

namespace Figures
{
    /// <summary>
    /// Class Point.
    /// </summary>
    public class Point
    {
        // X coordinate.
        public double X { get; }

        // Y coordinate.
        public double Y { get; }

        // Constructor.
        public Point(double x, double y) =>
            (X, Y) = (x, y);

        /// <summary>
        /// Get distance between 2 point.
        /// </summary>
        /// <param name="p"> Second point </param>
        /// <returns> Distance between 2 point </returns>
        public double GetDistance(Point p) =>
            Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
    }
}
