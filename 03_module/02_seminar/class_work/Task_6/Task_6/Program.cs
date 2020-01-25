using System;

namespace Task_6
{
    internal class Program
    {
        private static readonly Random Rnd = new Random();

        #region Consts for plants.
        private const int MinGrowth = 25;
        private const int MaxGrowth = 100;

        private const int MinPhotosensitivity = 0;
        private const int MaxPhotosensitivity = 100;

        private const int MinFrostresistance = 0;
        private const int MaxFrostresistance = 80;
        #endregion

        /// <summary>
        /// Print color message.
        /// </summary>
        /// <param name="message"> Message </param>
        /// <param name="color"> Message's color </param>
        private static void PrintMessage(string message, ConsoleColor color = ConsoleColor.Cyan)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Get number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="cond"> Condition for number </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message, Predicate<T> cond) where T : new()
        {
            Console.Write(message);

            while (true)
            {
                try
                {
                    // Attempt to get result.
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    // Check condition for number.
                    if (cond(result))
                        return result;

                    PrintMessage("Number must be natural\n", ConsoleColor.Yellow);
                    Console.Write(message);
                }
                catch
                {
                    // Print error message.
                    PrintMessage("Wrong input format!\n", ConsoleColor.Red);

                    Console.Write(message);
                }
            }
        }

        /// <summary>
        /// Print info about plants.
        /// </summary>
        /// <param name="plantArr"> Array from plants </param>
        /// <param name="message"> Help message </param>
        private static void PrintInfoAboutPlants(Plant[] plantArr, string message)
        {
            PrintMessage(message, ConsoleColor.Yellow);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Array.ForEach(plantArr, Console.WriteLine);
            Console.ResetColor();

            Console.WriteLine();
        }

        /// <summary>
        /// Method for sort.
        /// </summary>
        /// <param name="x"> First value in the couple </param>
        /// <param name="y"> Second value in the couple </param>
        /// <returns> 1, 0, or -1 </returns>
        private static int ParitySort(Plant x, Plant y) =>
                (x.Photosensitivity % 2).CompareTo(y.Photosensitivity % 2);

        private static void Main()
        {
            do
            {
                Console.Clear();

                // Get amount of elements.
                var n = GetNumber<int>("Enter amount of elements: ", el => el > 0);
                Plant[] plantArr;

                // Attempt to create array from 'n' elements.
                try
                {
                    plantArr = new Plant[n];
                }
                catch (OutOfMemoryException)
                {
                    PrintMessage("Impossible to create an array of this length", ConsoleColor.Red);
                    PrintMessage("\nPress ESC for exit, press any other key for repeat solution",
                        ConsoleColor.Green);
                    continue;
                }
                
                // Fill array.
                for (var i = 0; i < n; i++)
                {
                    var growth = Rnd.Next(MaxGrowth - MinGrowth + 1);
                    var photosensitivity = Rnd.Next(MaxPhotosensitivity - MinPhotosensitivity + 1);
                    var frostresistance = Rnd.Next(MaxFrostresistance - MinFrostresistance + 1);

                    try
                    {
                        plantArr[i] = new Plant(growth, photosensitivity, frostresistance);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        PrintMessage(ex.Message, ConsoleColor.Red);

                        i--;
                    }
                }

                PrintInfoAboutPlants(plantArr, "\nInfo about all plants:\n");

                // Sorted array by descending of growth.
                Array.Sort(plantArr, delegate (Plant x, Plant y)
                {
                    // Swap.
                    if (x.Growth < y.Growth)
                        return 1;

                    if (x.Growth == y.Growth)
                        return 0;

                    return -1;
                });

                PrintInfoAboutPlants(plantArr, "\nInfo about all plants, " +
                    "sorted by growth in descending order:\n");

                // Sorted array by ascending of frostresistance.
                Array.Sort(plantArr, (x, y) =>
                {
                    // Swap.
                    if (x.Frostresistance > y.Frostresistance)
                        return 1;

                    if (x.Frostresistance == y.Frostresistance)
                        return 0;

                    return -1;
                });

                PrintInfoAboutPlants(plantArr, "\nInfo about all plants, " +
                    "sorted by frostresistance in ascending order:\n");

                // Sorted array by parity of photosensivity.
                Array.Sort(plantArr, ParitySort);

                PrintInfoAboutPlants(plantArr, "\nInfo about all plants, " +
                    "sorted by photosensitivity by parity:\n");

                // Convert all elements.
                plantArr = Array.ConvertAll(plantArr,
                    el => el.Frostresistance % 2 == 0 ?
                        new Plant
                            (el.Growth, el.Photosensitivity, el.Frostresistance / 3) :
                        new Plant
                            (el.Growth, el.Photosensitivity, el.Frostresistance / 2));

                PrintInfoAboutPlants(plantArr, "\nInfo about all plants, " +
                                               "after a change in frost resistance:\n");

                PrintMessage("Press ESC for exit, press any other key for repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}