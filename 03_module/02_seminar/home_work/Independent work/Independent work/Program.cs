using System;

namespace Independent_work
{
    internal class Program
    {
        // Declare delegate.
        private delegate void JokerDelegate();

        /// <summary>
        /// Print color message.
        /// </summary>
        /// <param name="message"> Message </param>
        /// <param name="color"> Message's color </param>
        public static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        private static void Main()
        {
            Comedian comedian = default;

            do
            {
                Console.Clear();

                // Get name and create comedian with that name.
                for (var i = 0; i < 1; i++)
                {
                    PrintMessage("Enter name of comedian without digits: ");
                    try
                    {
                        comedian = new Comedian(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        PrintMessage(ex.Message + Environment.NewLine, ConsoleColor.Red);
                        i--;
                    }
                }

                // Check and method call.
                if (comedian != null)
                {
                    JokerDelegate joker = comedian.Identify;
                    joker += Comedian.Joke;

                    joker();
                }

                // Message on further actions.
                PrintMessage("\n\nPress ESC for exit, " +
                             "press any other key for repeat solution", ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}