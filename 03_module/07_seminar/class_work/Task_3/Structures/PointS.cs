using System;

namespace Structures
{
    public struct PointS
    {
        // Coordinates of point.
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

        /// <summary>
        /// Return info about point.
        /// </summary>
        /// <returns> Info about point </returns>
        public override string ToString() =>
            $"X: {X:0.####}, Y: {Y:0.####}";
    }
}
