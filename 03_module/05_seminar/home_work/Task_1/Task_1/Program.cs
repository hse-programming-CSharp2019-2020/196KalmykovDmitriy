using MyLib;
using System;

namespace Task_1
{
    internal class Program
    {
        // ALTERNATIVE: could use common TryParse.

        /// <summary>
        /// Get number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="cond"> Condition for number </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message, Predicate<T> cond)
        {
            PrintMessage(message);

            while (true)
                try
                {
                    // Attempt to convert string to required type.
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    // Check extra condition.
                    if (cond(result))
                        return result;

                    PrintMessage("Number must be > 0: ", ConsoleColor.Yellow);
                }
                catch
                {
                    // Print error message.
                    PrintMessage("Wrong format of input data!\n", ConsoleColor.Red);
                    PrintMessage(message);
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
        /// Get rectangle.
        /// </summary>
        /// <returns> Rectangle </returns>
        private static Rectangle GetRectangle()
        {
            // Get 2 sides.
            var side1 = GetNumber<double>("Enter first side: ",
                el => el > 0);
            var side2 = GetNumber<double>("Enter second side: ",
                el => el > 0);

            return new Rectangle(side1, side2);
        }

        /// <summary>
        /// Change sides.
        /// </summary>
        /// <param name="block"> Block </param>
        private static void ChangeSides(Block block)
        {
            // Get new sides.
            var newSide1 = GetNumber<double>("Enter new side 1: ",
                el => el > 0);
            var newSide2 = GetNumber<double>("Enter new side 2: ",
                el => el > 0);

            block.ChangeSide(newSide1, newSide2);
        }

        private static void Main()
        {
            do
            {
                Console.Clear();

                var rectangle = GetRectangle();

                // Get height.
                var height = GetNumber<double>("Enter height of block: ",
                    el => el > 0);

                var block = new Block(rectangle, height);

                PrintMessage($"Volume: {block.GetVolume()}\n", ConsoleColor.Yellow);

                // Subscribe method to event.
                block.SideHasChangedEvent += block.EventHandler;

                Console.WriteLine();
                ChangeSides(block);

                PrintMessage("\nPress ESC for exit, press any other key for repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
