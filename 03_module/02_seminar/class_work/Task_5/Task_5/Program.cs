using System;

namespace Task_5
{

    namespace Task_5
    {
        internal class Program
        {
            private const int SizeArr = 5;

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

            /// <summary>
            /// Find max absolute value in array.
            /// </summary>
            /// <param name="numbers"> Array </param>
            /// <returns> Max absolute value </returns>
            private static double GetMax(double[] numbers)
            {
                double maxAbsoluteValueInArr = 0;

                Array.ForEach(numbers, el =>
                {
                    if (Math.Abs(el) > Math.Abs(maxAbsoluteValueInArr))
                        maxAbsoluteValueInArr = el;
                });

                return maxAbsoluteValueInArr;
            }

            /// <summary>
            /// Check number for zero.
            /// </summary>
            /// <param name="maxAbsoluteValueInArr"> Max </param>
            /// <returns> True or false </returns>
            private static bool MaximumIsZero(double maxAbsoluteValueInArr)
            {
                if (!(Math.Abs(maxAbsoluteValueInArr) < double.Epsilon)) 
                    return false;

                PrintMessage("Max element of array = 0, " +
                             "normalize impossible! \n", ConsoleColor.Red);
                PrintMessage("\nPress ESC for exit, " +
                             "for repeat solution - any other key", ConsoleColor.Green);

                return true;

            }

            private static void Main()
            {
                do
                {
                    Console.Clear();

                    // Number's array.
                    var numbers = new double[SizeArr];

                    PrintMessage("Fill the array with real numbers from 5 elements:\n");

                    // Fill array.
                    for (var i = 0; i < SizeArr; i++)
                        numbers[i] = GetNumber<double>($"arr[{i}] = ");

                    // Max absolute value in array.
                    // If there are several maximums,
                    // then the first one is selected from the beginning array.
                    var maxAbsoluteValueInArr = GetMax(numbers);

                    PrintMessage("\nEntered array: ");
                    PrintArray(numbers);
                    Console.WriteLine();

                    // Check special case.
                    if (MaximumIsZero(maxAbsoluteValueInArr))
                        continue;

                    // Как вариант, это можно было написать через Linq: arr.Select(el=>el/max).ToArray();
                    // Normalize array.
                    numbers = Array.ConvertAll(numbers, el => el / maxAbsoluteValueInArr);

                    PrintMessage("Array after normalize: ");
                    PrintArray(numbers);

                    PrintMessage("\n\nPress ESC for exit, " +
                        "for repeat solution - any other key", ConsoleColor.Green);
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
        }
    }
}