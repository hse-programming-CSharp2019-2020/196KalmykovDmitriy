﻿using MyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;

namespace BinarySerialization
{
    internal class Program
    {
        private static readonly Random Rnd = new Random(DateTime.Now.Millisecond);
        private const int MinNumber = 0;
        private const int MaxNumber = 100;

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
        /// Get number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Message </param>
        /// <param name="helpMessage"> Help message </param>
        /// <param name="conditions"> Conditions for number </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message, string helpMessage, Predicate<T> conditions)
        {
            PrintMessage(message);

            while (true)
            {
                try
                {
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    if (conditions(result))
                    {
                        return result;
                    }

                    PrintMessage(helpMessage, ConsoleColor.Yellow);
                }
                catch (Exception)
                {
                    PrintMessage("Wrong format of input data!\n", ConsoleColor.Red);

                    PrintMessage(message);
                }
            }
        }

        /// <summary>
        /// Get list of numbers.
        /// </summary>
        /// <param name="size"> amount of numbers </param>
        /// <returns> List of numbers </returns>
        private static List<int> GetNumbers(int size)
        {
            var numbers = new List<int>(size);

            Console.WriteLine();

            for (var i = 0; i < size; i++)
            {
                var number = Rnd.Next(MinNumber, MaxNumber);
                numbers.Add(number);
                PrintMessage(numbers[i] + " ", ConsoleColor.Green);
            }

            return numbers;
        }

        /// <summary>
        /// Get multiple.
        /// </summary>
        /// <param name="numbers"> list of numbers </param>
        /// <returns> Multiple </returns>
        private static Multiple GetMultiple(List<int> numbers)
        {
            var divisor = GetNumber<int>("\nEnter divisor: ",
                "Divisor must be in range [1; 9]: ",
                number => (number > 0) && (number < 10));

            var row = new Multiple(divisor, numbers);
            return row;
        }

        /// <summary>
        /// Serialize multiple.
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <param name="numbers"> List of numbers </param>
        private static void SerializeMultiple(string path, List<int> numbers)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var formatter = new BinaryFormatter();

                do
                {
                    var row = GetMultiple(numbers);

                    formatter.Serialize(fs, row);

                    PrintMessage("\nPress ESC to reading from file, " +
                                      "press any other key to enter one more divisor...\n",
                        ConsoleColor.Green);
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
        }

        /// <summary>
        /// Binary serialization.
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <param name="numbers"> List of numbers </param>
        private static void BinarySerialization(string path, List<int> numbers)
        {
            try
            {
                SerializeMultiple(path, numbers);
            }
            catch (SerializationException ex)
            {
                PrintMessage($"Serialization error: {ex.Message}", ConsoleColor.Red);
            }
            catch (IOException ex)
            {
                PrintMessage($"Problem with file: {ex.Message}", ConsoleColor.Red);
            }
            catch (SecurityException ex)
            {
                PrintMessage($"Access error: {ex.Method}", ConsoleColor.Red);
            }
            catch (Exception ex)
            {
                PrintMessage($"Unexpected error: {ex.Message}", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Deserialize multiple.
        /// </summary>
        /// <param name="path"> Path to file </param>
        private static void DeserializeMultiple(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var formatter = new BinaryFormatter();

                Console.WriteLine();

                while (true)
                {
                    try
                    {
                        var row = (Multiple)formatter.Deserialize(fs);

                        PrintMessage($"{row}\n");
                    }
                    catch (SerializationException)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Binary deserialization.
        /// </summary>
        /// <param name="path"> Path to file </param>
        private static void BinaryDeserialization(string path)
        {
            try
            {
                DeserializeMultiple(path);
            }
            catch (SerializationException ex)
            {
                PrintMessage($"Serialization error: {ex.Message}", ConsoleColor.Red);
            }
            catch (IOException ex)
            {
                PrintMessage($"Problem with file: {ex.Message}", ConsoleColor.Red);
            }
            catch (SecurityException ex)
            {
                PrintMessage($"Access error: {ex.Method}", ConsoleColor.Red);
            }
            catch (Exception ex)
            {
                PrintMessage($"Unexpected error: {ex.Message}", ConsoleColor.Red);
            }
        }

        private static void Main()
        {
            const string path = "bytes.bin";

            var size = GetNumber<int>("Enter amount of numbers: ",
                "Number must be positive: ", number => number > 0);

            List<int> numbers = GetNumbers(size);

            Console.WriteLine();

            BinarySerialization(path, numbers);

            BinaryDeserialization(path);

            PrintMessage("Press ENTER to exit...", ConsoleColor.Green);
            Console.ReadLine();
        }
    }
}