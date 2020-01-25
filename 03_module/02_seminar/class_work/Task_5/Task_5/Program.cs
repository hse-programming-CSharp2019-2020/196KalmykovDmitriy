using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Task_5
    {
        class Program
        {
            private const int sizeArr = 5;
            private static T GetNumber<T>(string message) where T : new()
            {
                Console.Write(message);
                T result;

                while (true)
                {
                    try
                    {
                        result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                        return result;
                    }
                    catch
                    {
                        PrintMessage("Неверный формат входных данных!\n", ConsoleColor.Red);

                        Console.Write(message);
                    }
                }
            }

            private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
            {
                Console.ForegroundColor = color;
                Console.Write(message);
                Console.ResetColor();
            }

            private static void PrintArray(double[] arr)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Array.ForEach(arr, el => Console.Write($"{el:0.####} "));
                Console.ResetColor();
            }

            static void Main(string[] args)
            {
                do
                {
                    Console.Clear();

                    var arr = new double[sizeArr];

                    for (int i = 0; i < sizeArr; i++)
                        arr[i] = GetNumber<double>($"arr[{i}] = ");


                    PrintMessage("\nВведённый массив: ");
                    PrintArray(arr);
                    Console.WriteLine();

                    if (arr.Max() == 0)
                    {
                        PrintMessage("Максимальный элемент массива = 0, нормирование невозможно \n", ConsoleColor.Red);
                        Console.WriteLine("Для выхода нажмите ESC, " +
                       "для повтора решения - любую другую клавишу");
                        continue;
                    }


                    //arr = arr.Select(el => el / arr.Max()).ToArray();
                    arr = Array.ConvertAll(arr, el => el / arr.Max());

                    PrintMessage("Массив после нормирования: ");
                    PrintArray(arr);

                    Console.WriteLine("\nДля выхода нажмите ESC, " +
                        "для повтора решения - любую другую клавишу");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
        }
    }
}