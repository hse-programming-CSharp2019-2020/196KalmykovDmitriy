using System;

namespace Task_1
{
    // Declare delegat.
    delegate int Cast(double val);

    class Program
    {
        static void Main(string[] args)
        {
            // В самом начале создали второй: Cast cast2 = <Один из методов>
            // Для анонимного заменили бы Cast cast1 = delegate(int val){КОД};
            
            double[] numbersForTest = { 2.3, 0.02, 123, 25 };

            // Lambda expression to calculate the order of a number.
            Cast cast1 = val =>
            {
                // Order of a number.
                int result = val < 1 ? (int)Math.Log10(val) - 1 : (int)Math.Log10(val);

                // Print color text.
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{val} = {val / Math.Pow(10, result):0.######} * 10 ^ {result}");
                Console.ResetColor();

                Console.WriteLine($"Порядок числа {val} = {result}");

                return result;
            };

            // Lambda expression to find the nearest even number.
            // P. S. If the number is integer and odd, then the largest number is considered the closest.
            cast1 += val =>
            {
                // Как вариант, могла быть использована формула result = (int)val + (int)val / 2
                // Nearest even number.
                int result = ((int)val + 1) / 2 * 2;

                Console.WriteLine($"Ближайшее чётное число к {val:0.######} = {result}" +
                                  Environment.NewLine);

                return result;
            };

            // Test numbers from array.
            Array.ForEach(numbersForTest, val => cast1(val));

            Console.WriteLine("Для выхода нажмите ESC");
                while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}