using System;
using System.Collections.Generic;
using System.Linq;

namespace Figures
{
    public class Triangle : Figure
    {
        // Vertex of triangle.
        private readonly Point2D _point1;
        private readonly Point2D _point2;
        private readonly Point2D _point3;

        // Lengths of sides triangle.
        private readonly List<double> _sides = new List<double>();

        // Constructor.
        public Triangle(Point2D p1, Point2D p2, Point2D p3)
        {
            (_point1, _point2, _point3) = (p1, p2, p3);

            SetLengthSides();

            if (!IsTriangle())
                throw new ArgumentException("It's not a triangle!\n");
        }

        /// <summary>
        /// Check side for triangle's inequality 
        /// </summary>
        /// <param name="i1"> Index of the side for check </param>
        /// <param name="i2"> Index of second side </param>
        /// <param name="i3"> Index of third side </param>
        /// <returns></returns>
        private bool SideLessThanSum(int i1, int i2, int i3) =>
            _sides[i1] < _sides[i2] + _sides[i3];

        /// <summary>
        /// Check figure for triangle.
        /// </summary>
        /// <returns> True or false </returns>
        private bool IsTriangle() =>
            SideLessThanSum(0, 1, 2) &&
             SideLessThanSum(1, 0, 2) &&
             SideLessThanSum(2, 1, 0);

        /// <summary>
        /// Set lengths of sides.
        /// </summary>
        private void SetLengthSides()
        {
            _sides.Add(_point1.GetDistance(_point2));
            _sides.Add(_point1.GetDistance(_point3));
            _sides.Add(_point2.GetDistance(_point3));
        }

        /// <summary>
        /// Get area of triangle.
        /// </summary>
        /// <returns> Area of triangle </returns>
        public override double GetArea()
        {
            var p = _sides.Sum() / 2;

            return _sides.Aggregate<double, double, double>(1, (x, y) => x * (p - y),
                result => Math.Sqrt(result * p));
        }

        /// <summary>
        /// Return info about triangle.
        /// </summary>
        /// <returns> Info about triangle </returns>
        public override string ToString() =>
            base.ToString() + $"Area: {GetArea():0.####}";
    }
}
