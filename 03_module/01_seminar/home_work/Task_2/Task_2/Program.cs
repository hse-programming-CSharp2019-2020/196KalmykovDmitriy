using MyLib;
using System;

namespace Task_2
{
    class Program
    {
        // Как вариант, можно было сделать обычное считывание через TryParse.
        /// <summary>
        /// Get real number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <returns> Real number </returns>
        private static T GetNumber<T>(string message)
        {
            // Result.
            T result;

            Console.Write(message);

            while (true)
            {
                try
                {
                    // Trying to convert the entered string to the required type.
                    result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    // If conversion is success.
                    return result;
                }
                catch
                {
                    // Print error message.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат входных данных");
                    Console.ResetColor();

                    Console.Write(message);
                }
            }
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                // Set method in delegate.
                MeDel getSumIntegerParts = new TestClass().TestMethod;

                // First number.
                double val1 = GetNumber<double>("Введите первое число: ");

                // Second number.
                double val2 = GetNumber<double>("Введите второе число: ");

                // Print result.
                Console.WriteLine($"Сумма целых частей {val1} и {val2} = " +
                                  $"{getSumIntegerParts(val1, val2)}");

                // Repeat solution.
                Console.WriteLine("Для выхода нажмите ESC, " +
                                  "для повтора решения - любую другую клавишу");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}