using MyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;

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

        /// <summary>
        /// Print additional info.
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <param name="amount"> Amount of lines in file </param>
        /// <param name="timer"> Timer </param>
        private static void PrintAdditionalInfo(string path, int amount, Stopwatch timer)
        {
            PrintMessage("\nAdditional information:\n\n", ConsoleColor.Yellow);
            PrintMessage($"Read {amount} lines from file {path}\n");
            PrintMessage("Method: StreamWriter.ReadLine \r\n");
            PrintMessage($"Time of processing: {timer.Elapsed}\n");
            PrintMessage($"Time in milliseconds: {timer.ElapsedMilliseconds}");
        }

        /// <summary>
        /// Print statistics.
        /// </summary>
        /// <param name="pointsIdenticalColor"> Array of list of points wit same color </param>
        private static void PrintStatistics(IReadOnlyList<List<ColorPoint>> pointsIdenticalColor)
        {
            PrintMessage("\nColor statistics:\n\n", ConsoleColor.Yellow);

            for (var i = 0; i < ColorPoint.Colors.Count; i++)
            {
                PrintMessage($"{ColorPoint.Colors[i]} - {pointsIdenticalColor[i].Count}\n");
            }
        }

        /// <summary>
        /// Get point.
        /// </summary>
        /// <param name="line"> Line for processing </param>
        /// <returns> ColorPoint </returns>
        private static ColorPoint GetPoint(string line)
        {
            string[] colorPointData = line.Split();

            var x = Convert.ToDouble(colorPointData[0]);
            var y = Convert.ToDouble(colorPointData[1]);
            string color = colorPointData[2];

            // Create new point.
            var colorPoint = new ColorPoint
            {
                X = x,
                Y = y,
                Color = color
            };

            return colorPoint;
        }

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}MyTest.txt";
            int amountOfLines = 0;
            var timer = new Stopwatch();
            timer.Start();

            var pointsIdenticalColor = new List<ColorPoint>[ColorPoint.Colors.Count];
            pointsIdenticalColor = Array.ConvertAll(pointsIdenticalColor,
                el => new List<ColorPoint>());

            if (!File.Exists(path))
            {
                PrintMessage($"File \"{path}\" not found!", ConsoleColor.Red);
                PrintMessage("\n\nPress ESC to exit...", ConsoleColor.Green);
                while (Console.ReadKey().Key != ConsoleKey.Escape) ;

                return;
            }

            PrintMessage("Points:\n\n", ConsoleColor.Yellow);

            // Attempt to read info from file.
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string newLine;

                    while ((newLine = sr.ReadLine()) != null)
                    {
                        amountOfLines++;

                        // Processing new line.
                        ColorPoint colorPoint = GetPoint(newLine);
                        PrintMessage(colorPoint + Environment.NewLine);

                        int colorIndex = ColorPoint.Colors
                            .First(el => el.Value == colorPoint.Color).Key;

                        pointsIdenticalColor[colorIndex].Add(colorPoint);
                    }
                }
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

            PrintStatistics(pointsIdenticalColor);

            timer.Stop();
            PrintAdditionalInfo(path, amountOfLines, timer);

            PrintMessage("\n\nPress ESC to exit...", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}