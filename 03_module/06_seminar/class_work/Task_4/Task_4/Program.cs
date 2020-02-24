using System;
using System.Text;

namespace Task_4
{
    internal class Program
    {
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
        /// <param name="conditions"> Conditions for number </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message, Predicate<T> conditions)
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

                    PrintMessage("Enter 1, 2 or 3: ", ConsoleColor.Yellow);
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
        /// Processing choice.
        /// </summary>
        /// <param name="choice"> Your choice </param>
        /// <param name="booklet"> Booklet </param>
        private static void ProcessingChoice(int choice, IPublication booklet)
        {
            switch (choice)
            {
                case 1:
                    PrintMessage("Enter new text: ", ConsoleColor.Yellow);
                    booklet.Write(new StringBuilder(Console.ReadLine()));
                    break;
                case 2:
                    PrintMessage("Enter text for append: ", ConsoleColor.Yellow);
                    booklet.Append(new StringBuilder(Console.ReadLine()));
                    break;
                case 3:
                    booklet.Read();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void Main()
        {
            // Create new book.
            var booklet = new Book
            { Author = "Л.Н. Волгин", Title = @"""Consistent Optimum Principle""" };

            do
            {
                Console.Clear();
                PrintMessage(booklet + Environment.NewLine, ConsoleColor.Magenta);

                // Get choice.
                var choice = GetNumber<int>("Enter 1 - rewrite publication\n" +
                                            "Enter 2 - append publication\n" +
                                            "Enter 3 - Read book\n\n" +
                                            "Your choose: ", el => el < 4 && el > 0);

                // Processing.
                ProcessingChoice(choice, booklet);

                // Display new content, if it is.
                if (choice != 3)
                    PrintMessage("\nContent of book:\n" +
                                 booklet.Content + Environment.NewLine);

                PrintMessage("\nPress ESC for exit, press any other key to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

    }
}
