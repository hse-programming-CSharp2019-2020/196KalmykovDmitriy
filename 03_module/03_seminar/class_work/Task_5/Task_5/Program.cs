using System;

namespace Task_5
{
    internal class Program
    {
        // Variable for random.
        private static readonly Random Rnd = new Random();

        /// <summary>
        /// Create 2-dimensional array.
        /// </summary>
        /// <returns> Array </returns>
        private static int[,] GetIntsArr()
        {
            var arr = new int[15, 15];

            for (var i = 0; i < arr.GetUpperBound(0); i++)
                for (var j = 0; j < arr.GetUpperBound(1); j++)
                    arr[i, j] = Rnd.Next(100);

            return arr;
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

        private static void Main()
        {
            do
            {
                Console.Clear();

                var arr = GetIntsArr();

                // Set method to the event.
                Methods.LineComplete += Console.WriteLine;
                Methods.PrintArray(arr);

                // Remove method from event.
                Methods.LineComplete -= Console.WriteLine;

                PrintMessage("\nPress ESC for exit, press any other key for repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
