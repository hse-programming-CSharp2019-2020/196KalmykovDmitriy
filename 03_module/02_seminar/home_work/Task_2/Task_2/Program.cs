using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        private static readonly Random rnd = new Random();

        private static int[] GetArr()
        {
            var tempArr = new int[10];

            for (int i = 0; i < 10; i++)
                tempArr[i] = rnd.Next(21);

            return tempArr;
        }

        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                var A = GetArr();

                PrintMessage("Первый массив: ");
                foreach (var item in A)
                    Console.Write(item + " ");

                Console.WriteLine();

                if (A.Any(el => el == 0))
                {
                    PrintMessage("Невозможно вычислить 1 / 0\n", ConsoleColor.Red);
                    PrintMessage("Press ESC for exit, " +
                                 "press any other key for repeat solution", ConsoleColor.Green);

                    continue;
                }

                var B = Array.ConvertAll(A, x => 1.0 / x);

                PrintMessage("Второй массив: ");
                foreach (var item in B)
                    Console.Write($"{item:0.##} ");

                Console.WriteLine();

                PrintMessage("Press ESC for exit, " +
                                  "press any other key for repeat solution", ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

    }
}
