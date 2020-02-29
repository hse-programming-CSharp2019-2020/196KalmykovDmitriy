using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Task_1
{
    internal class Program
    {
        private static readonly Stopwatch Sw = new Stopwatch();
        private static readonly Random Rnd = new Random();
        private const int N = 100000;

        /// <summary>
        /// Print current time.
        /// </summary>
        /// <param name="timeSpan"> Time interval </param>
        /// <param name="message"> Message </param>
        public static void PrintTime(TimeSpan timeSpan, string message)
        {
            PrintMessage($"{message} time\n");

            var elapsedTime =
                $"{timeSpan.Hours:00}:{timeSpan.Minutes:00}:" +
                $"{timeSpan.Seconds:00}.{timeSpan.Milliseconds / 10:00}";

            PrintMessage($"RunTime {elapsedTime}\n\n",
                ConsoleColor.Yellow);
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

        // ALTERNATIVE: could implement 2 separate methods.

        /// <summary>
        /// Get arrays from class objects and structs.
        /// </summary>
        /// <returns></returns>
        private static (TestClass[], TestStruct[]) GetArrays()
        {
            var classes = new TestClass[N];
            var structs = new TestStruct[N];

            for (var i = 0; i < N; i++)
            {
                classes[i] = new TestClass();
                var tmp = Rnd.Next();
                classes[i].X = tmp;
                structs[i].X = tmp;
            }

            return (classes, structs);
        }

        /// <summary>
        /// Sorts the array and prints the time of sorting.
        /// </summary>
        /// <typeparam name="T"> Type of array </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="array"> Array </param>
        private static void SortArray<T>(string message, List<T> array)
        {
            Sw.Start();
            array.Sort();
            Sw.Stop();
            PrintTime(Sw.Elapsed, message);
        }

        private static void Main()
        {
            do
            {
                Sw.Reset();
                Console.Clear();

                // Get arrays from classes and structs.
                var (classes, structs) = GetArrays();

                // Sorting array of struct.
                SortArray("Struct", structs.ToList());

                // Sorting array of class objects. 
                SortArray("Class", classes.ToList());

                PrintMessage("Press ESC to exit, press any other key to test again",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
