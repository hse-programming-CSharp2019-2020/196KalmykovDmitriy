using System;

namespace Structures
{
    public struct CircleS : IComparable<CircleS>//, IComparer<CircleS>
    {
        // Radius of circle.
        public double Radius { get; set; }

        // Center of circle.
        public PointS Center { get; set; }

        // Constructor.
        public CircleS(double x, double y, double radius)
        {
            // Check value of radius.
            if (radius <= 0)
                throw new ArgumentOutOfRangeException("Radius must be positive!\n");

            (Center, Radius) = (new PointS(x, y), radius);
        }

        // Length of circle.
        public double Length => 2 * Math.PI * Radius;

        // ALTERNATIVE: could overload operators '>' and '<'.

        /// <summary>
        /// Implement IComparable interface.
        /// </summary>
        /// <param name="other"> Second circle </param>
        /// <returns> -1, 0, or 1 </returns>
        public int CompareTo(CircleS other) =>
            Radius.CompareTo(other.Radius);

        /// <summary>
        /// Return info about circle.
        /// </summary>
        /// <returns> Info about circle </returns>
        public override string ToString() =>
            $"Center: {Center}\n" +
            $"Radius: {Radius:0.####}";
    }
}
