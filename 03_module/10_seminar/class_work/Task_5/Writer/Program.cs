using MyLIb;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Writer
{
    internal class Program
    {
        private const int Max = 30;
        private const int ArrayLength = 30;
        private static readonly Random Rnd = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Get random color.
        /// </summary>
        /// <returns> Console color </returns>
        private static ConsoleColor GetRandomColor()
        {
            return (ConsoleColor)(Rnd.Next(Enum.GetNames(typeof(ConsoleColor)).Length));
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
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}Structs.txt";

            try
            {
                var binWriter = new BinaryWriter(new FileStream(path, FileMode.Create));
                var timer = new Stopwatch();

                #region Test structs.

                timer.Start();
                var chars = new ConsoleSymbolStruct[ArrayLength];

                // Fill array and print to file.
                for (var i = 0; i < ArrayLength; i++)
                {
                    try
                    {
                        chars[i] = new ConsoleSymbolStruct((char)Rnd.Next(32, 256),
                            Rnd.Next(30), Rnd.Next(30));
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        i--;
                        continue;
                    }

                    binWriter.Write(chars[i].X);
                    binWriter.Write(chars[i].Y);
                    binWriter.Write(chars[i].Symbol);


                }

                timer.Stop();
                PrintMessage($"\t\t\t\t\t\t\tSTRUCTURE:  {timer.Elapsed}");

                // Print symbols.
                for (var i = 0; i < ArrayLength; i++)
                {
                    Console.ForegroundColor = GetRandomColor();
                    Console.SetCursorPosition(chars[i].X, chars[i].Y);
                    Console.Write(chars[i].Symbol);
                    Thread.Sleep(50);
                }

                #endregion

                #region Test classes.

                timer.Start();
                var charsClass = new ConsoleSymbolClass[ArrayLength];

                // Fill array.
                for (var i = 0; i < ArrayLength; i++)
                {
                    try
                    {
                        charsClass[i] = new ConsoleSymbolClass((char)Rnd.Next(32, 256),
                            Rnd.Next(Max), Rnd.Next(Max));
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        i--;
                    }
                }

                timer.Stop();
                Console.SetCursorPosition(100, 2);
                PrintMessage($"\t\t\t\t\t\t\t\t\tCLASS:  {timer.Elapsed}");

                for (var i = 0; i < ArrayLength; i++)
                {
                    Console.ForegroundColor = GetRandomColor();
                    Console.SetCursorPosition(charsClass[i].X, charsClass[i].Y);
                    Console.Write(charsClass[i].Symbol);
                    Thread.Sleep(50);
                }

                #endregion
            }
            catch (IOException)
            {
                PrintMessage("Problem with file!\n", ConsoleColor.Red);
            }
            catch (Exception)
            {
                PrintMessage("Unexpected error!\n", ConsoleColor.Red);
            }

            Console.ReadLine();
        }
    }
}
