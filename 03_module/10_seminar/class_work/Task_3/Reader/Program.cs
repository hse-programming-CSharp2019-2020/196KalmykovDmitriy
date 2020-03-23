using System;
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

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}Data.txt";

            try
            {
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    var sr = new StreamReader(fs);
                    string line;

                    Console.SetIn(sr);
                    while ((line = Console.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

                var stdInPut = new StreamReader(Console.OpenStandardInput());
                Console.SetIn(stdInPut);
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