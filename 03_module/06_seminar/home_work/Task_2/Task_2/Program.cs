using System;
using System.Collections.Generic;

namespace Task_2
{
    internal class Program
    {
        private const int AmountOfAnimal = 5;

        private static readonly Random Rnd = new Random();

        /// <summary>
        /// Get random name of animal.
        /// </summary>
        /// <returns> Name of animal </returns>
        private static string GetRandomName()
        {
            var name = string.Empty;
            var length = Rnd.Next(1, 11);

            // Set first letter.
            name += (char)Rnd.Next('A', 'Z' + 1);

            for (var i = 1; i < length; i++)
                name += (char)Rnd.Next('a', 'z' + 1);

            return name;
        }

        /// <summary>
        /// Get animals.
        /// </summary>
        /// <returns> List from animals </returns>
        private static IEnumerable<Animal> GetAnimals()
        {
            var animals = new List<Animal>();
            var haveCats = false;
            var haveDogs = false;

            for (var i = 0; i < AmountOfAnimal; i++)
            {
                // At least 1 pet of every type.
                if (i == AmountOfAnimal - 1)
                {
                    if (!haveCats)
                    {
                        animals.Add(new Cat(GetRandomName()));
                        continue;
                    }
                    if (!haveDogs)
                    {
                        animals.Add(new Dog(GetRandomName()));
                        continue;
                    }
                }

                // 0 - cat.
                // 1 - dog.
                var typeAnimal = Rnd.Next(2);

                if (typeAnimal == 0)
                {
                    animals.Add(new Cat(GetRandomName()));
                    haveCats = true;
                }
                else
                {
                    animals.Add(new Dog(GetRandomName()));
                    haveDogs = true;
                }
            }

            return animals;
        }

        // ALTERNATIVE: could use common TryParse.

        /// <summary>
        /// Get number.
        /// </summary>
        /// <typeparam name="T"> Type of number </typeparam>
        /// <param name="message"> Help message </param>
        /// <param name="conditions"> Conditions for number </param>
        /// <returns> Number </returns>
        private static T GetNumber<T>(string message, Predicate<T> conditions)
        {
            PrintMessage(message);

            while (true)
            {
                try
                {
                    // Attempt to convert input string to required type.
                    var result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                    // Check extra conditions.
                    if (conditions(result))
                        return result;

                    PrintMessage("Number must be > 1 and < 11: ", ConsoleColor.Yellow);
                }
                catch
                {
                    // Print error message.
                    PrintMessage("Wrong format of input data!\n", ConsoleColor.Red);

                    PrintMessage(message);
                }
            }
        }

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

        private static void Main()
        {
            do
            {
                Console.Clear();

                var animalTrainer = new AnimalTrainer();

                var animals = GetAnimals();

                // Amount of exercises.
                var n = GetNumber<int>("Enter amount of exercises: ",
                    el => el > 1 && el < 11);

                // Subscribe all animals to the event.
                foreach (var animal in animals)
                    animalTrainer.BeginTrainingEvent += animal.OnTrainingStartedHandler;

                // Start training.
                animalTrainer.LetsGoTraining(n);

                PrintMessage("\nPress ESC for exit, press any other key to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
