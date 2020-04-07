using MyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security;

namespace JsonSerialization
{
    internal class Program
    {

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
        /// Serialize groups.
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <param name="groups"> Groups </param>
        private static void SerializeGroups(string path, IEnumerable<Group> groups)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var formatter = new DataContractJsonSerializer(typeof(List<Group>));
                //var formatter = new DataContract
                formatter.WriteObject(fs, groups);
            }

            PrintMessage("Serialization was successful!\n\n", ConsoleColor.Yellow);
        }

        /// <summary>
        /// Json serialization.
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <param name="groups"> Groups </param>
        private static void JsonSerialization(string path, IEnumerable<Group> groups)
        {
            try
            {
                SerializeGroups(path, groups);
            }
            catch (SerializationException ex)
            {
                PrintMessage($"Serialization error: {ex.Message}", ConsoleColor.Red);
            }
            catch (IOException ex)
            {
                PrintMessage($"Some problems with files: {ex.Message}", ConsoleColor.Red);
            }
            catch (SecurityException ex)
            {
                PrintMessage($"Access error {ex.Method}", ConsoleColor.Red);
            }
            catch (Exception ex)
            {
                PrintMessage($"Unexpected error: {ex.Message}", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Get list of groups.
        /// </summary>
        /// <returns> List of groups </returns>
        private static IEnumerable<Group> GetGroups()
        {
            var groups = new List<Group>();

            var studentList171 = new List<Student>
            {
                new Student("Ivanov", 17),
                new Student("Petrov", 16),
                new Student("Sidorov",18)
            };

            // Create first group.
            var groups171 = new Group("SE-171", studentList171);
            groups.Add(groups171);

            var studentList271 = new List<Student>
            {
                new Student("Yakovlev", 21),
                new Student("Yureva", 22),
                new Student("Enatov",23)
            };

            // Create second group.
            var groups271 = new Group("SE-271", studentList271);
            groups.Add(groups271);

            return groups;
        }

        /// <summary>
        /// Deserialize groups.
        /// </summary>
        /// <param name="path"> Path to file </param>
        private static void DeserializeGroups(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var formatter = new DataContractJsonSerializer(typeof(List<Group>));
                var groups = (List<Group>)formatter.ReadObject(fs);

                groups.ForEach(group => PrintMessage($"{group}\n"));

                PrintMessage("\nDeserialization was successful!", ConsoleColor.Yellow);
            }
        }

        /// <summary>
        /// Json deserialization.
        /// </summary>
        /// <param name="path"> Path to file </param>
        private static void JsonDeserialization(string path)
        {
            try
            {
                DeserializeGroups(path);
            }
            catch (SerializationException ex)
            {
                PrintMessage($"Serializable error: {ex.Message}", ConsoleColor.Red);
            }
            catch (IOException ex)
            {
                PrintMessage($"Some problems with file: {ex.Message}", ConsoleColor.Red);
            }
            catch (SecurityException ex)
            {
                PrintMessage($"Access error: {ex.Message}", ConsoleColor.Red);
            }
            catch (Exception ex)
            {
                PrintMessage($"Unexpected error: {ex.Message}", ConsoleColor.Red);
            }
        }
        private static void Main()
        {
            // Path to file.
            const string path = "groups.json";

            IEnumerable<Group> groups = GetGroups();

            JsonSerialization(path, groups);

            JsonDeserialization(path);

            PrintMessage("\n\nPress ENTER to exit...", ConsoleColor.Green);
            Console.ReadLine();
        }
    }
}
