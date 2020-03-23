using MyLib;
using System;
using System.Collections.Generic;
using System.IO;

namespace Reader
{
    internal class Program
    {
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

                    PrintMessage("Number must be > 1: ", ConsoleColor.Yellow);
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
        /// Get mass point.
        /// </summary>
        /// <param name="line"> Line </param>
        /// <returns> Mass point </returns>
        private static MassPoint GetMassPoint(string line)
        {
            var x = double.Parse(line.Substring(0, 3));
            var y = double.Parse(line.Substring(5, 5));
            var mass = double.Parse(line.Substring(10, 6));
            var massPoint = new MassPoint(new PointS(x, y), mass);

            return massPoint;
        }

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}MassPoints.bin";

            var elements = new List<MassPoint>();
            var radius = GetNumber<double>("Enter radius of set: ",
                el => el > 1);

            try
            {
                // Read info from file.
                using (var sr = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        MassPoint massPoint = GetMassPoint(line);

                        elements.Add(massPoint);
                    }
                }

                var real = new SetOfMassPoint(elements, new PointS(0, 0), radius);

                PrintMessage("\nSuitable points:\n\n", ConsoleColor.Green);
                PrintMessage(real.ToString(), ConsoleColor.Yellow);
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
