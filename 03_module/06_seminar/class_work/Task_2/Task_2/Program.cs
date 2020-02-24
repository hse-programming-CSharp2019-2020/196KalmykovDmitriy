using System;
using System.Collections.Generic;

namespace Task_2
{
    internal class Program
    {
        // ALTERNATIVE: could use common TryParse.

        /// <summary>
        /// Get number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message)
        {
            PrintMessage(message);

            while (true)
            {
                try
                {
                    // Attempt to convert input string to required type.
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    return result;
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

        /// <summary>
        /// Print info about figure.
        /// </summary>
        /// <param name="figure"> Figure </param>
        private static void Report(ITransform figure) =>
            PrintMessage($"Data of class object: {figure.GetType()}\n{figure}\n\n",
                ConsoleColor.Yellow);

        /// <summary>
        /// Change size of figure.
        /// </summary>
        /// <param name="figure"> Figure </param>
        /// <param name="coefficient"> Coefficient </param>
        /// <returns> Figure with modified size </returns>
        private static void Mapping(ITransform figure, double coefficient) =>
            figure.Transform(coefficient);

        /// <summary>
        /// Print info before and after modified size of figures.
        /// </summary>
        /// <param name="iList"> List from figures </param>
        private static void Processing(List<ITransform> iList)
        {
            // Print info before change.
            iList.ForEach(Report);

            // Get coefficient of change.
            var coefficient = GetNumber<double>("Enter coefficient for change: ");

            PrintMessage("\nAfter change:\n\n", ConsoleColor.Magenta);
            iList.ForEach(el => Mapping(el, coefficient));
            iList.ForEach(Report);
        }

        private static void Main()
        {
            #region From task 2

            //var iList = new List<ITransform>(4);
            //ITransform ira = new Circle();

            //ira.Transform(3);
            //iList.Add(ira);

            //ira = Mapping(new Cube(), 2);
            //iList.Add(ira);

            //iList.Add(new Circle());

            //iList.ForEach(Report);

            #endregion

            do
            {
                Console.Clear();

                // Initial list.
                var iList = new List<ITransform>(3)
                    {new Circle(), new Cube(), new Cylinder()};

                // Processing without Function.
                Processing(iList);

                PrintMessage("Now add Function:\n\n");
                iList.Add(new Function());

                // Processing with Function.
                Processing(iList);

                PrintMessage("Press ESC for exit, press any other key to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
