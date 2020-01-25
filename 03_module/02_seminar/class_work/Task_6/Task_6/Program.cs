using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    class Program
    {
        private static readonly Random rnd = new Random();

        #region Consts for plants.
        private const int minGrowth = 25;
        private const int maxGrowth = 100;

        private const int minPhotosensitivity = 0;
        private const int maxPhotosensitivity = 100;

        private const int minFrostresistance = 0;
        private const int maxFrostresistance = 80;
        #endregion

        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        private static T GetNumber<T>(string message, Predicate<T> cond) where T : new()
        {
            T result;

            Console.Write(message);

            while (true)
            {
                try
                {
                    result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    if (cond(result))
                        return result;

                    PrintMessage("Число должно быть натуральным\n", ConsoleColor.Yellow);
                    Console.Write(message);
                }
                catch
                {
                    PrintMessage("Неверный формат входных данных!\n", ConsoleColor.Red);

                    Console.Write(message);
                }
            }
        }

        private static void PrintInfoAboutPlants(Plant[] plantArr, string message)
        {
            PrintMessage(message, ConsoleColor.Yellow);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Array.ForEach(plantArr, el => Console.WriteLine(el));
            Console.ResetColor();

            Console.WriteLine();
        }


        private static int ParitySort(Plant x, Plant y)
        {
            if (x.Photosensitivity % 2 == 1 && y.Photosensitivity % 2 == 0)
                return 1;

            if (x.Photosensitivity % 2 == 0 && y.Photosensitivity % 2 == 0)
                return 0;

            return -1;
        }

        // Отрезок
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                int n = GetNumber<int>("Введите число элементов массива: ", el => el > 0);

                var plantArr = new Plant[n];

                for (int i = 0; i < n; i++)
                {
                    var growth = rnd.Next(maxGrowth - minGrowth + 1);
                    var photosensitivity = rnd.Next(maxPhotosensitivity - minPhotosensitivity + 1);
                    var frostresistance = rnd.Next(maxFrostresistance - minFrostresistance + 1);

                    plantArr[i] = new Plant(growth, photosensitivity, frostresistance);
                }


                PrintInfoAboutPlants(plantArr, "\nИнформация о всех растениях:\n");

                Array.Sort(plantArr, delegate (Plant x, Plant y)
                {
                    if (x.Growth < y.Growth)
                        return 1;

                    if (x.Growth == y.Growth)
                        return 0;

                    return -1;
                });

                PrintInfoAboutPlants(plantArr, "\nИнформация о всех растениях, " +
                    "отсортированных по росту в порядке убывания:\n");

                Array.Sort(plantArr, (x, y) =>
                {
                    if (x.Frostresistance > y.Frostresistance)
                        return 1;

                    if (x.Frostresistance == y.Frostresistance)
                        return 0;

                    return -1;
                });

                PrintInfoAboutPlants(plantArr, "\nИнформация о всех растениях, " +
                    "отсортированных по морозоустойчивости в порядке возрастания:\n");

                Array.Sort(plantArr, ParitySort);

                PrintInfoAboutPlants(plantArr, "\nИнформация о всех растениях, " +
                    "отсортированных по светочувствительности по чётности:\n");

                plantArr = Array.ConvertAll(plantArr,
                    el => el.Frostresistance % 2 == 0 ?
                        new Plant
                            (el.Growth, el.Photosensitivity, el.Frostresistance / 3) :
                        new Plant
                            (el.Growth, el.Photosensitivity, el.Frostresistance / 2));

                PrintInfoAboutPlants(plantArr, "\nИнформация о всех растениях, "+
                                               "после изменения морозоустойчивости\n");

                PrintMessage("Press ESC for exit, press any other key for repeat solution",
                    ConsoleColor.Green);

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
