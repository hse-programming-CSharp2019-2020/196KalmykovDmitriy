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
            var path = $@"..{sep}..{sep}..{sep}Numbers.dat";

            try
            {
                var fileStream = new FileStream(path, FileMode.Open);
                var binWriter = new BinaryWriter(fileStream);
                var binReader = new BinaryReader(fileStream);

                // Length of stream.
                long fileStreamLength = fileStream.Length / 4;
                int number;

                PrintMessage("Number in file:\n\n", ConsoleColor.Yellow);
                for (var i = 0; i < fileStreamLength; i++)
                {
                    // Read number from file.
                    number = binReader.ReadInt32();
                    PrintMessage(number + " ");
                }

                PrintMessage("\n\nNumbers in reverse order:\n\n", ConsoleColor.Yellow);
                for (var i = 0; i < fileStreamLength; i++)
                {
                    fileStream.Seek(fileStream.Length - (i + 1) * 4, SeekOrigin.Begin);
                    number = binReader.ReadInt32();
                    PrintMessage(number + " ");
                }

                fileStream.Seek(0, SeekOrigin.Begin);
                for (var i = 0; i < fileStreamLength; i++)
                {
                    number = binReader.ReadInt32();
                    fileStream.Seek(i * 4, SeekOrigin.Begin);

                    // Print number to file.
                    binWriter.Write(number * 5);
                }

                PrintMessage("\n\nNumbers increased 5 times:\n\n", ConsoleColor.Yellow);
                for (var i = 0; i < fileStreamLength; i++)
                {
                    fileStream.Seek(fileStream.Length - (i + 1) * 4, SeekOrigin.Begin);

                    // Read number from file.
                    number = binReader.ReadInt32();
                    PrintMessage(number + " ");
                }

                binReader.Dispose();
                fileStream.Dispose();
                binWriter.Dispose();
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
