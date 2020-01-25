using Numerical;
using System;

namespace Task_3
{
    class Program
    {
        #region Consts for bisection method.
        private const double EpsX = 0.01;
        private const double EpsY = 0;
        private const double Left = 3;
        private const double Right = 4;
        #endregion

        #region Consts for optimum method.
        private const double Epsilon = 0.01;
        private const double Delta = 0.001;
        #endregion

        /// <summary>
        /// Print color message.
        /// </summary>
        /// <param name="message"> Message </param>
        /// <param name="color"> Message's color </param>
        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Get Sin(x).
        /// </summary>
        /// <param name="x"> X </param>
        /// <returns> Sin(x)</returns>
        private static double SinX(double x) => Math.Sin(x);

        /// <summary>
        /// Test bisection method.
        /// </summary>
        private static void TestBisec()
        {
            PrintMessage("Test Bisec method:\n\n", ConsoleColor.Green);

            Console.WriteLine("Find root of equation Sin(x) = 0," +
                              $" on the segment [{Left}, {Right}]:" + Environment.NewLine);

            // Types of functions.
            function[] funcsArr =
            {
                Math.Sin,
                SinX,
                delegate(double x) { return Math.Sin(x); },
                x => Math.Sin(x)
            };

            // Types of messages.
            string[] messages =
            {
                "Finding a root using a library function: ",
                "Finding a root using a static method explicitly defined in the program: ",
                "Finding a root using an anonymous method: ",
                "Finding a root using a lambda expression: "
            };

            // Test.
            for (int i = 0; i < 4; i++)
            {
                PrintMessage(messages[i]);
                PrintMessage($"x = {NumMeth.Bisec(Left, Right, EpsX, EpsY, funcsArr[i])}\n",
                    ConsoleColor.Yellow);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Test optimum method.
        /// </summary>
        private static void TestOptimum()
        {
            PrintMessage("Test Optimum_1 method:\n\n", ConsoleColor.Green);

            // Text presentation of functions.
            string[] funcsTextArr =
            {
                "Cos(x)",
                "x * (x * x - 2) - 5",
                "-Sin(x) - Sin(3 * x) / 3"
            };

            // Types of functions.
            Functional_1[] funcsArr =
            {
                x => Math.Cos(x),
                x => x * (x * x - 2) - 5,
                x => -Math.Sin(x) - Math.Sin(3 * x) / 3
            };

            // Bounds for every function.
            (int left, int right)[] bounds =
            {
                (3, 6),
                (0, 1),
                (0, 1)
            };

            // Test method.
            for (int i = 0; i < 3; i++)
            {
                var minX = NumMeth.Optimum_1(funcsArr[i], bounds[i].left, bounds[i].right, Delta, Epsilon);

                PrintMessage($"Function minimum point {funcsTextArr[i]} " +
                             $"on the segment [{bounds[i].left}, {bounds[i].right}]: ");
                PrintMessage($"x = {minX}\n", ConsoleColor.Yellow);
            }
        }

        static void Main(string[] args)
        {
            // Attempt to apply bisection method.
            try
            {
                TestBisec();
            }
            catch (IndexOutOfRangeException ex)
            {
                PrintMessage(ex.Message, ConsoleColor.Red);
            }

            TestOptimum();

            PrintMessage("\nPress ESC for exit", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
