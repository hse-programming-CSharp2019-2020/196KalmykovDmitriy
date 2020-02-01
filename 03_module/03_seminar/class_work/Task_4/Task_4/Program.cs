using System;

namespace Task_4
{
    // Declare delegate.
    public delegate void NewStringValue(string s);

    internal class Program
    {
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
            var c = new ConsoleUI();

            // Start the execution of the class object ConsoleUI.
            c.CreateUI();

            do
            {
                // Get string from user.
                c.GetStringFromUI();

                PrintMessage("\nPress ESC for exit, press any other key for repeat solution\n\n",
                        ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}