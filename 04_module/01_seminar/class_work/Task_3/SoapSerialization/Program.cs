using MyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security;

namespace SoapSerialization
{
    internal class Program
    {
        private static readonly Random Rnd = new Random(DateTime.Now.Millisecond);
        private const int Min = -10;
        private const int Max = 11;

        /// <summary>
        /// Get equation.
        /// </summary>
        /// <returns> Quadratic </returns>
        private static Quadratic GetEquation()
        {
            var a = Rnd.Next(Min, Max);
            var b = Rnd.Next(Min, Max);
            var c = Rnd.Next(Min, Max);

            return new Quadratic(a, b, c);
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
        /// Serialize equations.
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <param name="amount"> Amount of equations </param>
        private static void SerializeEquations(string path, int amount)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var formatter = new SoapFormatter();

                var equations = new List<Quadratic>();

                for (var i = 0; i < amount; i++)
                {
                    try
                    {
                        Quadratic equation = GetEquation();
                        equations.Add(equation);
                    }
                    catch (ArgumentException)
                    {
                        i--;
                    }
                }

                formatter.Serialize(fs, equations);
            }
        }

        /// <summary>
        /// Soap serialization.
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <param name="amount"> Amount of equations </param>
        private static void SoapSerialization(string path, int amount)
        {
            try
            {
                SerializeEquations(path, amount);
            }
            catch (SerializationException ex)
            {
                PrintMessage($"Serialization error: {ex.Message}");
            }
            catch (IOException ex)
            {
                PrintMessage($"Problem with file: {ex.Message}");
            }
            catch (SecurityException ex)
            {
                PrintMessage($"Access exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                PrintMessage($"Unexpected error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deserialize equations.
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <param name="qDel"> My delegate </param>
        private static void Process(string path, Qdelegate qDel)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var formatter = new SoapFormatter();

                var equations = (List<Quadratic>)formatter.Deserialize(fs);

                equations.ForEach(el => qDel(el));
            }
        }

        /// <summary>
        /// Soap serialization.
        /// </summary>
        /// <param name="path"> Path to file </param>
        /// <param name="qDel"> My delegate </param>
        private static void SoapDeserialization(string path, Qdelegate qDel)
        {
            try
            {
                Process(path, qDel);
            }
            catch (SerializationException ex)
            {
                PrintMessage($"Serialization error: {ex.Message}");
            }
            catch (IOException ex)
            {
                PrintMessage($"Problem with file: {ex.Message}");
            }
            catch (SecurityException ex)
            {
                PrintMessage($"Access exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                PrintMessage($"Unexpected error: {ex.Message}");
            }
        }

        private static void Main()
        {
            const string path = "equations.soap";

            SoapSerialization(path, 5);

            PrintMessage("Serialized recording.\n");
            PrintMessage("Press any key to display on the screen.\n");
            Console.ReadKey(true);

            PrintMessage("\nIn the file, information about the following equations:\n\n",
                ConsoleColor.Yellow);

            SoapDeserialization(path, Processing.PrintEquation);

            PrintMessage("Press any key to solve equations.\n", ConsoleColor.Yellow);
            Console.ReadKey(true);
            PrintMessage("\r\nSolutions of equations with real roots:\n\n");

            SoapDeserialization(path, Processing.GetRealSolutions);

            PrintMessage("\nPress ENTER to exit...", ConsoleColor.Green);
            Console.ReadLine();
        }
    }
}
