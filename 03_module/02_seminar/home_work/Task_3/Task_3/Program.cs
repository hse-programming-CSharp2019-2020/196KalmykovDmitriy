using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        private static readonly Random Rnd = new Random();
        private const int SizeArr = 10;

        #region Consts for random.
        private const int MinValue = -3;
        private const int MaxValue = 3;
        #endregion

        /// <summary>
        /// Get double number from interval.
        /// </summary>
        /// <returns> Double number from interval </returns>
        private static double GetDoubleFromInterval() =>
            MinValue + double.Epsilon + Rnd.NextDouble() * (MaxValue - MinValue - double.Epsilon);

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
            do
            {
                Console.Clear();

                
                // Create A.
                var A = new double[SizeArr].Select(el => GetDoubleFromInterval()).ToArray();

                // Create B.
                var B = Array.ConvertAll(A, delegate (double el)
                {
                    return el >= 0 ? (int)el : 0;
                });

                PrintMessage("Массив А: ");
                Array.ForEach(A, el => Console.Write($"{el:0.##} "));
                Console.WriteLine();

                PrintMessage("Массив B: ");
                Array.ForEach(B, el => Console.Write(el + " "));
                Console.WriteLine();

                PrintMessage("Print ESC for exit, " +
                             "press any other any key for repeat solution", ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
