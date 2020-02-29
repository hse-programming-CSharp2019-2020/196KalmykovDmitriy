using MyLib;
using System;
using System.Collections.Generic;

namespace Task_5
{
    internal class Program
    {
        private static readonly Random Rnd = new Random();

        #region Consts

        private const int Min = -5;
        private const int Max = 10;

        #endregion

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

        // ALTERNATIVE: could use common TryParse.

        /// <summary>
        /// Get number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="extraMessage"> Extra message </param>
        /// <param name="conditions"> Conditions for number </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message, string extraMessage,
            Predicate<T> conditions)
        {
            PrintMessage(message);

            while (true)
            {
                try
                {
                    // Attempt to convert input string to required type.
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    // Check extra conditions.
                    if (conditions(result))
                        return result;

                    PrintMessage(extraMessage, ConsoleColor.Yellow);
                }
                catch
                {
                    // Print error message.
                    PrintMessage("Wrong format of input data!\n", ConsoleColor.Red);

                    PrintMessage(message);
                }
            }
        }

        /// <summary>
        /// Get random real number from interval.
        /// </summary>
        /// <returns> Random real number from interval </returns>
        private static double GetDoubleFromInterval() =>
            Min + Rnd.Next(Max - Min) * Rnd.NextDouble();

        /// <summary>
        /// Get list of mass points.
        /// </summary>
        /// <param name="amount"> Amount of mass points </param>
        /// <returns> List of mass points </returns>
        private static List<MassPoint> GetMassPoints(int amount)
        {
            Console.WriteLine();

            var massPoints = new List<MassPoint>(amount);

            // Fill list.
            for (var i = 0; i < amount; i++)
            {
                var x = GetDoubleFromInterval();
                var y = GetDoubleFromInterval();
                var point = new PointS(x, y);
                var mass = Rnd.Next(1, 6) * Rnd.NextDouble();

                massPoints.Add(new MassPoint(point, mass));
                PrintMessage(massPoints[i].ToString(), ConsoleColor.Magenta);
            }

            return massPoints;
        }

        /// <summary>
        /// Print info about points.
        /// </summary>
        /// <param name="setOfMassPoints"> Set of mass points </param>
        private static void PrintInfo(SetOfMassPoints setOfMassPoints)
        {
            Console.WriteLine();

            if (setOfMassPoints.SpecialSetMassPoints.Count == 0)
            {
                PrintMessage("There are no such points\n\n");
            }

            foreach (var massPoint in setOfMassPoints.SpecialSetMassPoints)
            {
                PrintMessage(massPoint.ToString(), ConsoleColor.Yellow);
            }
        }

        private static void Main()
        {
            do
            {
                Console.Clear();

                #region Set data.

                var amount = GetNumber<int>("Enter amount of points on the plane: ",
                    "Amount must be > 0: ", el => el > 0);

                var massPoints = GetMassPoints(amount);

                var radiusOfSet = GetNumber<double>("Enter radius of set: ",
                    "Radius must be > 1: ", el => el > 1);

                var setOfMassPoints = new SetOfMassPoints(massPoints,
                    new PointS(0, 0), radiusOfSet);

                #endregion

                PrintInfo(setOfMassPoints);

                PrintMessage("Press ESC for exit, press any other key ro repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
