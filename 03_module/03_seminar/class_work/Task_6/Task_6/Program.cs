﻿using System;

namespace Task_6
{
    internal class Program
    {
        // Counter of filled elements.
        private static int _counter;

        private static int _max;

        /// <summary>
        /// Get average of array.
        /// </summary>
        /// <param name="arr"> Array </param>
        /// <returns> Average </returns>
        private static double GetAverage(int[,] arr)
        {
            _counter++;

            double sum = 0;

            // Find sum.
            for (var i = 0; i <= arr.GetUpperBound(0); i++)
                for (var j = 0; j <= arr.GetUpperBound(1); j++)
                    sum += arr[i, j];

            return sum / _counter;
        }

        /// <summary>
        /// Find max in array.
        /// </summary>
        /// <param name="arr"> Array </param>
        /// <returns> Max in array </returns>
        internal static int FindMax(int[,] arr)
        {
            _max = -1;

            // Find max.
            for (var i = 0; i <= arr.GetUpperBound(0); i++)
                for (var j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    if (arr[i, j] > _max)
                       _max = arr[i, j];
                }

            return _max;
        }

        /// <summary>
        /// Print color message.
        /// </summary>
        /// <param name="message"> Message </param>
        /// <param name="color"> Message's color </param>
        internal static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Set methods to events.
        /// </summary>
        public static void SetMethodsToEvents()
        {
            Methods.LineComplete += Console.WriteLine;

            Methods.NewItemFilled += Methods.ArraySumCount;

            Methods.NewItemFilled += array =>
                PrintMessage($"Average of array: {GetAverage(array):0.###}\n",
                    ConsoleColor.Yellow);

            Methods.NewItemFilled += array =>
            {
                PrintMessage(
                    _max < FindMax(array)
                        ? $"Max element in array: {FindMax(array)}\n\n"
                        : "Maximum doesn't change\n\n",
                    ConsoleColor.Green);
            };
        }

        private static void Main()
        {
            SetMethodsToEvents();

            // Repeat solution.
            do
            {
                _max = 0;
                var arr = new int[15, 15];
                Console.Clear();

                Methods.FillArray(arr);
                Methods.PrintArray(arr);

                PrintMessage("\nPress ESC for exit, press any other key for repeat decision",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
