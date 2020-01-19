using System;

namespace Task_3
{
    // Declare delegat.
    delegate double delegateConvertTemperature(double val);

    class Program
    {
        // Как вариант, можно было написать обычный TryParse.
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
                    // Trying to convert entered string to the require type.
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

        /// <summary>
        /// Print info to console.
        /// </summary>
        /// <param name="celsiusDegrees"> Celsius degrees </param>
        /// <param name="convTempArr"> Array from methods of conversion </param>
        private static void PrintInfo(double celsiusDegrees, delegateConvertTemperature[] convTempArr)
        {
            // Array from scales.
            string[] scaleArr = { "Фаренгейта", "Кельвина", "Ранкина", "Реомюра" };

            // Print info.
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Перевод из градусов Цельсия в градусы {scaleArr[i]}: ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{celsiusDegrees} -> {convTempArr[i](celsiusDegrees)}");
                Console.ResetColor();
            }
        }

        static void Main(string[] args)
        {
            TemperatureConverterlmp tempConv = new TemperatureConverterlmp();

            do
            {
                Console.Clear();

                // Celsius degrees.
                double celsiusDegrees = GetNumber<double>("Введите число градусов Цельсия: ");

                // Закомменченные методы просто нужно было реализовать по условию.
                // Array from methods of conversion.
                delegateConvertTemperature[] convArr =
                {
                    tempConv.ConvertCelsiusToFahrenheit,
                    StaticTempConverters.ConvertCelsiusToKelvin,
                    StaticTempConverters.ConvertCelsiusToRankin,
                    StaticTempConverters.ConvertCelsiusToReaumur
                    //tempConv.ConvertFahrenheitToCelsius ,
                    //StaticTempConverters.ConvertKelvinToCelsius,
                    //StaticTempConverters.ConvertRankinToCelsius,
                    //StaticTempConverters.ConvertReaumurToCelsius
                };

                PrintInfo(celsiusDegrees, convArr);

                // Repeat solution.
                Console.WriteLine("Для выхода нажмите ESC, " +
                                  "для повтора решения - любую другую клавишу");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
