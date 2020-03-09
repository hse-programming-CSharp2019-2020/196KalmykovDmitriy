using System;

namespace Task_3
{
    internal class Circle : IFigure
    {
        // Radius of circle.
        private readonly int _radius;

        // Constructor.
        public Circle(int radius) =>
            _radius = radius;

        // Get area of circle.
        public double GetArea =>
            Math.PI * _radius * _radius;

        /// <summary>
        /// Return info about circle.
        /// </summary>
        /// <returns> Info about circle </returns>
        public override string ToString() =>
            "Radius of circle: " + _radius;
    }
}
