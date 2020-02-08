using System;

namespace Task_2
{
    internal class Program
    {
        /// <summary>
        /// Change values.
        /// </summary>
        /// <param name="me"> Expression </param>
        private static void ChangeValues(Expression me)
        {
            me.Ex = x => Math.Sqrt(Math.Abs(x));
            me.Ex = Math.Sin;
            me.Ex = x => x * x * x - 1;
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
            var me = new Expression(x => x * x + 2 * x - 3);
            var vs = new ValueStore(me, 0);

            // Subscribe methods to the event.
            me.OnExpChange += vs.OnExpChangeHandler;
            me.OnExpChange += () =>
                    PrintMessage(vs.CurrentVal + Environment.NewLine);

            // Print start value.
            PrintMessage(vs.CurrentVal + Environment.NewLine);

            ChangeValues(me);

            PrintMessage("\nPress ESC for exit", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
            }
        }
    }
}
