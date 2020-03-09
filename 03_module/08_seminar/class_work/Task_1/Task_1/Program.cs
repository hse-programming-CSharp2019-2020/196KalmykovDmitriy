using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1
{
    internal class Program
    {
        private static readonly Random Rnd = new Random();

        #region Consts.

        private const int Amount = 4;
        private const int Min = -10;
        private const int Max = 10;

        #endregion

        /// <summary>
        /// Get random real number from interval.
        /// </summary>
        /// <returns> Real number </returns>
        private static float GetRandomFloatFromInterval() =>
           (float)(Min + Rnd.NextDouble() * Rnd.Next(Max - Min));

        /// <summary>
        /// Get list of points.
        /// </summary>
        /// <returns> List of points </returns>
        private static List<Point<float>> GetPoints()
        {
            var points = new List<Point<float>>();

            for (var i = 0; i < Amount; i++)
            {
                var x = GetRandomFloatFromInterval();
                var y = GetRandomFloatFromInterval();
                var point = new Point<float>(x, y);

                points.Add(point);
            }

            return points;
        }

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
        /// Print info about points.
        /// </summary>
        /// <param name="points"></param>
        private static void PrintInfo(List<Point<float>> points) =>
            points.ForEach(el => PrintMessage(el.ToString()));

        /// <summary>
        /// Get maximum among 2 points.
        /// </summary>
        /// <param name="point1"> First point </param>
        /// <param name="point2"> Second point </param>
        /// <returns> The farthest point from (0; 0) </returns>
        internal static T GetMaximum<T>(T point1, T point2)
        where T : IComparable<T>
        {
            return point1.CompareTo(point2) > 0 ? point1 : point2;
        }

        private static void Main()
        {
            #region Test method GetMaximum().

            //var p = 'e';
            //var q = 'z';

            //Console.WriteLine($"Maximum(p, q) = {GetMaximum(p, q)}");
            //Console.WriteLine($"Maximum(3, 8) = {GetMaximum(3, 8)}");
            //Console.WriteLine($"Maximum(abcd, 1234) = {GetMaximum("abcd", "1234")}");
            //Console.WriteLine($"Maximum(5L, 2L) = {GetMaximum(5L, 2L)}");

            #endregion

            do
            {
                Console.Clear();

                var points = GetPoints();

                PrintInfo(points);

                // ALTERNATIVE: Could we use common 'for' loop.

                var max = points.Aggregate(new Point<float>(0, 0), 
                    (current, res) => GetMaximum(res, current));

                PrintMessage($"Farthest point:\n\n{max}", ConsoleColor.Magenta);

                PrintMessage("Press ESC to exit, press any other key to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
