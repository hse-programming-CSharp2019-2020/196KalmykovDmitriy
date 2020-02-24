using System;

namespace Task_1
{
    internal class Program
    {
        // Variable for random coefficient.
        private static readonly Random Coefficient = new Random();

        #region Range of random.
        private const int Min = 5;
        private const int Max = 15;
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
        /// Print info about figure.
        /// </summary>
        /// <param name="figure"> Figure </param>
        private static void Report(ITransform figure) =>
           PrintMessage($"Data of class object: {figure.GetType()}\n{figure}\n\n",
               ConsoleColor.Yellow);

        /// <summary>
        /// Get random number from interval.
        /// </summary>
        /// <returns> Random double number from interval </returns>
        private static double GetRandomNumber() =>
            Coefficient.Next(Min, Max) + Coefficient.NextDouble();

        /// <summary>
        /// Transform all figures.
        /// </summary>
        /// <param name="circle"> Circle </param>
        /// <param name="cube"> Cube </param>
        /// <param name="pyramid"> Pyramid </param>
        private static void TransformAllFigures(ITransform circle,
            ITransform cube, ITransform pyramid)
        {
            circle.Transform(GetRandomNumber());
            cube.Transform(GetRandomNumber());
            pyramid.Transform(GetRandomNumber());
        }

        /// <summary>
        /// Print info about all figures.
        /// </summary>
        /// <param name="circle"> Circle </param>
        /// <param name="cube"> Cube </param>
        /// <param name="pyramid"> Pyramid </param>
        /// <param name="ira"> Ira </param>
        private static void PrintInfo(ITransform circle,
            ITransform cube, ITransform pyramid, ITransform ira)
        {
            Report(circle);
            Report(cube);
            Report(pyramid);
            Report(ira);
        }

        private static void Main()
        {
            // Create figures.
            var circle = new Circle();
            var cube = new Cube();
            var pyramid = new Pyramid();
            ITransform ira = circle;

            PrintInfo(circle, cube, pyramid, ira);

            TransformAllFigures(circle, cube, pyramid);

            PrintMessage("After transform:\n\n");

            PrintInfo(circle, cube, pyramid, ira);

            // Help message to close console.
            PrintMessage("Press ESC for exit", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
