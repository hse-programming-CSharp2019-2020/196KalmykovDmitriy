using System;
using System.IO;
using System.Security;

namespace Task_4
{
    internal class Program
    {
        private static readonly Random Rnd = new Random(DateTime.Now.Millisecond);
        private const int AmountOfNumbers = 10;

        // Multiplication number.
        //private const int Pattern = 3;

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
            var path = $@"..{sep}..{sep}..{sep}IntegerNumbers.txt";
            int sum = 0;

            try
            {
                var file = new FileInfo(path);

                // Create file and stream.
                FileStream fs = file.Create();

                var binArr = new byte[4];

                PrintMessage("Numbers in file:\n\n", ConsoleColor.Magenta);
                for (var i = 0; i < AmountOfNumbers; i++)
                {
                    // Regular number.
                    int next = Rnd.Next(1000);
                    sum += next;

                    // Number from file.
                    PrintMessage(next + " ", ConsoleColor.Yellow);

                    binArr = BitConverter.GetBytes(next);
                    fs.Write(binArr, 0, binArr.Length);
                }

                fs.Dispose();

                fs = file.Open(FileMode.Open);
                fs.Seek(fs.Length, SeekOrigin.Begin);
                byte[] sumBinArr = BitConverter.GetBytes(sum / AmountOfNumbers);

                fs.Write(sumBinArr, 0, sumBinArr.Length);

                // Return to beginning of stream.
                fs.Position = 0;

                // Size of stream.
                long lenFs = fs.Length;

                //PrintMessage($"\n\nMultiples of {Pattern}:\n\n", ConsoleColor.Magenta);

                PrintMessage("\n\nAll numbers:\n\n", ConsoleColor.Magenta);
                for (var k = 0; k < lenFs / 4; k++)
                {
                    if (k == lenFs / 4 - 1)
                    {
                        PrintMessage("\nAverage: ", ConsoleColor.Yellow);
                    }

                    // Read 4 bytes.
                    fs.Read(binArr, 0, binArr.Length);
                    var decode = BitConverter.ToInt32(binArr, 0);
                    PrintMessage($"decode = {decode}\n");

                    #region Before change.

                    //if (decode % Pattern == 0)
                    //{
                    //    PrintMessage($"decode = {decode}\n");
                    //}

                    #endregion
                }
            }
            catch (IOException)
            {
                PrintMessage("Problem with file!\n", ConsoleColor.Red);
            }
            catch (SecurityException)
            {
                PrintMessage("Access error\n", ConsoleColor.Red);
            }
            catch (Exception)
            {
                PrintMessage("Unexpected error!\n", ConsoleColor.Red);
            }

            PrintMessage("\nPress ESC to exit...", ConsoleColor.Green);
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}