using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security;
using System.Threading;

namespace Task_4
{
    internal class Program
    {
        private const int ArrayLength = 100;
        private static readonly Random Rnd = new Random();

        /// <summary>
        /// Get random color.
        /// </summary>
        /// <returns> Random color </returns>
        private static ConsoleColor GetRandomColor() =>
                (ConsoleColor)Rnd.Next(Enum.GetNames(typeof(ConsoleColor)).Length);

        /// <summary>
        /// Get structs.
        /// </summary>
        /// <returns> Array of structs </returns>
        private static ConsoleSymbolStruct[] GetStructs()
        {
            var chars = new ConsoleSymbolStruct[ArrayLength];

            for (var i = 0; i < ArrayLength; i++)
            {
                chars[i] = new ConsoleSymbolStruct('*',
                    Rnd.Next(30), Rnd.Next(30));
            }

            return chars;
        }

        /// <summary>
        /// Get classes.
        /// </summary>
        /// <returns> Array of classes </returns>
        private static ConsoleSymbolClass[] GetClasses()
        {
            var chars = new ConsoleSymbolClass[ArrayLength];
            for (var i = 0; i < ArrayLength; i++)
            {
                chars[i] = new ConsoleSymbolClass('*',
                    Rnd.Next(30), Rnd.Next(30));
            }

            return chars;
        }

        /// <summary>
        /// Print structs.
        /// </summary>
        /// <param name="chars"> Array of structs </param>
        private static void PrintStructs(IReadOnlyList<ConsoleSymbolStruct> chars)
        {
            for (var i = 0; i < ArrayLength; i++)
            {
                Console.ForegroundColor = GetRandomColor();
                Console.SetCursorPosition(chars[i].X, chars[i].Y);
                Console.Write(chars[i].Symbol);
                Thread.Sleep(50); // using System.Threading;
            }
        }

        /// <summary>
        /// Print classes.
        /// </summary>
        /// <param name="chars"> Array of classes </param>
        private static void PrintClasses(IReadOnlyList<ConsoleSymbolClass> chars)
        {
            for (var i = 0; i < ArrayLength; i++)
            {
                Console.ForegroundColor = GetRandomColor();
                Console.SetCursorPosition(chars[i].X, chars[i].Y);
                Console.Write(chars[i].Symbol);
                Thread.Sleep(50); // using System.Threading;
            }
        }

        /// <summary>
        /// Serialize colors.
        /// </summary>
        /// <param name="myColors"> Colors </param>
        private static void SerializeColors(IEnumerable myColors)
        {
            using (var fs = new FileStream("test.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var formatter = new DataContractJsonSerializer(typeof(ConsoleSymbolStruct[]));

                formatter.WriteObject(fs, myColors);
            }
        }

        /// <summary>
        /// Json Serialize.
        /// </summary>
        /// <param name="structs"> Colors </param>
        private static void JsonSerialize(IEnumerable structs)
        {
            try
            {
                SerializeColors(structs);
            }
            catch (SerializationException ex)
            {
                PrintMessage($"Serialize error: {ex.Message}!\n", ConsoleColor.Red);
            }
            catch (IOException ex)
            {
                PrintMessage($"Problem with file: {ex.Message}!\n", ConsoleColor.Red);
            }
            catch (SecurityException ex)
            {
                PrintMessage($"Access error: {ex.Message}!\n", ConsoleColor.Red);
            }
            catch (Exception ex)
            {
                PrintMessage($"Unexpected error: {ex.Message}!\n", ConsoleColor.Red);
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


        private static void Main()
        {
            var dt = DateTime.Now;
            Console.WriteLine("\t\t\t\tStart of observation.");
            Console.WriteLine($"\t\t\t\t{dt};{dt.Millisecond} Milliseconds");

            ConsoleSymbolStruct[] chars = GetStructs();

            Console.WriteLine("\t\t\t\tEnd of observation.");
            dt = DateTime.Now;
            Console.WriteLine($"\t\t\t\t{dt};{dt.Millisecond} Milliseconds");

            PrintStructs(chars);

            dt = DateTime.Now;
            Console.WriteLine("\t\t\t\tStart of observation.");
            Console.WriteLine($"\t\t\t\t{dt};{dt.Millisecond} Milliseconds");

            ConsoleSymbolClass[] letters = GetClasses();

            Console.WriteLine("\t\t\t\tEnd of observation.");
            dt = DateTime.Now;
            Console.WriteLine($"\t\t\t\t{dt};{dt.Millisecond} Milliseconds");

            PrintClasses(letters);

            JsonSerialize(chars);
            Console.ReadLine();
        }
    }
}
