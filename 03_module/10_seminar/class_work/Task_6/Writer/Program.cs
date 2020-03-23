using MyLib;
using System;
using System.Collections.Generic;
using System.IO;

namespace Writer
{
    internal class Program
    {
        private static readonly Random Rnd = new Random(DateTime.Now.Millisecond);
        private const int Min = 10;
        private const int Max = 30;

        /// <summary>
        /// Get real number from interval.
        /// </summary>
        /// <returns> Real number </returns>
        private static double GetDoubleFromInterval()
        {
            return Min + Rnd.NextDouble() * Rnd.Next(Max - Min);
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
        /// Get block.
        /// </summary>
        /// <returns> BLock3D </returns>
        private static Block3D GetBlock()
        {
            var height = GetDoubleFromInterval();
            var baseHeight = GetDoubleFromInterval();
            var baseWidth = GetDoubleFromInterval();
            var block = new Block3D(height, baseHeight, baseWidth);

            return block;
        }

        /// <summary>
        /// Get blocks.
        /// </summary>
        /// <param name="amount"> Amount of blocks </param>
        /// <returns> List of blocks </returns>
        private static List<Block3D> GetBlocks(int amount)
        {
            var blocks = new List<Block3D>(amount);

            for (var i = 0; i < amount; i++)
            {
                Block3D block = GetBlock();

                blocks.Add(block);
            }

            return blocks;
        }

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}Blocks.txt";

            var amount = GetNumber<int>("Enter amount of blocks: ",
                el => el > 0);

            List<Block3D> blocks = GetBlocks(amount);

            try
            {
                using (var sw = new StreamWriter(new FileStream(path, FileMode.Create)))
                {
                    blocks.ForEach(el => sw.WriteLine(el));
                }
            }
            catch (IOException)
            {
                PrintMessage("Problem with file\n", ConsoleColor.Red);
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
