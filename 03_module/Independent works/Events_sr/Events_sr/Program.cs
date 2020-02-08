using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_sr
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
            do
            {

                Console.Clear();

                PrintMessage("\nPress ESC for exit, press any other key for repeat solution",
                ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
