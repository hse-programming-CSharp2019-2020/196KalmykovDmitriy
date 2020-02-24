using Animals;
using System;
using System.Collections.Generic;

namespace Task_5
{
    internal class Program
    {
        // Variable for generation characteristics of animals.
        private static readonly Random Rnd = new Random();

        /// <summary>
        /// Get list from animals.
        /// </summary>
        /// <returns> List from animals </returns>
        private static IEnumerable<Animal> GetZoo()
        {
            var zoo = new List<Animal>(10);

            for (var i = 0; i < 10; i++)
            {
                // 0 - Cockroach.
                // 1 - Kangaroo.
                // 2 - Cheetah.
                var animalType = Rnd.Next(0, 3);

                switch (animalType)
                {
                    case 0:
                        zoo.Add(new Cockroach(Rnd.Next(0, 5), Rnd.Next(3, 8)));
                        break;
                    case 1:
                        zoo.Add(new Kangaroo(Rnd.Next(0, 30), Rnd.Next(1, 5)));
                        break;
                    case 2:
                        zoo.Add(new Cheetah(Rnd.Next(0, 30),
                            Rnd.Next(70, 120), Rnd.Next(3, 8)));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return zoo;
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

        /// <summary>
        /// Print info about zoo.
        /// </summary>
        /// <param name="zoo"> Zoo from animals </param>
        private static void PrintInfo(IEnumerable<Animal> zoo)
        {
            foreach (var animal in zoo)
            {
                PrintMessage(animal.Descript() + Environment.NewLine);

                // Process cheetah separately for beautiful output.
                if (animal is Cheetah cheetah)
                {
                    cheetah.Jump();
                    cheetah.Run();
                }

                // If animal can jump.
                if (animal is IJump jump)
                    PrintMessage(jump.Jump());

                // If animal can run.
                if (animal is IRun run)
                    PrintMessage(run.Run());
            }
        }

        private static void Main()
        {
            do
            {
                Console.Clear();

                var zoo = GetZoo();

                PrintInfo(zoo);

                PrintMessage("Press ESC for exit, press any other key to repeat solution",
                    ConsoleColor.Green);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
