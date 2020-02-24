using System;

namespace Figures
{
    public class Square : Figure
    {
        // Side of squre.
        private double Side { get; }

        // Constructor.
        public Square(double side)
        {
            if (side <= 0)
                throw new ArgumentOutOfRangeException("side of square must be > 0\n");

            Side = side;
        }

        /// <summary>
        /// Get area of square.
        /// </summary>
        /// <returns> Area of square </returns>
        public override double GetArea() =>
            Side * Side;

        /// <summary>
        /// Return info about square.
        /// </summary>
        /// <returns> Info about square </returns>
        public override string ToString() =>
            base.ToString() + $"Area of square: {GetArea():0.####}";
    }
}
