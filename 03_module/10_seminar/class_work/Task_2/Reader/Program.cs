using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            PrintMessage(message, ConsoleColor.Magenta);

            while (true)
            {
                try
                {
                    // Attempt to convert input string to required type.
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    // Check extra conditions.
                    if (conditions(result))
                        return result;

                    PrintMessage("Number must be int range [1-100]: ", ConsoleColor.Yellow);
                }
                catch
                {
                    // Print error message.
                    PrintMessage("Wrong format of input data!\n", ConsoleColor.Red);

                    PrintMessage(message, ConsoleColor.Magenta);
                }
            }
        }

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}Numbers.bin";

            try
            {
                var fileStream = new FileStream(path, FileMode.Open);
                var binWriter = new BinaryWriter(fileStream);
                var binReader = new BinaryReader(fileStream);

                fileStream.Seek(0, SeekOrigin.Begin);

                long fileStreamLength = fileStream.Length / 4;
                var numbers = new List<int>();

                PrintMessage("Numbers in file:\n\n", ConsoleColor.Yellow);
                for (var i = 0; i < fileStreamLength; i++)
                {
                    var number = binReader.ReadInt32();
                    PrintMessage(number + " ");
                    numbers.Add(number);
                }

                Console.WriteLine("\n");

                // Number from user.
                var n = GetNumber<int>("Enter number in range [1-100]: ",
                    el => (el > 0) && (el < 101));

                int delta = numbers.ConvertAll(el => Math.Abs(el - n)).Min();

                // Find the closest numbers.
                fileStream.Seek(0, SeekOrigin.Begin);
                for (var i = 0; i < fileStreamLength; i++)
                {
                    var number = binReader.ReadInt32();

                    if (Math.Abs(number - n) != delta)
                    {
                        continue;
                    }

                    fileStream.Seek(-4, SeekOrigin.Current);
                    binWriter.Write(n);
                }

                fileStream.Seek(0, SeekOrigin.Begin);
                PrintMessage("\nNumbers in file:\n\n", ConsoleColor.Yellow);
                for (var i = 0; i < fileStreamLength; i++)
                {
                    var number = binReader.ReadInt32();
                    PrintMessage(number + " ");
                    numbers.Add(number);
                }
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
