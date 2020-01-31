using System;
using System.Linq;

namespace Task_2
{
    internal class Program
    {
        #region Consts for random.
        private const int Min = 0;
        private const int Max = 20;
        #endregion

        private const int SizeArr = 10;
        private static readonly Random Rnd = new Random();


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

                // Как альтернатива, можно было написать отдельный метод,
                // в котором формировался массив с помощью цикла for.
                // Create array.
                var A = new int[SizeArr].Select(el => Rnd.Next(Min + 1, Max)).ToArray();

                // Print A.
                PrintMessage("First array: ");
                foreach (var item in A)
                    Console.Write(item + " ");

                Console.WriteLine();

                // Create array.
                var B = Array.ConvertAll(A, x => 1.0 / x);

                // Print B.
                PrintMessage("Second Array: ");
                foreach (var item in B)
                    Console.Write($"{item:0.##} ");

                Console.WriteLine();

                PrintMessage("\nPress ESC for exit, " +
                                  "press any other key for repeat solution", ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
