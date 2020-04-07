using MyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;

namespace BinarySerialization
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
        /// Get university.
        /// </summary>
        /// <returns> University </returns>
        private static University GetUniversity()
        {
            var hse = new University
            {
                UniversityName = "NRU HSE"
            };

            var deptStaff = new List<Human>
            {
                new Professor("Ivanov"),
                new Professor("Petrov")
            };

            var se = new Dept("SE", deptStaff);

            hse.Departments = new List<Dept>
            {
                se
            };

            return hse;
        }

        /// <summary>
        /// Deserialize university.
        /// </summary>
        /// <param name="path"> Path to file </param>
        private static void DeserializeUniversity(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var formatter = new BinaryFormatter();

                var university = (University)formatter.Deserialize(fs);

                foreach (var dept in university.Departments)
                {
                    foreach (var human in dept.Staff.OfType<Professor>())
                    {
                        PrintMessage($"{dept.DeptName} prof: {human.Name}\n");
                    }
                }
            }

            PrintMessage("\nDeserialization was successful!", ConsoleColor.Yellow);
        }

        /// <summary>
        /// Binary deserialization.
        /// </summary>
        /// <param name="path"> Path to file </param>
        private static void BinaryDeserialization(string path)
        {
            try
            {
                DeserializeUniversity(path);
            }
            catch (SerializationException ex)
            {
                PrintMessage($"Serialization error: {ex.Message}", ConsoleColor.Red);
            }
            catch (IOException ex)
            {
                PrintMessage($"Some problem with file: {ex.Message}", ConsoleColor.Red);
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

        /// <summary>
        /// Binary serialization.
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <param name="university"> University </param>
        private static void BinarySerialization(string path, University university)
        {
            try
            {
                SerializeUniversity(path, university);
            }
            catch (SerializationException ex)
            {
                PrintMessage($"Serialization error: {ex.Message}", ConsoleColor.Red);
            }
            catch (IOException ex)
            {
                PrintMessage($"Some problem with file: {ex.Message}", ConsoleColor.Red);
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

        /// <summary>
        /// Serialize university.
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <param name="university"> University </param>
        private static void SerializeUniversity(string path, University university)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(fs, university);
            }

            PrintMessage("Serialization was successful!\n\n", ConsoleColor.Yellow);
        }

        private static void Main()
        {
            // Path to file.
            const string path = "university.bin";

            University hse = GetUniversity();

            BinarySerialization(path, hse);

            BinaryDeserialization(path);

            PrintMessage("\n\nPress ENTER to exit...", ConsoleColor.Green);
            Console.ReadLine();
        }
    }
}
