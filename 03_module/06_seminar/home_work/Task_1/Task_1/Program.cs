using Figures;
using System;
using System.Collections.Generic;

namespace Task_1
{
    internal class Program
    {
        // List from figures.
        private static readonly List<Figure> Figures = new List<Figure>();

        /// <summary>
        /// Get Point2D.
        /// </summary>
        /// <param name="index"> Index of triangle vertex </param>
        /// <returns> Point2D </returns>
        private static Point2D GetPoint2D(int index) =>
             new Point2D(GetNumber<double>($"Enter x{index}: "),
            GetNumber<double>($"Enter y{index}: "));

        /// <summary>
        /// Get triangle.
        /// </summary>
        /// <returns> Triangle </returns>
        private static Triangle GetTriangle()
        {
            Triangle triangle = null;

            for (var i = 0; i < 1; i++)
            {
                try
                {
                    // Get 3 vertex of triangle.
                    var p1 = GetPoint2D(1);
                    var p2 = GetPoint2D(2);
                    var p3 = GetPoint2D(3);

                    // Attempt to create triangle.
                    triangle = new Triangle(p1, p2, p3);
                }
                catch (ArgumentException ex)
                {
                    PrintMessage(ex.Message, ConsoleColor.Red);
                    i--;
                }
            }

            return triangle;
        }

        /// <summary>
        /// Get Square.
        /// </summary>
        /// <returns> Square </returns>
        private static Square GetSquare()
        {
            Square square = null;

            for (var i = 0; i < 1; i++)
            {
                try
                {
                    // Get side of square.
                    var side = GetNumber<double>("Enter side of square: ",
                        "Number must be > 0: ", el => el > 0);

                    // Attempt to create square.
                    square = new Square(side);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    PrintMessage(ex.Message, ConsoleColor.Red);
                    i--;
                }
            }

            return square;
        }

        /// <summary>
        /// Get Cube.
        /// </summary>
        /// <returns> Cube </returns>
        private static Cube GetCube()
        {
            Cube cube = null;

            for (var i = 0; i < 1; i++)
            {
                try
                {
                    // Get rib of cube.
                    var rib = GetNumber<double>("Enter rib of cube: ",
                        "Number must be > 0: ", el => el > 0);

                    // Attempt to create cube.
                    cube = new Cube(rib);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    PrintMessage(ex.Message, ConsoleColor.Red);
                    i--;
                }
            }

            return cube;
        }

        /// <summary>
        /// Add figure depending of choice.
        /// </summary>
        /// <param name="choice"> Choice </param>
        private static void ProcessingChoice(int choice)
        {
            Console.WriteLine();

            // 0 - triangle.
            // 1 - square.
            // 2 - cube.
            switch (choice)
            {
                case 1:
                    Figures.Add(GetTriangle());
                    PrintMessage("\nNew triangle added!\n", ConsoleColor.Green);
                    break;
                case 2:
                    Figures.Add(GetSquare());
                    PrintMessage("\nNew square added!\n", ConsoleColor.Green);
                    break;
                case 3:
                    Figures.Add(GetCube());
                    PrintMessage("\nNew cube added!\n", ConsoleColor.Green);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Add figure.
        /// </summary>
        private static void AddFigure()
        {
            var choice = GetNumber<int>("\nEnter your choice: ",
                "Enter 1, 2, or 3: ", el => el < 4 && el > 0);

            ProcessingChoice(choice);
        }

        /// <summary>
        /// Fill all list from figures.
        /// </summary>
        /// <param name="amount"> amount of figures </param>
        private static void FillFigures(int amount)
        {
            PrintMessage("\n1 - triangle\n" +
                         "2 - square\n" +
                         "3 - cube\n", ConsoleColor.Yellow);

            for (var i = 0; i < amount; i++)
                AddFigure();
        }

        // ALTERNATIVE: could use common TryParse.

        /// <summary>
        /// Get number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="condMessage"> Message for incorrect input data </param>
        /// <param name="conditions"> Conditions for number </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message, string condMessage = null,
            Predicate<T> conditions = null)
        {
            PrintMessage(message);

            while (true)
            {
                try
                {
                    // Attempt to convert input string to required type.
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    if (conditions is null)
                        return result;

                    // Check extra conditions.
                    if (conditions(result))
                        return result;

                    PrintMessage(condMessage, ConsoleColor.Yellow);
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
            do
            {
                Figures.Clear();
                Console.Clear();

                // Get amount of figures.
                var amount = GetNumber<int>("Enter amount of figures: ",
                    "Number must be > 0: ", el => el > 0);

                FillFigures(amount);

                Console.WriteLine();

                PrintMessage("Info about figures:\n\n");
                Figures.ForEach(el => PrintMessage(el + "\n\n", ConsoleColor.Yellow));

                PrintMessage("Press ESC for exit, press any other key to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
