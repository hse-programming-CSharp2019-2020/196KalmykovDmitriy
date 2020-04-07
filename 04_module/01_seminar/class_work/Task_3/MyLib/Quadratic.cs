using System;

namespace MyLib
{
    [Serializable]
    public class Quadratic
    {
        // Coefficients.
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public double Discriminant { get; set; }

        // Roots of equation Ax^2 + Bx +C = 0.
        public double X1 { get; set; }
        public double X2 { get; set; }

        public Quadratic() { }

        // Constructor.
        public Quadratic(double a, double b, double c)
        {
            if (Math.Abs(a) < double.Epsilon)
            {
                throw new ArgumentException("Coefficient A can't be zero");
            }

            (A, B, C) = (a, b, c);

            Discriminant = b * b - 4 * a * c;

            // Roots.
            X1 = (-b - Math.Sqrt(Discriminant)) / (2 * a);
            X2 = (-b + Math.Sqrt(Discriminant)) / (2 * a);
        }

        public override string ToString() =>
            $"{A}x^2 + {B}x + {C} = 0";
    }
}
