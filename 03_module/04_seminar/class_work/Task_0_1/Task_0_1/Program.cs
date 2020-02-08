using System;

namespace Task_0_1
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

        /// <summary>
        /// Start callback.
        /// </summary>
        /// <param name="message"> Message </param>
        private static void StartOutputCallBack(string message) =>
            Console.WriteLine("StartOutputCallBack - " + message);

        /// <summary>
        /// End callback.
        /// </summary>
        /// <param name="message"> Message </param>
        private static void EndOutputCallBack(string message) =>
            Console.WriteLine("EndOutputCallBack - " + message);

        private static void Main()
        {
            var publisher = new Publisher();

            // Subscribe methods to event.
            publisher.BeginOutput += StartOutputCallBack;
            publisher.EndOutput += EndOutputCallBack;

            publisher.Display("I am a subscriber!");

            // Unsubscribe methods from event.
            publisher.BeginOutput -= StartOutputCallBack;
            publisher.EndOutput -= EndOutputCallBack;

            publisher.Display("\nI am not a subscriber!");

            PrintMessage("\nPrint ESC for exit", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }
    }
}
