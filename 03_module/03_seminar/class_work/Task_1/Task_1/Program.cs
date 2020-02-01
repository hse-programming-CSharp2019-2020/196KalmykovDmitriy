using System;

namespace Task_1
{
    /// <summary>
    /// Event delegate.
    /// </summary>
    public delegate void Del();
    internal class Program
    {
        // Event.
        public static event Del Ev;

        /// <summary>
        /// Print "f1".
        /// </summary>
        private static void F1() =>
            PrintMessage("f1");

        /// <summary>
        /// Print "f2".
        /// </summary>
        private static void F2() =>
            PrintMessage("f2");

        /// <summary>
        /// Print "f3".
        /// </summary>
        private static void F3() =>
            PrintMessage("f3");

        /// <summary>
        /// Print color message.
        /// </summary>
        /// <param name="message"> Message </param>
        /// <param name="color"> Message's color </param>
        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void Main()
        {
            // Add handlers.
            Ev += F1;
            Ev += F2;
            Ev += F3;

            // Raise event.
            Ev?.Invoke();

            PrintMessage("\nPress ESC for exit", ConsoleColor.Green);

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }
    }
}
