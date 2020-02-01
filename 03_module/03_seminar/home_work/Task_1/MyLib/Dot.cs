using System;

namespace MyLib
{
    // Declare delegate.
    public delegate void CoordChanged(Dot dot);

    /// <summary>
    /// Class Dot.
    /// </summary>
    public class Dot
    {
        // Variable for random.
        private static readonly Random Rnd = new Random();

        // Event.
        public event CoordChanged OnCoordChanged;

        // Bounds for random.
        private const int Min = -10;
        private const int Max = 10;

        // X and y coords.
        public double X { get; private set; }
        public double Y { get; private set; }

        // Constructor.
        public Dot(double x, double y) => (X, Y) = (x, y);

        /// <summary>
        /// Get double from interval.
        /// </summary>
        /// <returns> Random double from interval </returns>
        private static double GetDoubleFromInterval() =>
            double.Epsilon + Min + Rnd.NextDouble() * (Max - Min - double.Epsilon);

        /// <summary>
        /// Method for raise event (maybe).
        /// </summary>
        public void DotFlow()
        {
            for (var i = 0; i < 10; i++)
            {
                X = GetDoubleFromInterval();
                Y = GetDoubleFromInterval();

                if ((X < 0) && (Y < 0))
                    OnCoordChanged(this);
            }
        }
    }
}
