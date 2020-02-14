using System;

namespace MyLib
{
    /// <summary>
    /// Class Point.
    /// </summary>
    internal class Point
    {
        // X coordinate.
        public double X { get; set; }

        // Y coordinate.
        public double Y { get; set; }

        // Constructor.
        public Point(double x, double y) =>
            (X, Y) = (x, y);

        /// <summary>
        /// Get distance between 2 points.
        /// </summary>
        /// <param name="p"> Second point </param>
        /// <returns> Distance between 2 points </returns>
        public double Distance(Point p) =>
            Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
    }
}
