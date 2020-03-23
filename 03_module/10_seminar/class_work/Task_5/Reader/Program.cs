using MyLIb;
using System;
using System.IO;

namespace Reader
{
    internal class Program
    {
        private const int Amount = 7;

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
            var path = $@"..{sep}..{sep}..{sep}Structs.txt";

            try
            {
                var fs = new FileStream(path, FileMode.Open);
                var binReader = new BinaryReader(fs);
                var symbols = new ConsoleSymbolStruct[Amount];

                for (var i = 0; i < Amount; i++)
                {
                    var x = binReader.ReadInt32();
                    var y = binReader.ReadInt32();
                    var symbol = binReader.ReadChar();

                    symbols[i] = new ConsoleSymbolStruct(symbol, x, y);
                }

                for (var i = 0; i < Amount; i++)
                {
                    PrintMessage($"Symbol: {symbols[i].Symbol}:  ({symbols[i].X}, {symbols[i].Y})\n");
                }
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