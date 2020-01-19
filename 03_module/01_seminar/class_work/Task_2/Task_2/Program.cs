using MyLib;
using System;

namespace Task_2
{
    class Program
    {
        // Variable for random.
        private static readonly Random rnd = new Random();
        private const int sizeArr = 10;

        /// <summary>
        /// Get int array.
        /// </summary>
        /// <returns> Int array </returns>
        private static int[] GetArrInts()
        {
            int[] arrInts = new int[sizeArr];

            // Fill array.
            for (int i = 0; i < sizeArr; i++)
                arrInts[i] = rnd.Next(10, 100);

            return arrInts;
        }

        /// <summary>
        /// Print all info.
        /// </summary>
        /// <param name="number"> number </param>
        /// <param name="arrInts"> int array </param>
        private static void PrintInfo(int number, int[] arrInts)
        {
            // Print number.
            Console.Write("Пятизначное число: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(number);
            Console.ResetColor();

            Console.Write($"Массив из {sizeArr} чисел: ");

            // Print array.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Array.ForEach(arrInts, val => Console.Write(val + " "));
            Console.ResetColor();

            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                // Set methods in delegats.
                Func1 getArr = Methods_Lib.GetArray;
                Func2 printArr = Methods_Lib.PrintArray;

                int number = rnd.Next(10000, 100000);

                int[] arrInts = GetArrInts();

                PrintInfo(number, arrInts);

                // Print number after convert to array.
                Console.Write($"{number} -> ");
                printArr(getArr(number));
                Console.WriteLine();

                // Print element of array after convert element to array.
                foreach (var el in arrInts)
                {
                    Console.Write($"{el} -> ");
                    printArr(getArr(el));
                    Console.WriteLine();
                }

                // Print info about delegats.
                Console.WriteLine();

                Console.WriteLine("Информация о делегате getArr:");
                Console.WriteLine($"Method: {getArr.Method}, " +
                                  $"Target: {getArr.Target}" + Environment.NewLine);

                Console.WriteLine("Информация о делегате printArr:");
                Console.WriteLine($"Method: {printArr.Method}," +
                                  $" Target: {printArr.Target}" + Environment.NewLine);

                // Repeat solution.
                Console.WriteLine("Для выхода нажмите ESC, " +
                                  "для повтора решения - любую другую клавишу");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}