using System;
using System.Collections.Generic;
using System.IO;

namespace Task_2
{
    internal class Program
    {
        private static readonly Random Rnd = new Random(DateTime.Now.Millisecond);
        private const int Min = 0;
        private const int Max = 1000;

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
        /// <param name="message"> Message </param>
        /// <param name="helpMessage"> Help message </param>
        /// <param name="conditions"> Conditions for number </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message, string helpMessage, Predicate<T> conditions)
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

                    PrintMessage(helpMessage, ConsoleColor.Yellow);
                }
                catch
                {
                    // Print error message.
                    PrintMessage("Wrong format of input data!\n", ConsoleColor.Red);

                    PrintMessage(message);
                }
            }
        }

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var generalPath = $@"..{sep}..{sep}..{sep}Numbers.txt";
            var pathSample = $@"..{sep}..{sep}..{sep}";

            var amount = GetNumber<int>("Enter amount of elements: ",
                "Numbers must be > 0: ", el => el > 0);

            try
            {
                // Print numbers to file.
                using (var sw = new StreamWriter(new FileStream(generalPath, FileMode.Create)))
                {
                    for (var i = 0; i < amount; i++)
                    {
                        int number = Rnd.Next(Min, Max + 1);
                        sw.WriteLine(number);
                    }
                }

                var m = GetNumber<int>($"Enter number (< {amount}): ",
                    $"Numbers must be in range [1 - {amount - 1}]: ",
                    el => (el > 0) && (el < amount));

                var numbers = new List<int>(amount);

                // Read number from file.
                using (var sr = new StreamReader(new FileStream(generalPath, FileMode.Open)))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        numbers.Add(int.Parse(line));
                    }
                }

                numbers.Sort();

                // Delete excess files.
                int fileIndex = 0;
                while (File.Exists(pathSample + fileIndex + ".txt"))
                {
                    File.Delete(pathSample + fileIndex + ".txt");
                    fileIndex++;
                }

                // Print info to different files.
                for (var i = 0; i < amount; i += m)
                {
                    var path = pathSample + i / m + ".txt";

                    using (var sw = new StreamWriter(new FileStream(path, FileMode.Create)))
                    {
                        try
                        {
                            for (var j = i; j < m + i; j++)
                            {
                                sw.WriteLine(numbers[j]);
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            PrintMessage("\nInformation written successfully!", ConsoleColor.Yellow);
                        }
                    }
                }

                PrintMessage("\nInformation written successfully!", ConsoleColor.Yellow);
            }
            catch (IOException)
            {
                PrintMessage("Problem with file!", ConsoleColor.Red);
            }
            catch (Exception)
            {
                PrintMessage("Unexpected error!", ConsoleColor.Red);
            }

            PrintMessage("\n\nPress ESC to exit...", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
