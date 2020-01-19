using System;

namespace Task_5
{
    class Program
    {
        // Upper bounds of sums.
        private const int jMax = 5;
        private const int iMax = 5;

        // Как вариант, можно было написать обычный TryParse.
        /// <summary>
        /// Get X.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="conditions"> Conditions for number </param>
        /// <returns> Real number </returns>
        private static T GetX<T>(string message)
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
                    return result;
                }
                catch
                {
                    // Print error message.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный формат входных данных!");
                    Console.ResetColor();
                }
            }
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                // X.
                double x = GetX<double>("Введите x: ");

                // Lambda expression for calculate internal multiply.
                Func<int, double> multiply = i =>
                {
                    // Current result of internal multiply.
                    double resultMultyply = 0;

                    // Calculate.
                    for (int j = 1; j <= jMax; j++)
                        resultMultyply += i * x / j;

                    return resultMultyply;
                };

                // Lambda expression for calculate external sum.
                Action sum = () =>
                {
                    // Result of external sum.
                    double resultSum = 0;

                    // Calculate.
                    for (int i = 1; i <= iMax; i++)
                        resultSum += multiply(i);

                    // Print result.
                    Console.Write("Значение всего выражения = ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{resultSum:0.####}");
                    Console.ResetColor();
                };

                // Start to compute.
                sum();

                // Repeat solution.
                Console.WriteLine("Для выхода нажмите ESC, " +
                                  "для повтора решения - любую другую клавишу");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}