using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Security;

namespace Variant_2
{
    internal class Program
    {
        private static readonly Random Rnd = new Random(DateTime.Now.Millisecond);

        private const int MaxListLength = 10;
        private const int MinListLength = 5;

        internal const int MinClassesNumber = 2;
        internal const int MaxClassesNumber = 10;

        internal const int MinNameLength = 2;
        internal const int MaxNameLength = 12;

        private const string PathTeacher = "..//..//..//Teacher.bin";
        private const string PathStudents = "..//..//..//Students.json";

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
        /// Get random name.
        /// </summary>
        /// <returns> Name </returns>
        internal static string GetRandomName()
        {
            var length = Rnd.Next(MinNameLength, MaxNameLength + 1);

            var result = string.Empty;
            result += (char)Rnd.Next('А', 'Я' + 1);

            for (var i = 0; i < length - 1; i++)
            {
                result += (char)Rnd.Next('а', 'я' + 1);
            }

            return result;
        }

        /// <summary>
        /// Get list of students.
        /// </summary>
        /// <param name="teacher"> Teacher </param>
        /// <returns> List of students </returns>
        private static List<Student> GetStudents(Teacher teacher)
        {
            var students = new List<Student>();
            var length = Rnd.Next(MinListLength, MaxListLength + 1);

            for (var i = 0; i < length; i++)
            {
                try
                {
                    students.Add(new Student(GetRandomName(), GetRandomName(), teacher));
                }
                catch (ArgumentException)
                {
                    i--;
                }
            }

            return students;
        }

        /// <summary>
        /// Serialize students.
        /// </summary>
        /// <param name="students"> List of students </param>
        private static void SerializeStudents(IReadOnlyCollection<Student> students)
        {
            using (var fs = new FileStream(PathStudents, FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                var formatter = new DataContractJsonSerializer(typeof(List<Student>),
                    new[] { typeof(Teacher) });

                formatter.WriteObject(fs, students);
            }

            PrintMessage("Json serialization was successful\n\n", ConsoleColor.Yellow);
        }

        /// <summary>
        /// Serialize teacher.
        /// </summary>
        /// <param name="teacher"> Teacher </param>
        private static void SerializeTeacher(Teacher teacher)
        {
            using (var fs = new FileStream(PathTeacher, FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(fs, teacher);
            }

            PrintMessage("Binary serialization was successful\n\n", ConsoleColor.Yellow);
        }

        /// <summary>
        /// Serialize.
        /// </summary>
        /// <param name="teacher"> Teacher </param>
        /// <param name="students"> List of students </param>
        private static void Serialize(Teacher teacher, IReadOnlyCollection<Student> students)
        {
            try
            {
                SerializeStudents(students);
                SerializeTeacher(teacher);
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
        /// Deserialize students.
        /// </summary>
        private static void DeserializeStudents()
        {
            using (var fs = new FileStream(PathStudents, FileMode.Open,
                FileAccess.Read, FileShare.Read))
            {
                var formatter = new DataContractJsonSerializer(typeof(List<Student>),
                    new[] { typeof(Teacher) });

                var students = (List<Student>)formatter.ReadObject(fs);
                students.ForEach(s => PrintMessage($"{s}\n"));
            }

            PrintMessage("Json deserialization was successful\n\n", ConsoleColor.Yellow);
        }

        /// <summary>
        /// Deserialize teacher.
        /// </summary>
        private static void DeserializeTeacher()
        {
            using (var fs = new FileStream(PathTeacher, FileMode.Open,
                FileAccess.Read, FileShare.Read))
            {
                var formatter = new BinaryFormatter();

                var teacher = (Teacher)formatter.Deserialize(fs);
                PrintMessage($"{teacher}\n\n", ConsoleColor.Magenta);
            }

            PrintMessage("Binary deserialization was successful\n\n", ConsoleColor.Yellow);
        }

        /// <summary>
        /// Deserialize.
        /// </summary>
        private static void Deserialize()
        {
            try
            {
                DeserializeStudents();
                DeserializeTeacher();
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
        /// Get random classes number.
        /// </summary>
        /// <returns> Integer number </returns>
        private static int GetRandomClassesNumber() =>
            Rnd.Next(MinClassesNumber, MaxClassesNumber);

        private static void Main()
        {
            var teacher = new Teacher(GetRandomName(),
                GetRandomName(),
                GetRandomName(),
                GetRandomClassesNumber());

            List<Student> students = GetStudents(teacher);

            PrintMessage($"{teacher}\n\n", ConsoleColor.Magenta);
            students.ForEach(s => PrintMessage($"{s}\n"));

            Serialize(teacher, students);
            Deserialize();

            PrintMessage("Press ENTER to exit...", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Enter) ;
        }
    }
}
