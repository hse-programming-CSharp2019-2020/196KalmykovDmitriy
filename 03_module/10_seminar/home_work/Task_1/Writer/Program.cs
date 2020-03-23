using System;
using System.IO;

namespace Writer
{
    internal class Program
    {
        private static readonly Random Rnd = new Random(DateTime.Now.Millisecond);
        private const int Min = 10;
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

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}Text.txt";

            try
            {
                using (var sw = new StreamWriter(new FileStream(path, FileMode.Create)))
                {
                    int length = Rnd.Next(Min, Max);

                    for (var i = 0; i < length; i++)
                    {
                        if (i % 30 == 0 && i != 0)
                        {
                            sw.WriteLine();
                        }

                        sw.Write((char)Rnd.Next('А', 'я' + 1));
                    }
                }
            }
            catch (IOException)
            {
                PrintMessage("Problem with file!\n\n", ConsoleColor.Red);
            }
            catch (Exception)
            {
                PrintMessage("Unexpected error!\n\n", ConsoleColor.Red);
            }

            PrintMessage("Press ESC to exit", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
