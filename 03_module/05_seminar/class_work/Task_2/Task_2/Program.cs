using Figures;
using System;
using System.Collections.Generic;
namespace Task_2
{
    internal class Program
    {
        /// <summary>
        /// Fill lists from coordinates.
        /// </summary>
        /// <param name="xList"> List from X coordinates </param>
        /// <param name="yList"> List from Y coordinates </param>
        private static void FillListsFromCoord(IList<double> xList, IList<double> yList)
        {
            var helpMessages = new List<string>
            {
                "first", "second", "third"
            };

            // Fill lists.
            for (var i = 0; i < 3; i++)
            {
                xList.Add(GetNumber<double>(
                    $"Enter X coord of {helpMessages[i]} point: "));

                yList.Add(GetNumber<double>(
                    $"Enter Y coord of {helpMessages[i]} point: "));

                PrintMessage($"\nNew point added:\nX: {xList[i]}\nY: {yList[i]}\n\n",
                    ConsoleColor.Yellow);
            }

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

        // ALTERNATIVE: we can use common TryParse.

        /// <summary>
        /// Get number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <returns></returns>
        private static T GetNumber<T>(string message)
        {
            PrintMessage(message);

            while (true)
            {
                try
                {
                    // Attempt to convert entered string to required type.
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    return result;
                }
                catch
                {
                    // Print error message.
                    PrintMessage("Wrong format of input data!\n", ConsoleColor.Red);
                    PrintMessage(message);
                }
            }
        }

        /// <summary>
        /// Test points for belong to triangle.
        /// </summary>
        /// <param name="triangle"> Triangle </param>
        private static void TestPoint(TriangleComp triangle)
        {
            // Create new point.
            var point = new Point(
                GetNumber<double>("Enter X: "),
                GetNumber<double>("Enter Y: "));

            // Print message about her location relative triangle.
            PrintMessage(triangle.IsBelongToTriangle(point)
                ? "\nPoint belongs to triangle!\n\n"
                : "\nPoint doesn't belong to triangle!\n\n", ConsoleColor.Yellow);
        }

        /// <summary>
        /// Get triangle.
        /// </summary>
        /// <returns> Triangle </returns>
        private static TriangleComp GetTriangle()
        {
            // Create new lists from coordinates.
            var xList = new List<double>(3);
            var yList = new List<double>(3);

            FillListsFromCoord(xList, yList);

            // Create triangle.
            var triangle = new TriangleComp(xList, yList);

            PrintMessage($"Square of triangle: {triangle.Square:0.###}\n\n", ConsoleColor.Yellow);

            return triangle;
        }

        private static void Main()
        {
            do
            {
                TriangleComp triangle;

                Console.Clear();

                try
                {
                    // Attempt to get triangle.
                    triangle = GetTriangle();
                }
                catch (ArgumentException ex)
                {
                    PrintMessage(ex.Message + Environment.NewLine, ConsoleColor.Red);
                    continue;
                }

                PrintMessage("Press ENTER to continue", ConsoleColor.Green);

                while (Console.ReadKey().Key != ConsoleKey.Enter) ;

                do
                {
                    Console.Clear();

                    PrintMessage("Enter the coordinates of the point to check:\n\n",
                        ConsoleColor.Yellow);

                    TestPoint(triangle);

                    PrintMessage("Press ENTER to continue, press any other key to check new point\n\n",
                        ConsoleColor.Green);

                } while (Console.ReadKey().Key != ConsoleKey.Enter);

                PrintMessage("Press ESC for exit, press any other key to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
