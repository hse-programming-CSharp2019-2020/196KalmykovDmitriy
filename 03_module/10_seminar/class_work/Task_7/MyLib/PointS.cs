using System;

namespace MyLib
{
    public struct PointS : IComparable
    {
        // Coordinates.
        public double X { get; set; }

        public double Y { get; set; }

        // Constructor.
        public PointS(double a, double b)
        {
            X = a; Y = b;
        }

        /// <summary>
        /// Get distance.
        /// </summary>
        /// <param name="point"> point </param>
        /// <returns> Distance between 2 points </returns>
        public double GetDistance(PointS point)
        {
            double dx = X - point.X;
            double dy = Y - point.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Implementation IComparable.
        /// </summary>
        /// <param name="otherPoint"> Other point </param>
        /// <returns> -1, 0, or 1</returns>
        public int CompareTo(object otherPoint)
        {
            var temp = new PointS(0, 0);

            return ((PointS)otherPoint).GetDistance(temp).CompareTo(GetDistance(temp));
        }
    }
}
