﻿using System;
using System.Linq;

namespace Task_5
{

    namespace Task_5
    {
        class Program
        {
            private const int sizeArr = 5;

            /// <summary>
            /// Method for get number.
            /// </summary>
            /// <typeparam name="T"> Type of number </typeparam>
            /// <param name="message"> Help message </param>
            /// <returns> Number </returns>
            private static T GetNumber<T>(string message) where T : new()
            {
                Console.Write(message);

                while (true)
                {
                    try
                    {
                        // Attempt to get result.
                        var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                        return result;
                    }
                    catch
                    {
                        // Print error message.
                        PrintMessage("Wrong input format!\n", ConsoleColor.Red);

                        Console.Write(message);
                    }
                }
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

            /// <summary>
            /// Print color array.
            /// </summary>
            /// <param name="arr"></param>
            private static void PrintArray(double[] arr)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Array.ForEach(arr, el => Console.Write($"{el:0.####} "));
                Console.ResetColor();
            }

            static void Main(string[] args)
            {
                do
                {
                    Console.Clear();

                    double maxAbsoluteValueInArr = 0;

                    var arr = new double[sizeArr];

                    PrintMessage("Fill the array with real numbers from 5 elements:\n");

                    // Fill array.
                    for (int i = 0; i < sizeArr; i++)
                        arr[i] = GetNumber<double>($"arr[{i}] = ");

                    PrintMessage("\nВведённый массив: ");
                    PrintArray(arr);
                    Console.WriteLine();


                    // Find max.
                    // If there are several maximums,
                    // then the first one is selected from the beginning array.
                    Array.ForEach(arr, el =>
                    {
                        if (Math.Abs(el) > Math.Abs(maxAbsoluteValueInArr))
                            maxAbsoluteValueInArr = el;
                    });

                    // Check special case.
                    if (maxAbsoluteValueInArr == 0)
                    {
                        PrintMessage("Max element of array = 0, " +
                                     "normalize impossible! \n", ConsoleColor.Red);
                        PrintMessage("\nPress ESC for exit, " +
                                          "for repeat solution - any other key", ConsoleColor.Green);
                        continue;
                    }

                    // Как вариант, это можно было написать через Linq: arr.Select(el=>el/max);
                    // Normalize array.
                    arr = Array.ConvertAll(arr, el => el / maxAbsoluteValueInArr);

                    PrintMessage("Array after normalize: ");
                    PrintArray(arr);

                    PrintMessage("\n\nPress ESC for exit, " +
                        "for repeat solution - any other key", ConsoleColor.Green);
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
        }
    }
}