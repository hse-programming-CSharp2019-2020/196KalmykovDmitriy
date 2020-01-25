using System;

namespace Numerical
{
    // Declare delegat.
    public delegate double function(double x);

    // Declare delegat.
    public delegate double Functional_1(double x);

    /// <summary>
    /// Class for analysis function.
    /// </summary>
    public class NumMeth
    {
        /// <summary>
        /// Find minimum's point.
        /// </summary>
        /// <param name="fun"> Function </param>
        /// <param name="left"> Left bound </param>
        /// <param name="right"> Right bound </param>
        /// <param name="delta"> Eps X </param>
        /// <param name="epsilon"> Eps Y </param>
        /// <returns> Minimum's point </returns>
        public static double Optimum_1(Functional_1 fun, double left, double right,
               double delta, double epsilon)
        {
            // Declare require variable.
            double rOne = (Math.Sqrt(5) - 1) / 2.0;
            double rTwo = rOne * rOne;
            double yLeft, yRight;
            double h;

            // Можно было делать обычное присваивание, но так лаконичней.
            // Set value in variables.
            (yLeft, yRight, h) = (fun(left), fun(right), right - left);

            var c = left + rTwo * h;
            var yC = fun(c);

            var d = left + rOne * h;
            var yD = fun(d);

            // Function start.
            while (Math.Abs(yLeft - yRight) > epsilon || h > delta)
            {
                if (yC < yD)
                {
                    (right, yRight) = (d, yD);
                    (d, yD, h) = (c, yC, right - left);

                    c = left + rTwo * h;
                    yC = fun(c);
                }
                else
                {
                    (left, yLeft, c, yC) = (c, yC, d, yD);

                    h = right - left;
                    d = left + rOne * h;
                    yD = fun(d);
                }
            }

            return (yRight < yLeft) ? right : left;
        }

        /// <summary>
        /// Find the root using the bisection method.
        /// </summary>
        /// <param name="left"> Left bound </param>
        /// <param name="right"> Right bound </param>
        /// <param name="epsX"> Eps X</param>
        /// <param name="epsY"> Eps Y</param>
        /// <param name="f"> Function </param>
        /// <returns> Root of function on the interval </returns>
        public static double Bisec(double left, double right,
            double epsX, double epsY, function f)
        {
            var x = left;
            var y = f(x);

            // Immediately check epsY.
            if (Math.Abs(y) <= epsY)
                return x;

            x = right;
            var z = f(x);

            // Again check EpsY.
            if (Math.Abs(z) <= epsY)
                return x;

            // Invalid range bounds.
            if (y * z > 0)
                throw new IndexOutOfRangeException("Интервал не локализует корень функции");

            // Bisec method.
            do
            {
                x = left / 2 + right / 2;
                y = f(x);

                if (Math.Abs(y) <= epsY)
                    return x;

                if (y * z > 0)
                    right = x;
                else
                    left = x;

            } while (Math.Abs(right - left) >= epsX);

            return x;
        }

    }
}