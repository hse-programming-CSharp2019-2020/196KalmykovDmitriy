using MyLib;
using System;
using System.Collections.Generic;
using System.IO;

namespace Writer
{
    internal class Program
    {
        private static readonly Random Rnd = new Random(DateTime.Now.Millisecond);

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
        /// Get number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="conditions"> Conditions for number </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message, Predicate<T> conditions)
        {
            PrintMessage(message);

            while (true)
            {
                try
                {
                    // Attempt to convert input string to required type.
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    // Check extra conditions.
                    if (conditions(result))
                        return result;

                    PrintMessage("Number must be > 0: ", ConsoleColor.Yellow);
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
        /// Get points.
        /// </summary>
        /// <param name="amount"> Amount of points </param>
        /// <returns> List of points </returns>
        private static List<MassPoint> GetPoints(int amount)
        {
            Console.WriteLine();

            var massPoints = new List<MassPoint>(amount);

            for (var i = 0; i < amount; i++)
            {
                var point = new PointS(Rnd.Next(-10, 11), Rnd.Next(-10, 11));
                massPoints.Add(new MassPoint(point, Rnd.Next(1, 6)));
                PrintMessage(massPoints[i] + Environment.NewLine, ConsoleColor.Yellow);
            }

            return massPoints;
        }

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}MassPoints.bin";

            // Amount of points.
            var amount = GetNumber<int>("Enter amount of points: ",
                el => el > 0);

            List<MassPoint> massPoints = GetPoints(amount);

            try
            {
                // Print to file.
                using (var sw = new StreamWriter(new FileStream(path, FileMode.Create)))
                {
                    // 4 4 6.
                    massPoints.ForEach(el =>
                        sw.WriteLine($"{el.Center.X}    " +
                                     $"{el.Center.Y}    {el.Mass}      "));
                }
            }
            catch (IOException)
            {
                PrintMessage("Problem with file!\n", ConsoleColor.Red);
            }
            catch (Exception)
            {
                PrintMessage("Unexpected error!\n", ConsoleColor.Red);
            }

            PrintMessage("\nPress ESC to exit...", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
