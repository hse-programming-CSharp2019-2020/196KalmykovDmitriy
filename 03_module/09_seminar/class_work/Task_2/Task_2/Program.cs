using System;
using System.IO;
using System.Security;

namespace Task_2
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

        // ALTERNATIVE: could we use common TryParse.

        /// <summary>
        /// Get number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="conditions"> Conditions for number </param>
        /// <returns> Number </returns>
        private static T GetData<T>(string message, Predicate<T> conditions)
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

                    PrintMessage($"The letter must be in the range [A-{message[16]}]: ",
                        ConsoleColor.Yellow);
                }
                catch
                {
                    // Print error message.
                    PrintMessage("Wrong format of input data!\n", ConsoleColor.Red);

                    PrintMessage(message);
                }
            }
        }

        private static void Main()
        {
            var sep = Path.DirectorySeparatorChar;
            var path = $@"..{sep}..{sep}..{sep}Alphabet.txt";

            try
            {
                var fi = new FileInfo(path);
                FileStream fs = fi.Open(FileMode.OpenOrCreate);

                char s = default;

                // Check number of step.
                if (fs.Length > 0)
                {
                    s = GetData<char>($"Enter letter [A-{(char) ('A' + fs.Length - 1)}]: ",
                        el => (el >= 'A' && el < 'A' + fs.Length));
                }

                // Size of file.
                long len = fs.Length;

                if (len == 26)
                {
                    PrintMessage("Alphabet assembled!\n", ConsoleColor.Yellow);
                }
                else
                {
                    if (len == 0)
                    {
                        PrintMessage("File is empty!\n", ConsoleColor.Yellow);
                    }

                    if (len > 0)
                    {
                        fs.Seek(s - 'A', SeekOrigin.Begin);

                        // Change letter.
                        if (fs.ReadByte() != '*')
                        {
                            fs.Seek(s - 'A', SeekOrigin.Begin);
                            fs.WriteByte((byte) '*');
                        }
                    }

                    // Add new letter.
                    fs.Seek(len, SeekOrigin.Begin);
                    var bt = (byte) ('A' + len);
                    fs.WriteByte(bt);

                    PrintMessage("\nThe letter");
                    PrintMessage($" {(char) bt} ", ConsoleColor.Magenta);
                    PrintMessage("is added to the file \n\n");
                }

                PrintMessage("Letters in file:\n\n");

                fs.Seek(0, SeekOrigin.Begin);

                int letterInt;
                while ((letterInt = fs.ReadByte()) != -1)
                {
                    PrintMessage((char) letterInt + " ", ConsoleColor.Yellow);
                }

                fs.Dispose();

            }
            catch (IOException)
            {
                PrintMessage("Problem with file!", ConsoleColor.Red);
            }
            catch (SecurityException)
            {
                PrintMessage("Access error!", ConsoleColor.Red);
            }
            catch (Exception)
            {
                PrintMessage("Unexpected error!", ConsoleColor.Red);
            }

            PrintMessage("\n\nPress ESC to exit...", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
