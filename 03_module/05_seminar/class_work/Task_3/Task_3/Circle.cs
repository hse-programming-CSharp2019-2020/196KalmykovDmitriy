using System;

namespace Task_3
{
    /// <summary>
    /// Class Circle.
    /// </summary>
    internal class Circle
    {
        // Radius.
        internal double Rad { get; }

        // Center of circle.
        internal Point Center { get; }

        // Constructor.
        internal Circle(double x, double y, double z, double rad) =>
            (Center, Rad) = (new Point(x, y, z), rad);
        
        /// <summary>
        /// Print info about circle.
        /// </summary>
        /// <returns> Info about circle </returns>
        public override string ToString() =>
            $"Center of circle: {Center:0.###}\n" +
            $"Radius: {Rad:0.###}\n";
    }
}
