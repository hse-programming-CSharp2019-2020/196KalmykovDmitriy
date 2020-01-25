using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        private const int sizeArr = 10;
        private const int min = -15;
        private const int max = 15;
        private static readonly Random rnd = new Random();

        private static int[] GetIntsArray()
        {
            var arr = new int[sizeArr];

            for (int i = 0; i < sizeArr; i++)
                arr[i] = rnd.Next(min, max + 1);

            return arr;
        }

        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        private static void PrintArray(int[] arr, string message)
        {
            PrintMessage(message);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Array.ForEach(arr, el => Console.Write($"{el, -4}"));
            Console.ResetColor();

            Console.WriteLine(Environment.NewLine);
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                var intsArr = GetIntsArray();

                PrintArray(intsArr, "Сгенерированный массив: ");

                Array.Sort(intsArr, (x, y) =>
                {
                    if (Math.Abs(x) > Math.Abs(y))
                        return 1;

                    if (Math.Abs(x) == Math.Abs(y))
                        return 0;

                    return -1;
                });

                PrintArray(intsArr, "Отсортированный массив " +
                                    "в порядке возрастания абсолютных значений: ");

                PrintMessage("Для выхода нажмите ESC, " +
                                  "for repeat solution - any other key", ConsoleColor.Green);

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
