using MyLib;
using System;

namespace Task_1
{
    class Program
    {
        // Как варианта, можно было сделать обычное считывание через TryParse.
        /// <summary>
        /// Get int number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <returns> Int number </returns>
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
                    Console.WriteLine("Неверный формат входных данных!");
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

                //Set method in delegate.
                MyDel findMax = TestClass.TestMethod;

                // First number.
                int val1 = GetNumber<int>("Введите первое число (целое): ");

                // Second number.
                int val2 = GetNumber<int>("Введите второе число (целое): ");

                // Print result.
                Console.WriteLine($"Наибольшее число: {findMax(val1, val2)}");

                // Repeat solution.
                Console.WriteLine("Для выхода нажмите ESC, " +
                                  "для повтора решения - любую другую кнопку");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}