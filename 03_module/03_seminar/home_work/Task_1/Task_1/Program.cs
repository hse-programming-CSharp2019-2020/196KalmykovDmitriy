using MyLib;
using System;

namespace Task_1
{
    internal class Program
    {
        /// <summary>
        /// Print coordinates of dot A.
        /// </summary>
        /// <param name="A"> Dot </param>
        private static void PrintInfo(Dot A)
        {
            PrintMessage($"X-coord: {A.X:0.###}\n");
            PrintMessage($"Y-coord: {A.Y:0.###}\n\n");
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

        // Как вариант, можно было написать обычный TryParse.
        /// <summary>
        /// Get number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message) where T : new()
        {
            Console.Write(message);

            while (true)
            {
                try
                {
                    // Trying to convert the entered string to the required type.
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    return result;
                }
                catch
                {
                    // Print error message.
                    PrintMessage("Wrong format of data entry!\n", ConsoleColor.Red);

                    Console.Write(message);
                }
            }
        }

        private static void Main()
        {
            do
            {
                Console.Clear();

                // Get x and y.
                var x = GetNumber<double>("Input X: ");
                var y = GetNumber<double>("Input Y: ");
                Console.WriteLine();

                // Create new dot.
                var D = new Dot(x, y);

                D.OnCoordChanged += PrintInfo;
                D.DotFlow();

                PrintMessage("Press ESC for exit, press any other key for repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
