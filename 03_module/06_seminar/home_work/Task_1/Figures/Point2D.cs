using System;

namespace Figures
{
    public class Point2D
    {
        // Coordinates.
        internal double X { get; set; }
        internal double Y { get; set; }

        // Constructor.
        public Point2D(double x, double y) => (X, Y) = (x, y);

        /// <summary>
        /// Get distance between 2 points.
        /// </summary>
        /// <param name="point"> Second point </param>
        /// <returns> Distance between 2 points </returns>
        internal double GetDistance(Point2D point) =>
            Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));
    }
}
