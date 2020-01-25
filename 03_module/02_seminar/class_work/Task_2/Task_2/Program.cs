using System;

namespace Task_2
{
    class Program
    {
        /// <summary>
        /// Method for print notification.
        /// </summary>
        /// <param name="message"> Notification </param>
        public static void OnCarEngineEvent(string message)
        {
            PrintMessage("\n***** Сообщение от объекта типа Car *****\n");
            PrintMessage($"=> {message}\n", ConsoleColor.Yellow);
        }

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

        static void Main(string[] args)
        {
            // Print caption.
            PrintMessage("***** Использование делегатов для управления событиями *****\n",
                ConsoleColor.Yellow);

            // Create new car.
            var c1 = new Car("SlugBug", 100, 10);

            // Method for notifications.
            c1.RegisterWithCarEngine(OnCarEngineEvent);
            
            // Increase speed.
            Console.WriteLine("***** Увеличиваем скорость *****");
            for (int i = 0; i < 6; i++)
                c1.Accelerate(20);

            PrintMessage("\nPress ESC for exit", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}