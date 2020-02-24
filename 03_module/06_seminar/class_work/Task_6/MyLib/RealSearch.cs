using System;

namespace MyLib
{
    public class RealSearch : IInterFunc, IInterRoot
    {
        // Bounds of interval.
        private readonly double _left;
        private readonly double _right;

        // Accuracy.
        private readonly double _epsilon;

        // Amount of iterations.
        private int _iterations;

        /// <summary>
        /// Implement real function.
        /// </summary>
        /// <param name="root"> Root of function </param>
        /// <returns> </returns>
        double IInterFunc.ArithmeticFunction(double root) =>
            Math.Sin(root);

        // Constructor.
        public RealSearch(double left, double right, double epsilon) =>
            (_left, _right, _epsilon, _iterations) = (left, right, epsilon, 0);

        public int IterationQuantity
        {
            get
            {
                if (_iterations == 0)
                    RootSearch();

                return _iterations;
            }
        }

        public double RootSearch()
        {
            double fc, x = _left, y = _right, middle;

            var fx = ((IInterFunc)this).ArithmeticFunction(x);
            var fy = ((IInterFunc)this).ArithmeticFunction(y);

            if (fx * fy > 0)
                throw new ArgumentOutOfRangeException("Error in root localization!");
            do
            {
                middle = (y + x) / 2;
                fc = ((IInterFunc)this).ArithmeticFunction(middle);

                if (fc * fx > 0)
                    (x, fx) = (middle, fc);
                else
                    (y, fy) = (middle, fc);

                // Count iterations.
                _iterations++;
            } while (Math.Abs(fc) > _epsilon && y - x > double.Epsilon);

            return middle;
        }

    }
}