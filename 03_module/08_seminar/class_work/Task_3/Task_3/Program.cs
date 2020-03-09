using System;

namespace Task_3
{
    internal class Program
    {
        private static readonly Random Rnd = new Random();

        #region Consts.

        private const int Amount = 7;
        private const int CircleBound = 30;
        private const int SquareBound = 4;

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

        /// <summary>
        /// Print info about circles and squares.
        /// </summary>
        /// <param name="circles"> Array of circles </param>
        /// <param name="squares"> Array of squares </param>
        private static void PrintInfo(Circle[] circles, Square[] squares)
        {
            Methods.PorArea(circles, CircleBound);
            Console.WriteLine();
            Methods.PorArea(squares, SquareBound);
        }

        // ALTERNATIVE: could use 2 methods for every array.

        /// <summary>
        /// Get circles and squares.
        /// </summary>
        /// <returns> Array of circles and array of squares </returns>
        private static (Circle[] circles, Square[] squares) GetFigures()
        {
            var circles = new Circle[Amount];
            var squares = new Square[Amount];

            for (var i = 0; i < Amount; i++)
            {
                circles[i] = new Circle(Rnd.Next(10));
                squares[i] = new Square(Rnd.Next(10));
            }

            return (circles, squares);
        }

        private static void Main()
        {
            do
            {
                Console.Clear();

                PrintMessage($"Bottom area limit for circles: {CircleBound}\n" +
                             $"Bottom area limit for squares: {SquareBound}\n\n");

                var (circles, squares) = GetFigures();

                PrintInfo(circles, squares);

                PrintMessage("\nPress ESC for exit, press any other key to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
