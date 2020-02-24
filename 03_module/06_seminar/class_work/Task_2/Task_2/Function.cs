using System;

namespace Task_2
{
    internal class Function : ITransform
    {
        // y = kx + b;
        private const double K = 1;
        private double _b = 1;

        /// <summary>
        /// Change value of b of line.
        /// </summary>
        /// <param name="coefficient"> Coefficient </param>
        public void Transform(double coefficient) =>
            _b -= K * coefficient;

        // K doesn't change, therefore we can define view of line without k.
        /// <summary>
        /// Method for return info about function.
        /// </summary>
        /// <returns> Info about function </returns>
        public override string ToString() =>
            _b > 0 ? $"View of line: x + {_b:0.####}" :
                Math.Abs(_b) < double.Epsilon ? "View of line: x" :
                $"View of line: x - {Math.Abs(_b):0.####}";
    }
}
