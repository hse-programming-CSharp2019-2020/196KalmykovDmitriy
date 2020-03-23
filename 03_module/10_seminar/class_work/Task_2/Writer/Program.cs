using System;
using System.IO;

namespace Writer
{
    internal class Program
    {
        private const int Amount = 10;
        private const int Min = 1;
        private const int Max = 100;
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

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}Numbers.bin";

            try
            {
                var fileStream = new FileStream(path, FileMode.Create);
                var binWriter = new BinaryWriter(fileStream);

                for (var i = 0; i < Amount; i++)
                {
                    int number = Rnd.Next(Min, Max + 1);

                    // Print info to file.
                    binWriter.Write(number);
                }

                PrintMessage("Numbers written successfully!", ConsoleColor.Yellow);
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
