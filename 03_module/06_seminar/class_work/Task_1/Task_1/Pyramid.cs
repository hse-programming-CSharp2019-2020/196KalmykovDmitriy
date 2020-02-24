using System;

namespace Task_1
{
    internal class Pyramid : ITransform
    {
        // Length of base side.
        private double B { get; set; } = 1;

        // Length of height of pyramid.
        private double H { get; set; } = 1;

        /// <summary>
        /// Change base side and height of pyramid.
        /// </summary>
        /// <param name="coefficient"> Coefficient </param>
        public void Transform(double coefficient) =>
            (B, H) = (B * coefficient, H * coefficient);

        /// <summary>
        /// Get area of full cover of pyramid.
        /// </summary>
        /// <returns> Area </returns>
        private double GetArea() =>
            B * (B + Math.Sqrt(4 * H * H + B * B));

        /// <summary>
        /// Method for return info about pyramid.
        /// </summary>
        /// <returns> Info about pyramid </returns>
        public override string ToString() =>
            $"Volume of pyramid: {H * B * B / 3:0.####}, Area: {GetArea():0.####}";
    }
}
