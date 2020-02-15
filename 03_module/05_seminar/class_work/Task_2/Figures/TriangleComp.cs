using System;
using System.Collections.Generic;
using System.Linq;

namespace Figures
{
    /// <summary>
    /// Class Triangle.
    /// </summary>
    public class TriangleComp
    {
        private readonly List<Point> _points = new List<Point>();

        private readonly List<double> _sidesDistance = new List<double>();

        public double Square => GetSquare();

        // Constructor.
        public TriangleComp(IReadOnlyList<double> xList, IReadOnlyList<double> yList)
        {
            FillPoints(xList, yList);
            FillSidesDistance();

            if (!IsTriangle())
                throw new ArgumentException("It's not a triangle!");
        }

        /// <summary>
        /// Check triangle inequality.
        /// </summary>
        /// <returns> True or false </returns>
        private bool IsTriangle() =>
                _sidesDistance[0] < _sidesDistance[1] + _sidesDistance[2] &&
                _sidesDistance[1] < _sidesDistance[2] + _sidesDistance[0] &&
                _sidesDistance[2] < _sidesDistance[1] + _sidesDistance[0];


        /// <summary>
        /// Fill list from points.
        /// </summary>
        /// <param name="xList"> X coordinates </param>
        /// <param name="yList"> Y coordinates </param>
        private void FillPoints(IReadOnlyList<double> xList, IReadOnlyList<double> yList)
        {
            for (var i = 0; i < xList.Count; i++)
                _points.Add(new Point(xList[i], yList[i]));
        }

        /// <summary>
        /// Fill list from sides.
        /// </summary>
        private void FillSidesDistance()
        {
            _sidesDistance.Add(_points[0].GetDistance(_points[1]));
            _sidesDistance.Add(_points[0].GetDistance(_points[2]));
            _sidesDistance.Add(_points[1].GetDistance(_points[2]));
        }

        /// <summary>
        /// Find square of triangle.
        /// </summary>
        /// <returns> Square of triangle </returns>
        private double GetSquare()
        {
            var p = _sidesDistance.Sum() / 2;

            // ALTERNATIVE: could be calculate separately every (p-sides).
            return _sidesDistance.Aggregate<double, double, double>
                (1, (x, y) => x * (p - y), result => Math.Sqrt(result * p));
        }

        /// <summary>
        /// Get length of vector's multiply.
        /// </summary>
        /// <param name="ind1"> Index of first point</param>
        /// <param name="ind2"> Index of second point </param>
        /// <param name="point"> Point for check </param>
        /// <returns> Length of vector's multiply </returns>
        private double GetVectorsMultiply(int ind1, int ind2, Point point) =>
            (_points[ind1].X - point.X) * (_points[ind2].Y - _points[ind1].Y) -
            (_points[ind2].X - _points[ind1].X) * (_points[ind1].Y - point.Y);

        // ALTERNATIVE: we can use square's method for check belong to triangle.

        /// <summary>
        /// Check point for belong to triangle.
        /// </summary>
        /// <param name="point"> Point </param>
        /// <returns> True or false </returns>
        public bool IsBelongToTriangle(Point point)
        {
            var vectorsMultiply = new List<double>
            {
                GetVectorsMultiply(0, 1, point),
                GetVectorsMultiply(1, 2, point),
                GetVectorsMultiply(2, 0, point)
            };

            return vectorsMultiply.TrueForAll(el => el >= 0) ||
                   vectorsMultiply.TrueForAll(el => el <= 0);
        }
    }
}
