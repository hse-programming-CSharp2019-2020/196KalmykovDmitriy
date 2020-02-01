using MyLib;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task_2
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
        /// Print info about changes.
        /// </summary>
        /// <param name="A"> Difference </param>
        private static void SquareConsoleInfo(double A)
        {
            var change = Math.Round(A, 2, MidpointRounding.AwayFromZero);
            PrintMessage("Change of size: ");
            PrintMessage((change > 0 ? "+" : "") + change + "\n");
        }

        /// <summary>
        /// Get Point.
        /// </summary>
        /// <param name="message"> Help message </param>
        /// <returns> Tuple </returns>
        private static (double, double) GetPoint(string message)
        {
            Console.Write(message);

            // Patterns for string.
            var reg1 = new Regex(
                @"^\(\-{0,1}[1-9]+[0-9|,]*; \-{0,1}[1-9]+[0-9|,]*\)", RegexOptions.Compiled);
            var reg2 = new Regex(@"^\(0{1}; \-{0,1}[1-9]+[0-9|,]*\)", RegexOptions.Compiled);
            var reg3 = new Regex(@"^\(\-{0,1}[1-9]+[0-9|,]*; 0{1}\)", RegexOptions.Compiled);

            while (true)
            {
                try
                {
                    var tempStr = Console.ReadLine();

                    // Check string for format.
                    if (!reg1.IsMatch(tempStr) && !reg2.IsMatch(tempStr) &&
                                 tempStr != "(0; 0)" && !reg3.IsMatch(tempStr))
                        throw new Exception();

                    // Take 2 substrings from string.
                    var x = new string(tempStr.Skip(1).TakeWhile(el => el != ';').ToArray());
                    var y = new string(tempStr.SkipWhile(el => el != ' ').Skip(1).
                        TakeWhile(el => el != ')').ToArray());

                    // Attempt to transform result to tuple<double, double>.
                    var result = (double.Parse(x), double.Parse(y));
                    return result;
                }
                catch
                {
                    PrintMessage("Wrong format of input data!\n", ConsoleColor.Red);
                    Console.Write(message);
                }
            }
        }

        private static void Main()
        {
            Square S;
            do
            {
                Console.Clear();
                PrintMessage("Input format: (x; y)\n", ConsoleColor.Magenta);
                // Get 2 corner.
                var leftUpCorner = GetPoint("Input left upper corner: ");
                var rightDownCorner = GetPoint("Input right down corner: ");

                try
                {
                    // Create new square.
                    S = new Square(leftUpCorner, rightDownCorner);
                    S.OnSizeChanged += SquareConsoleInfo;
                }
                catch (IndexOutOfRangeException ex)
                {
                    // Print error message.
                    PrintMessage(ex.Message + Environment.NewLine, ConsoleColor.Red);
                    PrintMessage("\nPress ESC for exit, press any other key for repeat solution",
                        ConsoleColor.Green);
                    continue;
                }

                PrintMessage("\nTest has begun!\n" +
                             "You have 3 attempt to change square\n", ConsoleColor.Yellow);

                // Test.
                for (var i = 0; i < 3; i++)
                    try
                    {
                        S.RightDownCorner = GetPoint("Input right down corner: ");
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        PrintMessage(ex.Message + Environment.NewLine, ConsoleColor.Red);
                        i--;
                    }

                PrintMessage("\nPress ESC for exit, press any other key f or repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}