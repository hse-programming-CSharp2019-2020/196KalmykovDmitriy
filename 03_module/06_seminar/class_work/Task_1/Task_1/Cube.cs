using System;

namespace Task_1
{
    internal class Cube : ITransform
    {
        // Length of cube's rib.
        private double _rib = 1;

        /// <summary>
        /// Change rib of cube.
        /// </summary>
        /// <param name="coefficient"> Coefficient </param>
        public void Transform(double coefficient) =>
            _rib *= coefficient;

        /// <summary>
        /// Method for return info about cube. 
        /// </summary>
        /// <returns> Info about cube </returns>
        public override string ToString() =>
            $"Volume of cube: {Math.Pow(_rib, 3):0.####}";
    }
}
