using System;
using System.IO;
using System.Linq;

namespace ReaderAndWriter
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
            var pathForReading = $@"..{sep}..{sep}..{sep}Text.txt";
            var pathForWriting = $@"..{sep}..{sep}..{sep}Statistics.txt";
            var fs = new FileStream(pathForReading, FileMode.Open);
            var arr = new int[32];

            try
            {
                using (var sr = new StreamReader(fs))
                {
                    for (var i = 0; i < fs.Length; i++)
                    {
                        int letterIndex = sr.Read();

                        if (letterIndex < 1000)
                        {
                            continue;
                        }

                        try
                        {
                            arr[letterIndex - 1040]++;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            arr[letterIndex - 1072]++;
                        }
                    }
                }

                double amount = arr.Sum();

                using (var sw = new StreamWriter(new FileStream(pathForWriting, FileMode.Create)))
                {
                    for (var i = 0; i < 31; i++)
                    {
                        sw.WriteLine($"{(char)(i + 1072)} - {arr[i] * 100 / amount:f3}");
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
