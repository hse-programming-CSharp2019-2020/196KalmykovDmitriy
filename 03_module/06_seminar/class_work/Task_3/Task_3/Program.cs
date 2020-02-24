using System;
using System.Collections.Generic;

namespace Task_3
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
        /// Print series from N members.
        /// </summary>
        /// <param name="amount"> Amount of members </param>
        /// <param name="series"> Series </param>
        private static void SeriesPrint(int amount, ISeries series)
        {
            for (var i = 0; i < amount; i++)
                PrintMessage(series.GetNext + "  ");

            Console.WriteLine("\n");
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
        /// Print info about series and their members.
        /// </summary>
        /// <param name="dict"> Dictionary(Name, Series) </param>
        /// <param name="amount"> Amount of members </param>
        private static void PrintInfo(Dictionary<string, ISeries> dict, int amount)
        {
            foreach (var pair in dict)
            {
                PrintMessage($"Sequence of {pair.Key}: ", ConsoleColor.Yellow);
                SeriesPrint(amount, pair.Value);
            }
        }

        private static void Main()
        {
            do
            {
                Console.Clear();

                var amount = GetNumber<int>("Enter amount of members in series: ",
                    el => el > 0);

                Console.WriteLine();

                // ALTERNATIVE: could use tuples, or auxiliary array.
                // Create dictionary.
                var dict = new Dictionary<string, ISeries>()
                {
                    {"Fibonacci", new Fibonacci()},
                    {"Pell", new Pell() },
                    {"Luke", new Luke() }
                };

                try
                {
                    PrintInfo(dict, amount);
                }
                catch (OutOfMemoryException)
                {
                    PrintMessage("Number was too big!\n", ConsoleColor.Red);
                    continue;
                }
                catch (OverflowException)
                {
                    PrintMessage("Number was too big!\n", ConsoleColor.Red);
                    continue;
                }

                PrintMessage("Press ESC for exit, press any other key to continue",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
