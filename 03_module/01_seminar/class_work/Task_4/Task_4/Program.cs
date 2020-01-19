using MyLib;
using System;
using System.Collections.Generic;

namespace Task_4
{
    class Program
    {
        // Как вариант, можно было написать обычный TryParse.
        /// <summary>
        /// Get int number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="conditions"> Conditions for number </param>
        /// <returns> Int number </returns>
        private static T GetNumber<T>(string message, Predicate<T> conditions)
        {
            // Result.
            T result;

            Console.Write(message);

            while (true)
            {
                try
                {
                    // Trying to convert entered string to the require type.
                    result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    // If conversion is success.
                    if (conditions(result))
                        return result;

                    // Print conditions, if conversion isn't success.
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Число должно быть > 1");
                    Console.ResetColor();
                    Console.Write(message);
                }
                catch
                {
                    // Print error message.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат входных данных!");
                    Console.ResetColor();

                    Console.Write(message);
                }
            }
        }

        /// <summary>
        /// Get field of movement.
        /// </summary>
        /// <param name="raws"> Amount of raws </param>
        /// <param name="colums"> Amount of columns </param>
        /// <returns> Field </returns>
        private static char[,] GetField(int raws, int colums)
        {
            // Create field.
            char[,] field = new char[raws, colums];

            // Fill array.
            for (int i = 0; i < raws; i++)
                for (int j = 0; j < colums; j++)
                    field[i, j] = '_';

            // Set start position.
            field[raws - 1, 0] = '*';

            return field;
        }

        /// <summary>
        /// Print field.
        /// </summary>
        /// <param name="field"> Field </param>
        private static void PrintField(char[,] field)
        {
            // Print field.
            for (int i = 0; i < field.GetLength(0); i++, Console.WriteLine())
                for (int j = 0; j < field.GetLength(1); j++)
                    if (field[i, j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(field[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                        Console.Write(field[i, j] + " ");

            Console.WriteLine();
        }

        /// <summary>
        /// Get number instead letter.
        /// </summary>
        /// <param name="letter"> Letter </param>
        /// <returns> Index </returns>
        private static int GetIndex(char letter) =>
            letter switch
            {
                'R' => 0,
                'L' => 1,
                'F' => 2,
                'B' => 3,
            };

        /// <summary>
        /// Get trace.
        /// </summary>
        /// <param name="message"> Help message </param>
        /// <returns> Trace for robot </returns>
        private static string GetTrace(string message)
        {
            // Avaible moves.
            char[] moves = { 'R', 'L', 'F', 'B' };

            bool flagContinue = true;
            string trace = string.Empty;

            while (flagContinue)
            {
                // Read trace.
                Console.Write(message);
                trace = Console.ReadLine();

                // Check trace for correct.
                for (int i = 0; i < trace.Length; i++)
                {
                    if (!(Array.Exists(moves, val => val == trace[i])))
                    {
                        flagContinue = true;

                        // Print error message.
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Путь может содержать только буквы R, L, F, B!");
                        Console.ResetColor();

                        Console.Write(message);
                        break;
                    }

                    flagContinue = false;
                }
            }

            return trace;
        }

        static void Main(string[] args)
        {
            do
            {
                // Create new robot.
                Robot rob = new Robot();

                // Avaible moves for robot.
                Steps[] robotMoves = { rob.Right, rob.Left, rob.Forward, rob.Backward };

                // List from steps.
                List<Steps> movesList = new List<Steps>();

                Console.Clear();

                // Get amount of raws.
                int raws = GetNumber<int>("Введите число строк на поле: ",
                    val => val > 1);

                // Get amount of columns.
                int colums = GetNumber<int>("Введите число столбцов на поле: ",
                    val => val > 1);


                char[,] field = GetField(raws, colums);

                PrintField(field);

                // Print start position.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Start: " + rob.Position());
                Console.ResetColor();

                // Print instruction.
                Console.WriteLine("Путь должен состоять из заглавных букв R, L, F, B");
                Console.WriteLine("R - right, L -left, F - forward, B - backward");
                string trace = GetTrace("Введите путь: ");

                // Create list from steps.
                for (int i = 0; i < trace.Length; i++)
                {
                    int temp = i;
                    movesList.Add(robotMoves[GetIndex(trace[temp])]);
                }

                try
                {
                    // Robot's moves.
                    for (int i = 0; i < movesList.Count; i++)
                    {
                        if (i == 0)
                            field[raws - 1, 0] = '+';

                        movesList[i]();
                        field[raws - rob.Y - 1, rob.X] = '+';

                        if (i == movesList.Count - 1)
                            field[raws - rob.Y - 1, rob.X] = '*';
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    // Print error message.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Робот вышел за границы поля!");
                    Console.ResetColor();

                    Console.WriteLine("Для выхода нажмите ESC, " +
                                      "для повтора решения - любую другую клавишу");
                    continue;
                }

                PrintField(field);

                // Print end position.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("End: " + rob.Position());
                Console.ResetColor();

                // Repeat solution.
                Console.WriteLine("Для выхода нажмите ESC, " +
                                  "для повтора решения - любую другую клавишу");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}