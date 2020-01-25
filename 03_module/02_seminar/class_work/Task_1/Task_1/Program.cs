using MyLib;
using System;
using System.Linq;

namespace Task_1
{
    class Program
    {
        // Как вариант, могли создать новую строку и проходя циклом for по старой
        // добавлять в новую все 'не цифры'.
        /// <summary>
        /// Delete digits from string.
        /// </summary>
        /// <param name="str"> Input string </param>
        /// <returns> String without digits </returns>
        public static string RemoveDigits(string str) =>
            new string(str.Where(el => !char.IsDigit(el)).ToArray());

        // Как вариант, могли создать новую строку и проходя циклом for по старой
        // добавлять в новую все 'не пробелы'.
        /// <summary>
        /// Delete spaces from string.
        /// </summary>
        /// <param name="str"> Input string </param>
        /// <returns> String without spaces</returns>
        public static string RemoveSpaces(string str) =>
            new string(str.Where(el => el != ' ').ToArray());

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
        /// Print color strings.
        /// </summary>
        /// <param name="message"> Message before string </param>
        /// <param name="conv"> Converter </param>
        /// <param name="cr"> Convert rule </param>
        private static void PrintStrings(string message, string[] stringsForTest,
            Converter conv = null, ConvertRule cr = null)
        {
            // Print color strings.
            Array.ForEach(stringsForTest,
                str =>
                {
                    PrintMessage(message);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(conv is null ? str : conv.Convert(str, cr));
                });
            Console.ResetColor();

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            string[] stringsForTest =
                { "as2 d 3q2w2 ass ", "a    s2d ", "12qwd vwwqe2 cw3d " };

            // Initializate delegates.
            ConvertRule crMethod1 = RemoveSpaces,
                crMethod2 = RemoveDigits;

            var conv = new Converter();

            // Print initial strings.
            PrintStrings("Initial string: ", stringsForTest);

            // Print strings without spaces.
            PrintStrings("String without spaces: ", stringsForTest, conv, crMethod1);

            // Print strings without digits.
            PrintStrings("String without digits: ", stringsForTest, conv, crMethod2);

            // Initializate multicast delegate.
            ConvertRule crBoth = crMethod1 + crMethod2;

            // Test multicast delegate.
            PrintStrings("Test multicast delegate: ", stringsForTest, conv, crBoth);

            PrintMessage("Press ESC for exit", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}