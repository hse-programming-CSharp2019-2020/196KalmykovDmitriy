using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Numerical
{
    public delegate double function(double x);

    public delegate double Functional_1(double x);

    public class NumMeth
    {
        public static double Optimum_1(Functional_1 fun, double left, double right,
               double delta, double epsilon)
        {
            double rOne = (Math.Sqrt(5) - 1) / 2.0;
            double rTwo = rOne * rOne;
            double yLeft, yRight;
            double c, d;
            double h;
            double p, yC, yD, yP;

            yLeft = fun(left);
            yRight = fun(right);
            h = right - left;
            c = left + rTwo * h;
            yC = fun(c);
            d = left + rOne * h;
            yD = fun(d);

            while (Math.Abs(yLeft-yRight)>epsilon || h>delta)
            {
                if (yC < yD)
                {
                    right = d;
                    yRight = yD;
                    d = c;
                    yD = yC;
                    h = right - left;
                    c = left + rTwo * h;
                    yC = fun(c);
                }
                else
                {
                    left = c;
                    yLeft = yC;
                    c = d;
                    yC = yD;
                    h = right - left;
                    d = left + rOne * h;
                    yD = fun(d);
                }
            }

            p = left;
            yP = yLeft;

            if (yRight < yLeft)
            {
                p = right;
                yP = yRight;
            }

            return p;
        }

        public static double Bisec(double left, double right,
            double epsX, double epsY, function f)
        {
            double x, y, z;

            x = left;
            y = f(x);

            if (Math.Abs(y) <= epsY)
                return x;

            x = right;
            z = f(x);

            if (Math.Abs(z) <= epsY)
                return x;

            if (y * z > 0)
                throw new IndexOutOfRangeException("Интервал не локализует корень функции");

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