using System;

namespace Task_0_2
{
    internal class EventGuide2
    {
        /// <summary>
        /// Print color message.
        /// </summary>
        /// <param name="message"> Message </param>
        /// <param name="color"> Message's color </param>
        internal static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            // Check message for q.
            if (message?.Trim() != "q")
            {
                Console.ForegroundColor = color;
                Console.Write("You typed: " + message + "\n\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("You typed: \'q\' to quit");
                Console.ResetColor();
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        private static void Main()
        {
            var input = new Input();
            input.GetUserInput();
        }
    }
}
