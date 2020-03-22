using MyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;

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

        // ALTERNATIVE: could use common TryParse.

        /// <summary>
        /// Get number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Message </param>
        /// <param name="conditions"> Conditions </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message, Predicate<T> conditions)
        {
            PrintMessage(message);

            while (true)
            {
                try
                {
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    if (conditions(result))
                    {
                        return result;
                    }

                    PrintMessage("Number must be > 0: ", ConsoleColor.Yellow);
                }
                catch
                {
                    PrintMessage("Wring format of input data!\n", ConsoleColor.Red);

                    PrintMessage(message);
                }
            }
        }

        /// <summary>
        /// Get point.
        /// </summary>
        /// <returns> Color point </returns>
        private static ColorPoint GetPoint()
        {
            var point = new ColorPoint
            {
                X = Rnd.NextDouble(),
                Y = Rnd.NextDouble()
            };

            int typeColorIndex = Rnd.Next(0, ColorPoint.Colors.Count);
            point.Color = ColorPoint.Colors[typeColorIndex];

            return point;
        }

        /// <summary>
        /// Get points.
        /// </summary>
        /// <param name="amount"> amount of points </param>
        /// <returns> List of points </returns>
        private static IEnumerable<ColorPoint> GetPoints(int amount)
        {
            var points = new List<ColorPoint>();

            for (var i = 0; i < amount; i++)
            {
                ColorPoint point = GetPoint();

                points.Add(point);
            }

            return points;
        }

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}MyTest.txt";

            var amount = GetNumber<int>("Enter amount of elements: ",
                el => el > 0);

            IEnumerable<ColorPoint> points = GetPoints(amount);

            string[] infoAboutPoints = points.Select(el => el.ToString()).ToArray();

            try
            {
                // Print info to file.
                File.WriteAllLines(path, infoAboutPoints);
            }
            catch (IOException)
            {
                PrintMessage("Problem with file!", ConsoleColor.Red);
            }
            catch (SecurityException)
            {
                PrintMessage("Access error!", ConsoleColor.Red);
            }
            catch (Exception)
            {
                PrintMessage("Unexpected error!", ConsoleColor.Red);
            }

            PrintMessage($"\nThe {amount} lines are written to the text file: \n{path}", 
                ConsoleColor.Yellow);

            PrintMessage("\n\nPress ESC to exit...", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
