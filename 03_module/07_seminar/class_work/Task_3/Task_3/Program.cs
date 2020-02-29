using Structures;
using System;
using System.Collections.Generic;

namespace Task_3
{
    internal class Program
    {
        private static readonly Random Rnd = new Random();

        #region Consts.

        private const int Amount = 10;
        private const int Min = -5;
        private const int Max = 15;

        #endregion

        /// <summary>
        /// Get array of circles.
        /// </summary>
        /// <returns> Array of circles </returns>
        private static CircleS[] GetCircles()
        {
            var circles = new CircleS[Amount];

            for (var i = 0; i < Amount; i++)
            {
                // Attempt to create new circle.
                try
                {
                    var x = GetDoubleFromInterval();
                    var y = GetDoubleFromInterval();
                    var radius = GetDoubleFromInterval();
                    circles[i] = new CircleS(x, y, radius);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    // Print error message.
                    PrintMessage(ex.Message + Environment.NewLine, ConsoleColor.Red);
                    i--;
                }
            }

            return circles;
        }

        /// <summary>
        /// Get random real number from interval.
        /// </summary>
        /// <returns> Random real number from interval </returns>
        private static double GetDoubleFromInterval() =>
            Min + Rnd.Next(Max - Min) * Rnd.NextDouble();

        ///<summary>
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
        /// Print info about circles.
        /// </summary>
        /// <param name="circles"> Array of circles </param>
        private static void PrintInfo(CircleS[] circles) =>
            Array.ForEach(circles, el => PrintMessage(
                $"{el}\nLength: {el.Length:0.####}\n" +
                "Distance from (0; 0): " +
                $"{el.Center.GetDistance(new PointS(0, 0)):0.####}\n\n",
                ConsoleColor.Yellow));

        /// <summary>
        /// Get array of distance from (0; 0).
        /// </summary>
        /// <param name="circles"> Array of circles </param>
        /// <returns> Array of distance from (0; 0) </returns>
        private static double[] GetKeys(IReadOnlyList<CircleS> circles)
        {
            var keys = new double[Amount];

            for (var i = 0; i < keys.Length; i++)
            {
                keys[i] = circles[i].Center.GetDistance(new PointS(0, 0));
            }

            return keys;
        }

        private static void Main()
        {
            do
            {
                Console.Clear();

                var circles = GetCircles();
                PrintInfo(circles);

                #region Sorting by length without keys.

                Array.Sort(circles);
                PrintMessage("After sorting by ascending of length:\n\n");
                PrintInfo(circles);

                #endregion

                #region Sorting by distance from (0; 0) with keys.

                var keys = GetKeys(circles);

                Array.Sort(keys, circles);

                PrintMessage("After sorting by ascending of distance from (0; 0):\n\n");
                PrintInfo(circles);

                #endregion

                PrintMessage("Press ESC for exit, press any other key to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key!=ConsoleKey.Escape);
        }
    }
}
