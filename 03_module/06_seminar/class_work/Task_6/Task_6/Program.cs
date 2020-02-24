using MyLib;
using System;

namespace Task_6
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
            var func = new RealSearch(3, 3.28, 0.001);

            try
            {
                // Print info.
                PrintMessage($"Root of Sin (x) = {func.RootSearch():G4}\n");
                PrintMessage($"Amount of iterations = {func.IterationQuantity}\n");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                PrintMessage(ex.Message + "\n", ConsoleColor.Red);
            }

            PrintMessage("Press ESC for exit", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
