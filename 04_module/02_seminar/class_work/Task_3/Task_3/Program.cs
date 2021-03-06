﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security;

namespace Task_3
{
    internal class Program
    {
        /// <summary>
        /// Get array of colors.
        /// </summary>
        /// <param name="lines"> lines from file </param>
        /// <returns> Array of colors </returns>
        private static MyColor[] GetArray(IReadOnlyList<string> lines)
        {
            var myColors = new MyColor[lines.Count - 2];

            for (var i = 1; i < lines.Count - 1; i++)
            {
                var colorName = lines[i].Split(':')[0];

                var index = lines[i].IndexOf('#');
                var colorR = lines[i].Substring(index + 1, 2);
                var colorG = lines[i].Substring(index + 3, 2);
                var colorB = lines[i].Substring(index + 5, 2);

                myColors[i - 1] = new MyColor
                (
                    colorName,
                    Convert.ToByte(colorR, 16),
                    Convert.ToByte(colorG, 16),
                    Convert.ToByte(colorB, 16)
                );
            }

            return myColors;
        }

        /// <summary>
        /// Serialize colors.
        /// </summary>
        /// <param name="myColors"> Colors </param>
        private static void SerializeColors(IEnumerable myColors)
        {
            using (var fs = new FileStream("test.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var formatter = new DataContractJsonSerializer(typeof(MyColor[]));

                formatter.WriteObject(fs, myColors);
            }
        }

        /// <summary>
        /// Json Serialize.
        /// </summary>
        /// <param name="myColors"> Colors </param>
        private static void JsonSerialize(IEnumerable myColors)
        {
            try
            {
                SerializeColors(myColors);
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
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}css-color-names.json";

            var lines = File.ReadAllLines(path);

            var myColors = GetArray(lines);

            JsonSerialize(myColors);

            foreach (var color in myColors)
            {
                Enum.TryParse(color.ColorName, out ConsoleColor consoleColor);
                PrintMessage(color.ColorName, consoleColor);
            }

            PrintMessage("\nPress ENTER to exit...", ConsoleColor.Green);
            Console.ReadLine();
        }
    }
}
