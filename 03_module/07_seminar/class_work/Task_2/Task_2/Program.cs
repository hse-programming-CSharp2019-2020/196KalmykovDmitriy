using System;
using System.Collections.Generic;

namespace Task_2
{
    internal class Program
    {
        private static readonly Random Rnd = new Random();

        #region Consts.

        private const int Min = -10;
        private const int Max = 10;
        private const int Amount = 20;

        #endregion

        /// <summary>
        /// Get random real number from interval.
        /// </summary>
        /// <returns> Real number </returns>
        private static double GetRandomFromInterval() =>
            Min + Rnd.NextDouble() * Rnd.Next(Max - Min);

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
        /// Get corner.
        /// </summary>
        /// <returns> Coordinates of corner </returns>
        private static Coords GetCorner()
        {
            var x = GetRandomFromInterval();
            var y = GetRandomFromInterval();

            return new Coords(x, y);
        }

        /// <summary>
        /// Get list from rectangles.
        /// </summary>
        /// <returns> List from rectangles </returns>
        private static List<Rectangle> GetRectangles()
        {
            var rectangles = new List<Rectangle>(Amount);

            for (var i = 0; i < Amount; i++)
            {
                var upperLeftCorner = GetCorner();
                var lowerRightCorner = GetCorner();

                // Attempt to create rectangle.
                try
                {
                    var rectangle = new Rectangle(upperLeftCorner, lowerRightCorner);

                    rectangles.Add(rectangle);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    PrintMessage(ex.Message + Environment.NewLine, ConsoleColor.Red);
                    i--;
                }
            }

            return rectangles;
        }

        /// <summary>
        /// Print info about rectangles.
        /// </summary>
        /// <param name="rectangles"> List from rectangles </param>
        private static void PrintInfo(List<Rectangle> rectangles) =>
            rectangles.ForEach(el => PrintMessage(el.ToString(),
                ConsoleColor.Yellow));


        private static void Main()
        {
            do
            {
                Console.Clear();

                #region Test circle.

                //var circle1 = new Circle(1, 2, 3);
                //PrintMessage(circle1.ToString());

                //var circle2 = new Circle(new Coords(2, 4), 3);
                //PrintMessage(circle2.ToString());

                #endregion

                var rectangles = GetRectangles();

                PrintInfo(rectangles);

                rectangles.Sort();

                PrintMessage("After sorting by area:\n\n");
                PrintInfo(rectangles);

                PrintMessage("Press ESC to exit, press any other key to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
