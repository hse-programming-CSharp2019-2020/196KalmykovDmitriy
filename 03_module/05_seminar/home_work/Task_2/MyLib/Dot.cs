namespace MyLib
{
    /// <summary>
    /// Class Dot.
    /// </summary>
    public class Dot
    {
        // Coordinates of dot.
        private double _x;
        private readonly double _y;

        /// <summary>
        /// Get X coordinate.
        /// </summary>
        /// <returns> X coordinate </returns>
        public double GetX() => _x;

        /// <summary>
        /// Get Y coordinate.
        /// </summary>
        /// <returns> Y coordinate </returns>
        public double GetY() => _y;

        // Constructor.
        public Dot(double x, double y) =>
            (_x, _y) = (x, y);

        /// <summary>
        /// Change X coordinate.
        /// </summary>
        /// <param name="x"> New X </param>
        public void ChangeX(double x) =>
            _x = x;
    }
}
