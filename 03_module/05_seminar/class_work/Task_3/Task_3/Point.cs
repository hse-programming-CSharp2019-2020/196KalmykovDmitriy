using System;

namespace Task_3
{
    /// <summary>
    /// Class Point.
    /// </summary>
    internal class Point
    {
        // X coordinate.
        internal double X { get; }

        // Y coordinate.
        internal double Y { get; }

        // Z coordinate.
        internal double Z { get; }

        // Constructor.
        internal Point(double x, double y, double z) =>
            (X, Y, Z) = (x, y, z);

        /// <summary>
        /// Get distance between 2 points.
        /// </summary>
        /// <param name="p"> Second point </param>
        /// <returns> Distance between 2 points </returns>
        internal double GetDistance(Point p) =>
            Math.Sqrt(Math.Pow(p.X - X, 2) + Math.Pow(p.Y - Y, 2));

        /// <summary>
        /// Print info about point.
        /// </summary>
        /// <returns> Info about point </returns>
        public override string ToString() =>
            $"X = {X:0.###}, " +
            $"Y = {Y:0.###}, " +
            $"Z = {Z:0.###}";
    }
}
