using System;

namespace MyLib
{
    public delegate void Qdelegate(Quadratic equation);

    public static class Processing
    {
        /// <summary>
        /// Get real solutions.
        /// </summary>
        /// <param name="equation"> Equation </param>
        public static void GetRealSolutions(Quadratic equation)
        {
            if (equation.Discriminant < 0)
            {
                return;
            }

            PrintEquation(equation);

            Console.WriteLine($"Roots: Х1 = {equation.X1,3:g3} \tX2 = {equation.X2,3:g3}");
            Console.WriteLine("------------------------------------------");
        }

        /// <summary>
        /// Return info about equation.
        /// </summary>
        /// <param name="equation"> Info about equation </param>
        public static void PrintEquation(Quadratic equation) =>
            Console.WriteLine($"{equation}; Discriminant = {equation.Discriminant:g3}\n");
    }
}
