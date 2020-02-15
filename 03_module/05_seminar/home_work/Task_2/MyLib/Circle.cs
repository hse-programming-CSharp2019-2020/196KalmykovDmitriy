namespace MyLib
{
    public class Circle
    {
        // Center of circle.
        public readonly Dot Center;

        // Radius.
        private readonly double _radius;

        // Constructor.
        public Circle(Dot dot, double rad) =>
            (Center, _radius) = (dot, rad);

        /// <summary>
        /// Get max X coordinate of circle.
        /// </summary>
        /// <returns> Max X coordinate of circle </returns>
        public double GetMaxX() => Center.X + _radius;

        /// <summary>
        /// Get min X coordinate of circle.
        /// </summary>
        /// <returns> Min X coordinate of circle </returns>
        public double GetMinX() => Center.X - _radius;
    }
}
