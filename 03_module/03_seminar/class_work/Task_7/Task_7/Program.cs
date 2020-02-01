using System;
using System.Linq;

namespace Task_7
{
    internal class Program
    {
        // Variable for random
        private static readonly Random Rnd = new Random();

        /// <summary>
        /// Print color message.
        /// </summary>
        /// <param name="message"> Message </param>
        /// <param name="color"> Message's color </param>
        internal static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        private static void Main()
        {
            do
            {
                Console.Clear();

                // Как альтернатива, это можно было сделать через Array.ConvertAll.
                // Create and fill array.
                var arr = new int[19999].Select(el => Rnd.Next()).ToArray();

                var run = new Sorting(arr);
                var watch = new View();

                // Add methods to events.
                run.OnSort += Display.ShowBar;
                run.OnSort += watch.ShowN;

                // Begin sort.
                run.Sort();

                PrintMessage("\n\nPress ESC for exit, press any other key for repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
