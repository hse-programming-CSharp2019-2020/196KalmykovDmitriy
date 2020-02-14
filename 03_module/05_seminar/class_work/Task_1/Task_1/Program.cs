using MyLib;
using System;
using System.Collections.Generic;

namespace Task_1
{
    internal class Program
    {
        /// <summary>
        /// Get number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="conditions"> Conditions for number </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message, Predicate<T> conditions = null)
        {
            PrintMessage(message);

            while (true)
            {
                try
                {
                    // attempt to convert string to required type.
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    // If there are no extra conditions
                    if (conditions is null)
                        return result;

                    if (conditions(result))
                        return result;

                    PrintMessage("Radius must be > 0: ", ConsoleColor.Yellow);
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
        /// Get list from circles.
        /// </summary>
        /// <returns> List from circles </returns>
        private static List<Circle> GetCircles()
        {
            var circles = new List<Circle>();

            do
            {
                Console.Clear();

                // Get data for 1 circle.
                var x = GetNumber<double>("Enter X coordinate: ");
                var y = GetNumber<double>("Enter Y coordinate: ");
                var radius = GetNumber<double>("Enter radius: ", el => el > 0);
                var circle = new Circle(radius, x, y);

                PrintMessage($"\nNew circle added:\n{circle}\n", ConsoleColor.Magenta);

                // Add new circle to list.
                circles.Add(circle);

                PrintMessage("Press ESC to stop input, press any other key to continue",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            return circles;
        }

        private static void Main()
        {
            do
            {
                var circles = GetCircles();

                Console.Clear();

                // List sort.
                circles.Sort((x, y) => x > y ? 1 : x < y ? -1 : 0);

                PrintMessage("Sorted list:\n\n", ConsoleColor.Yellow);

                // Print list.
                circles.ForEach(el => PrintMessage(el + Environment.NewLine));

                PrintMessage("Press ESC for exit, press any other key for repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}