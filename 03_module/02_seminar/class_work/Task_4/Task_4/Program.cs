using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        /// <summary>
        /// По возрастанию.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int AscendingSort(int x, int y) =>
             x.CompareTo(y);

        private static int DescendingSort(int x, int y) =>
            y.CompareTo(x);

        /// <summary>
        /// По чётности
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int ParitySort(int x, int y)
        {
            if (x % 2 == 0 && y % 2 == 1)
                return 1;

            if (x % 2 == 0 && y % 2 == 0)
                return 0;

            return -1;
        }

        private static int OddSort(int x, int y)
        {
            if (x % 2 == 1 && y % 2 == 0)
                return 1;

            if (x % 2 == 1 && y % 2 == 1)
                return 0;

            return -1;
        }

        private static void PrintArray(Series series)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in series.arrInts)
                Console.Write(item + " ");

            Console.ResetColor();
            Console.WriteLine();
        }

        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        private static void PrintSortedArrays(Series series)
        {
            Comparison<int>[] typesOfSort =
            {
                AscendingSort,
                DescendingSort,
                ParitySort,
                OddSort
            };

            string[] messages =
            {
                "Отсортированный по возрастанию: ",
                "Отсортированный по убыванию: ",
                "Отсортированный по чётности: ",
                "Отсортированный по нечётности: "
            };

            for (int i = 0; i < 4; i++)
            {
                PrintMessage(messages[i]);
                series.Order(typesOfSort[i]);
                PrintArray(series);
            }
        }

        static void Main(string[] args)
        {
            var series = new Series { arrInts = new[] { 5, 3, 1, 42, 21, 6, 8, 42, 27, 13 } };

            PrintMessage("Исходный массив: ");
            PrintArray(series);
            Console.WriteLine();

            PrintSortedArrays(series);

        }
    }
}