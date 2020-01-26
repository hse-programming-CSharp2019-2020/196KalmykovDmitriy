using System;
using System.Linq;

namespace Task_1
{
    internal class Program
    {
        #region Some consts.
        private const int SizeArr = 10;
        private const int Min = -15;
        private const int Max = 15;
        #endregion
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

        /// <summary>
        /// Print array.
        /// </summary>
        /// <param name="arr"> Array </param>
        /// <param name="message"> Help message </param>
        private static void PrintArray(int[] arr, string message)
        {
            PrintMessage(message);

            // Set text color.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Array.ForEach(arr, el => Console.Write($"{el,-4}"));
            Console.ResetColor();

            Console.WriteLine(Environment.NewLine);
        }

        private static void Main()
        {
            do
            {
                Console.Clear();
                // Как альтернатива, можно было написать отдельный метод,
                // в котором формировался массив с помощью цикла for.
                // Create array.
                var intsArr = new int[SizeArr].Select(el => Rnd.Next(Min + 1, Max)).ToArray();

                PrintArray(intsArr, "Generated array: ");

                // Sort the array.
                Array.Sort(intsArr, (x, y) => Math.Abs(x).CompareTo(Math.Abs(y)));

                PrintArray(intsArr, "Sorted array in ascending order of absolute values: ");

                PrintMessage("For exit press ESC, " +
                                  "for repeat solution - any other key", ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
