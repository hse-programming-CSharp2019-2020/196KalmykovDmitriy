using System;
using System.IO;
using System.Runtime.Serialization;
using System.Security;
using System.Xml.Serialization;

namespace Variant_1
{
    internal class Program
    {
        private static readonly Random Rnd = new Random(DateTime.Now.Millisecond);

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
        /// Serialize Student.
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <param name="student"> Student </param>
        private static void SerializeStudent(string path, Student student)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var formatter = new XmlSerializer(typeof(Student), new[]
                {
                    typeof(ControlElement),
                    typeof(Contest),
                    typeof(ControlWork)
                });

                formatter.Serialize(fs, student);
            }

            PrintMessage("\nSerialization was successful!\n\n", ConsoleColor.Yellow);
        }

        /// <summary>
        /// serialization.
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <param name="student"> Student </param>
        private static void XmlSerialization(string path, Student student)
        {
            try
            {
                SerializeStudent(path, student);
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
        /// Deserialize.
        /// </summary>
        /// <param name="path"> Path to file </param>
        private static void Deserialize(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var formatter = new XmlSerializer(typeof(Student), new[]
                {
                    typeof(ControlElement),
                    typeof(Contest),
                    typeof(ControlWork)
                });

                var data = (Student)formatter.Deserialize(fs);

                PrintMessage(data.ToString());
            }

            PrintMessage("\nDeserialization was successful!\n\n", ConsoleColor.Yellow);
        }

        /// <summary>
        /// Deserialization.
        /// </summary>
        /// <param name="path"> Path to file </param>
        private static void XmlDeserialization(string path)
        {
            try
            {
                Deserialize(path);
            }
            catch (SerializationException ex)
            {
                PrintMessage($"Deserialization error: {ex.Message}", ConsoleColor.Red);
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
        /// Get random name.
        /// </summary>
        /// <returns> Name </returns>
        internal static string GetRandomName()
        {
            var length = Rnd.Next(2, 13);

            var result = string.Empty;
            result += (char)Rnd.Next('А', 'Я' + 1);

            for (var i = 0; i < length - 1; i++)
            {
                result += (char)Rnd.Next('а', 'я' + 1);
            }

            return result;
        }

        /// <summary>
        /// Get student.
        /// </summary>
        /// <returns> Student </returns>
        private static Student GetStudent()
        {
            var student = new Student();

            for (var i = 0; i < 1; i++)
            {
                try
                {
                    student = new Student(GetRandomName(), GetRandomName());
                }
                catch (ArgumentException)
                {
                    i--;
                }
            }

            return student;
        }

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $"..{sep}..{sep}..{sep}Student.xml";

            var student = GetStudent();

            PrintMessage(student.ToString());

            XmlSerialization(path, student);
            XmlDeserialization(path);

            PrintMessage("Press ENTER to exit...", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Enter) ;
        }
    }
}
