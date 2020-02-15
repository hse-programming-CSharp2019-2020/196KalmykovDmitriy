using System;
using System.Collections.Generic;

namespace Task_3
{
    internal class Program
    {
        private static readonly Random Rnd = new Random();

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

        // ALTERNATIVE: could use common TryParse.

        /// <summary>
        /// Get amount of cones.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="cond"> Conditions for number </param>
        /// <returns> Amount of cones </returns>
        private static T GetNumber<T>(string message, Predicate<T> cond)
        {
            PrintMessage(message);

            while (true)
            {
                try
                {
                    // Attempt to transform string to required type.
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    // Check extra conditions for number.
                    if (cond(result))
                        return result;

                    PrintMessage("Amount must be > 0: ", ConsoleColor.Yellow);
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
        /// Get random cone.
        /// </summary>
        /// <returns> Cone </returns>
        private static StraightCone GetRandomCone()
        {
            // Coordinates for vertex of cone.
            var vertexX = Rnd.Next(-10, 10) * Rnd.NextDouble();
            var vertexY = Rnd.Next(-10, 10) * Rnd.NextDouble();
            var vertexZ = Rnd.Next(-10, 10) * Rnd.NextDouble();

            var vertex = new Point(vertexX, vertexY, vertexZ);

            var x = Rnd.Next(-10, 10) * Rnd.NextDouble();
            var y = Rnd.Next(-10, 10) * Rnd.NextDouble();
            var z = Rnd.Next(-10, 10) * Rnd.NextDouble();
            var radius = Rnd.Next(1, 20) * Rnd.NextDouble() + double.Epsilon;

            return new StraightCone(x, y, z, radius, vertex);
        }

        /// <summary>
        /// Get list from cones.
        /// </summary>
        /// <param name="amount"> Amount of cones </param>
        /// <returns> List from cones </returns>
        private static List<StraightCone> GetCones(int amount)
        {
            var cones = new List<StraightCone>(amount);

            // Add cones.
            for (var i = 0; i < amount; i++)
                cones.Add(GetRandomCone());

            // Just print empty string.
            Console.WriteLine();

            return cones;
        }

        private static void Main()
        {
            do
            {
                Console.Clear();

                // Amount of cones.
                var amount = GetNumber<int>("Enter amount of cones: ",
                    el => el > 0);

                // Get list from cones.
                var cones = GetCones(amount);

                // Print list.
                cones.ForEach(el => PrintMessage(el + Environment.NewLine,
                    ConsoleColor.Magenta));

                PrintMessage("Press ESC for exit, press any other key to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
