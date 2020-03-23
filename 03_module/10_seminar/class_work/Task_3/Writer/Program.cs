using System;
using System.IO;

namespace Writer
{
    internal class Program
    {
        private static readonly Random Rnd = new Random(DateTime.Now.Millisecond);
        private const int Min = 100;
        private const int Max = 1000;

        /// <summary>
        /// Get random real number from interval.
        /// </summary>
        /// <returns> Real number </returns>
        private static double GetDoubleFromInterval()
        {
            return Min + Rnd.Next(Max - Min) * Rnd.NextDouble();
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
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}Data.txt";

            try
            {
                // Print info to file.
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    var sw = new StreamWriter(fs);
                    Console.SetOut(sw);

                    for (var i = 0; i < 100; i++)
                    {
                        var number = GetDoubleFromInterval();
                        Console.WriteLine(number);
                    }

                    sw.Flush();
                }

                var stdOutPut = new StreamWriter(Console.OpenStandardOutput())
                {
                    AutoFlush = true
                };

                Console.SetOut(stdOutPut);
                Console.WriteLine("Data written successfully!\n");
            }
            catch (IOException)
            {
                PrintMessage("Problem with file!\n\n", ConsoleColor.Red);
            }
            catch (Exception)
            {
                PrintMessage("Unexpected error!\n\n", ConsoleColor.Red);
            }

            PrintMessage("Press ESC to exit...", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
