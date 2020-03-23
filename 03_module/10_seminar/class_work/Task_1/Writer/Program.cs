using System;
using System.IO;

namespace Writer
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

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}Numbers.dat";

            try
            {
                var binWriter = new BinaryWriter(new FileStream(path, FileMode.Create));

                // Print to file numbers {0, 2, 4, 6, 8, 10}.
                for (var i = 0; i <= 10; i += 2)
                {
                    binWriter.Write(i);
                }

                binWriter.Dispose();
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
