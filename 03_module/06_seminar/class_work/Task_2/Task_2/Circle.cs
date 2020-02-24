using System;

namespace Task_2
{
    internal class Circle : ITransform
    {
        // Radius of circle.
        private double _rad = 1;

        /// <summary>
        /// Change radius.
        /// </summary>
        /// <param name="coefficient"> Coefficient </param>
        public void Transform(double coefficient) =>
            _rad *= coefficient;

        /// <summary>
        /// Method for return info about circle.
        /// </summary>
        /// <returns> Info about circle </returns>
        public override string ToString() =>
            $"Area of circle: {Math.PI * _rad * _rad:0.####}";
    }
}
