using MyLib;
using System;

namespace Task_2
{
    internal class Program
    {
        // ALTERNATIVE: could use common TryParse.

        /// <summary>
        /// Get Number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="cond"> Conditions for number </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message, Predicate<T> cond = null)
        {
            PrintMessage(message);

            while (true)
            {
                try
                {
                    // Attempt to convert string to required type.
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    if (cond is null)
                        return result;

                    // Check extra conditions.
                    if (cond(result))
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

        private static void Main()
        {
            do
            {
                Console.Clear();

                // Create new dot.
                var dot = new Dot(
                    GetNumber<double>("Enter X coordinate: "),
                    GetNumber<double>("Enter Y coordinate: "));

                // Get radius.
                var radius = GetNumber<double>("Enter radius: ", el => el > 0);
                Console.WriteLine();

                // Create new circle.
                var circle = new Circle(dot, radius);

                // Subscribe method to event.
                circle.XHasChangedEvent += delegate
                {
                    PrintMessage($"\nMin X coordinate: {circle.GetMinX()}\n" +
                                 $"Max X coordinate: {circle.GetMaxX()}\n\n", ConsoleColor.Yellow);
                };

                // Get new X.
                var newX = GetNumber<double>("Enter new X coordinate of center of circle: ");

                circle.ChangeXcoord(newX);

                PrintMessage("Press ESC for exit, press any other key to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
