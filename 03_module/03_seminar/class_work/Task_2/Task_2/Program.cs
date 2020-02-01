using System;

namespace Task_2
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
            // Create class instances.
            var pub = new Publisher();
            var firstSub = new SomethingHappenedSubscriber();
            var secondSub = new SomethingHappenedSubscriber2();

            // Add method to the event.
            pub.SomethingHappened += firstSub.SomethingHappenedHandler;
            pub.SomethingHappened += secondSub.SomethingHappenedHandler;

            // Raise event.
            pub.FireEvent();

            PrintMessage("\nPress ESC for exit", ConsoleColor.Green);

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }
    }
}
