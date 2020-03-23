using MyLib;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReaderAndWriter
{
    internal class Program
    {
        /// <summary>
        /// Get block.
        /// </summary>
        /// <param name="line"> Line with info about block </param>
        /// <returns> Block3D </returns>
        private static Block3D GetBlock(string line)
        {
            var height = double.Parse(line.Substring(14, 6));
            var baseHeight = double.Parse(line.Substring(30, 6));
            var baseWidth = double.Parse(line.Substring(41, 6));
            var block = new Block3D(height, baseHeight, baseWidth);

            return block;
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

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}Blocks.txt";
            var blocks = new List<Block3D>();

            try
            {
                // Read from file.
                using (var sr = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Block3D block = GetBlock(line);

                        blocks.Add(block);
                    }
                }

                // Print info.
                blocks.ForEach(el => PrintMessage(el + "\n"));
                blocks.Sort();
                PrintMessage("\nSorted by volume:\n\n", ConsoleColor.Yellow);
                blocks.ForEach(el => PrintMessage(el + "\n"));

                // Print to file.
                using (var sw = new StreamWriter(new FileStream(path, FileMode.Open)))
                {
                    blocks.ForEach(el => sw.WriteLine(el));
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
