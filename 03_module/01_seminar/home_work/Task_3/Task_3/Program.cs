using System;

namespace Task_3
{
    // Declare delegat.
    delegate double Sum(int n);

    class Program
    {
        // Как вариант можно было сделать обычное считвание через TryParse,
        // проверяя в цикле выполнение условий.
        /// <summary>
        /// Get upper bound of sum.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="conditions"> Conditions for number </param>
        /// <returns> Upper bound of sum </returns>
        private static T GetBound<T>(string message, Predicate<T> conditions)
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

                    // If conversion is success - check conditions.
                    if (conditions(result))
                        return result;

                    // If conditons aren't met.
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Число должно быть > 0");
                    Console.ResetColor();

                    Console.Write(message);
                }
                catch
                {
                    // Print error message.
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неправильный формат входных данных!");
                    Console.ResetColor();

                    Console.Write(message);
                }
            }
        }

        /// <summary>
        /// First variant.
        /// </summary>
        /// <param name="j"> Index </param>
        /// <returns> Member value </returns>
        private static double aJ1(int j) =>
            1.0 / j;

        /// <summary>
        /// Second variant.
        /// </summary>
        /// <param name="j"> Index </param>
        /// <returns> Member value </returns>
        private static double aJ2(int j) =>
            1 / Math.Pow(2, j);

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                
                // Upper bound of external sum.
                int N = GetBound<int>("Введите верхнюю границу суммы: ",
                    val => val > 0);

                // Lambda expression for calculate internal sum.
                Sum sumJ = i =>
                {
                    // Result of current internal sum.
                    double curResult = 0;

                    for (int j = 1; j <= i; j++)
                        curResult += aJ2(j);

                    return curResult;
                };

                // Lambda expression for calculate external sum.
                Sum sumI = amount =>
                {
                    // Result of external sum.
                    double result = 0;

                    for (int i = 1; i <= amount; i++)
                        result += sumJ(i);

                    return result;
                };

                // Print result.
                Console.Write("Искомая сумма = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{sumI(N):0.####}");
                Console.ResetColor();

                // Repeat solution.
                Console.WriteLine("Для выхода нажмите ESC, " +
                                  "для повтора решения - любую другую клавишу");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}