using System;
using System.IO;
using System.Security;

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

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}Test.txt";

            // Check file for existence.
            if (!File.Exists(path))
            {
                PrintMessage("File not found!\n", ConsoleColor.Red);

                PrintMessage("\nPress ESC to exit...", ConsoleColor.Green);
                while (Console.ReadKey().Key != ConsoleKey.Escape) ;

                return;
            }

            try
            {
                using (var fileStream = new FileStream(path, FileMode.Open))
                {
                    // Numeric value of byte read.
                    int numericValue;

                    // Byte position in the stream.
                    int bytePosition = 0;

                    while ((numericValue = fileStream.ReadByte()) != -1)
                    {
                        if (numericValue >= '0' && numericValue <= '9')
                        {
                            PrintMessage($"Numeric value:{numericValue}," +
                                         $" digit: {(char) numericValue}, position in stream {bytePosition}\n");
                        }

                        bytePosition++;
                    }
                }
            }
            catch (IOException)
            {
                PrintMessage("Problem with file!\n", ConsoleColor.Red);
            }
            catch (SecurityException)
            {
                PrintMessage("Access error!\n", ConsoleColor.Red);
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
